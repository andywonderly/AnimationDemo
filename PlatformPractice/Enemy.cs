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
    class Enemy
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

        public Enemy(int ground, List<Texture2D> textures)
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

        }

        public void SetIdle()
        {
            switch (State)
            {
                case PlayerState.JabLeft:
                case PlayerState.UppercutLeft:
                case PlayerState.WalkingLeft:
                    State = PlayerState.IdleLeft;
                    break;
                case PlayerState.JabRight:
                case PlayerState.UppercutRight:
                case PlayerState.WalkingRight:
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
    }


}
