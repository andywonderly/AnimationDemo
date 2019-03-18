using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlatformPractice.Game1;

namespace PlatformPractice
{
    class Player
    {
        public Rectangle Frame { get; set; }
        //public Animation Animation { get; set; }
        public List<Animation> Animations { get; set; }
        //public List<Attack> NormalAttacks { get; set; }
        public Animation CurrentAnimation { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public PlayerState State { get; set; }
        public PlayerState StateCopy { get; set; }
        public PlayerState PreviousState { get; set; }
        public int Movement { get; set; }
        //public Attack Jab { get; set; }
        //public Attack Short { get; set; }
        //public Attack PunchUppercut { get; set; }
        //public Attack KickOverhead { get; set; }
        //public Attack KickUppercut { get; set; }

        public Player(int ground, List<Texture2D> textures)
        {
            State = PlayerState.IdleRight;
            PreviousState = State;
            X = 50;
            Y = ground + 120;
            Animations = new List<Animation>();

            foreach(var item in textures)
            {
                var tempAnimation = new Animation(item, item.Name);
                Animations.Add(tempAnimation);
            }

            CurrentAnimation = Animations.FirstOrDefault(n => n.Name == "IdleRight");

            var frameWidth = CurrentAnimation.Frames[CurrentAnimation.CurrentFrame].Width;
            var frameHeight = CurrentAnimation.Frames[CurrentAnimation.CurrentFrame].Height;

            Frame = new Rectangle(X, Y, frameWidth, frameHeight);
        }





        public void Update(KeyboardState keyboardState, KeyboardState previousKeyboardState, GamePadState padState, GamePadState previousGamePadState)
        {
            var walkSpeed = 4;

            //Check for attack buttons before walking buttons.  Attacks supercede walking

            //Making these bools serves two purposes:  it makes the conditionals that follow easier to read
            //and it snapshots the current situation.  For example, if you test the state itself in the
            //conditionals, it could change along the way and cause unexpected behavior.  This way,
            //only one state change can occur per frame.
            bool keyA = keyboardState.IsKeyDown(Keys.A) && !previousKeyboardState.IsKeyDown(Keys.A);
            bool keyS = keyboardState.IsKeyDown(Keys.S) && !previousKeyboardState.IsKeyDown(Keys.S);
            bool keyLeft = keyboardState.IsKeyDown(Keys.Left);
            bool keyRight = keyboardState.IsKeyDown(Keys.Right);
            bool padLeft = padState.IsButtonDown(Buttons.DPadLeft);
            bool padRight = padState.IsButtonDown(Buttons.DPadRight);
            bool buttonX = padState.IsButtonDown(Buttons.X) && !previousGamePadState.IsButtonDown(Buttons.X);
            bool buttonY = padState.IsButtonDown(Buttons.Y) && !previousGamePadState.IsButtonDown(Buttons.Y);
            bool walkingRight = (State == PlayerState.WalkingRight);
            bool walkingLeft = (State == PlayerState.WalkingLeft);
            bool attacking = (State == PlayerState.JabLeft || State == PlayerState.JabRight || State == PlayerState.UppercutLeft || State == PlayerState.UppercutRight);
            bool takingHit = (State == PlayerState.KnockdownLeft || State == PlayerState.KnockdownRight || State == PlayerState.HitStunLeft || State == PlayerState.HitStunRight);
            bool hit = keyboardState.IsKeyDown(Keys.H) && (State == PlayerState.IdleLeft || State == PlayerState.IdleRight);
            bool knockdown = keyboardState.IsKeyDown(Keys.K) && (State == PlayerState.IdleLeft || State == PlayerState.IdleRight);

            if (keyA || buttonX && (walkingRight || walkingLeft))
            {
                Jab();
            }
            else if (keyS || buttonY && (walkingRight|| walkingLeft))
            {
                Uppercut();
            }
            else if((keyLeft || padLeft) && !(keyRight || padRight) && !attacking)
            {
                X -= walkSpeed;
                StateCopy = State;
                State = PlayerState.WalkingLeft;
            }
            else if ((keyRight || padRight) && !(keyLeft || padLeft) && !attacking)
            {
                X += walkSpeed;
                StateCopy = State;
                State = PlayerState.WalkingRight;
            }
            else if(hit)
            {
                TakeHit();
            }
            else if(knockdown)
            {
                Knockdown();
            }
            
            //If the player is currently in a walking state but no walk buttons are being pressed, set to idle.
            //This code should trigger the following if(PreviousState != State) block to trigger which will take
            //care of the animation reset.
            if((State == PlayerState.WalkingLeft || State == PlayerState.WalkingRight) && !(keyLeft || keyRight || padLeft || padRight))
            {
                SetIdleDirection();
            }

            //Update based on current state
            if(PreviousState != State)
            {
                //If there has been a state change, set the animation accordingly
                switch(State)
                {
                    case PlayerState.IdleLeft:
                        CurrentAnimation = Animations.First(n => n.Name == "IdleLeft");
                        break;
                    case PlayerState.IdleRight:
                        CurrentAnimation = Animations.First(n => n.Name == "IdleRight");
                        break;
                    case PlayerState.WalkingLeft:
                        CurrentAnimation = Animations.First(n => n.Name == "WalkLeft");
                        break;
                    case PlayerState.WalkingRight:
                        CurrentAnimation = Animations.First(n => n.Name == "WalkRight");
                        break;
                    case PlayerState.JabLeft:
                        CurrentAnimation = Animations.First(n => n.Name == "JabLeft");
                        break;
                    case PlayerState.JabRight:
                        CurrentAnimation = Animations.First(n => n.Name == "JabRight");
                        break;
                    case PlayerState.UppercutRight:
                        CurrentAnimation = Animations.First(n => n.Name == "UppercutRight");
                        break;
                    case PlayerState.UppercutLeft:
                        CurrentAnimation = Animations.First(n => n.Name == "UppercutLeft");
                        break;
                }

                //And reset counters
                CurrentAnimation.CurrentFrame = 0;
                CurrentAnimation.TickCounter = 0;
                //And copy the state to previous state
                PreviousState = State;
                
            }
            else
            {
                //If there hasn't been a state change, advance the existing animation

                //Get tick counter and pause ticks of current animation and current frame, respectively
                var tickCounter = CurrentAnimation.TickCounter;
                var pauseTicks = CurrentAnimation.Frames[CurrentAnimation.CurrentFrame].PauseTicks;

                //Advance the frame here if condition is met
                if(tickCounter > 0 && tickCounter % pauseTicks == 0)
                {
                    CurrentAnimation.CurrentFrame++;
                    CurrentAnimation.TickCounter = 0;
                }

                CurrentAnimation.TickCounter++;

                //If CurrentFrame counter exceeds frame count, reset counters
                if(CurrentAnimation.CurrentFrame == CurrentAnimation.Frames.Count())
                {
                    CurrentAnimation.CurrentFrame = 0;
                    CurrentAnimation.TickCounter = 0;

                    //And set current state to idle (and proper idle direction) based on previous state
                    if (attacking || walkingLeft || walkingRight || takingHit)
                    {
                        PreviousState = State;
                        SetIdleDirection();
                    }

                }

            }

            //Update the Frame
            var frameWidth = CurrentAnimation.Frames[CurrentAnimation.CurrentFrame].Width;
            var frameHeight = CurrentAnimation.Frames[CurrentAnimation.CurrentFrame].Height;
            Frame = new Rectangle(X, Y, frameWidth, frameHeight);
        }

        public void SetIdleDirection()
        {
            switch (State)
            {
                case PlayerState.JabLeft:
                case PlayerState.UppercutLeft:
                case PlayerState.WalkingLeft:
                case PlayerState.HitStunLeft:
                case PlayerState.KnockdownLeft:
                    State = PlayerState.IdleLeft;
                    break;
                case PlayerState.JabRight:
                case PlayerState.UppercutRight:
                case PlayerState.WalkingRight:
                case PlayerState.HitStunRight:
                case PlayerState.KnockdownRight:
                    State = PlayerState.IdleRight;
                    break;

            }
        }

        public void Jab()
        {
            if (State == PlayerState.WalkingLeft || State == PlayerState.IdleLeft)
            {
                StateCopy = State;
                State = PlayerState.JabLeft;
                CurrentAnimation = Animations.First(n => n.Name == "JabLeft");
            }
            else if (State == PlayerState.WalkingRight || State == PlayerState.IdleRight)
            {
                StateCopy = State;
                State = PlayerState.JabRight;
                CurrentAnimation = Animations.First(n => n.Name == "JabRight");
            }
        }

        public void Uppercut()
        {
            if (State == PlayerState.WalkingLeft || State == PlayerState.IdleLeft)
            {
                StateCopy = State;
                State = PlayerState.UppercutLeft;
                CurrentAnimation = Animations.First(n => n.Name == "UppercutLeft");
            }
            else if (State == PlayerState.WalkingRight || State == PlayerState.IdleRight)
            {
                StateCopy = State;
                State = PlayerState.UppercutRight;
                CurrentAnimation = Animations.First(n => n.Name == "UppercutRight");
            }
        }

        public void Knockdown()
        {
            if(State == PlayerState.IdleLeft)
            {
                StateCopy = State;
                State = PlayerState.KnockdownLeft;
                CurrentAnimation = Animations.First(n => n.Name == "KnockdownLeft");
            }
            else if(State == PlayerState.IdleRight)
            {
                StateCopy = State;
                State = PlayerState.KnockdownRight;
                CurrentAnimation = Animations.First(n => n.Name == "KnockdownRight");
            }        
        }

        public void TakeHit()
        {
            if (State == PlayerState.IdleLeft)
            {
                StateCopy = State;
                State = PlayerState.HitStunLeft;
                CurrentAnimation = Animations.First(n => n.Name == "TakeHitLeft");
            }
            else if (State == PlayerState.IdleRight)
            {
                StateCopy = State;
                State = PlayerState.HitStunRight;
                CurrentAnimation = Animations.First(n => n.Name == "TakeHitRight");
            }
        }


    }


}
