using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformPractice
{
    class GameClass
    {
        public int Ground { get; set; }
        public Player Player { get; set; }
        //public List<Texture2D> Animations { get; set; }
        public KeyboardState KeyboardState { get; set; }
        public KeyboardState PreviousKeyboardState { get; set; }
        public GamePadState GamePadState { get; set; }
        public GamePadState PreviousGamePadState { get; set; }
        public Background1 Background1 { get; set; }
        public Point Camera { get; set; }
        public Point BackgroundCamera { get; set; }

        public GameClass(List<Texture2D> textures)
        {
            Ground = 200;
            Player = new Player(Ground, textures);
            PreviousKeyboardState = Keyboard.GetState();
            PreviousGamePadState = GamePad.GetState(PlayerIndex.One);
            Camera = new Point(0, 0);
            BackgroundCamera = new Point(0, 0);
        }

        public void SetBackground1(Texture2D background1, Texture2D background2)
        {
            Background1 = new Background1(background1, background2, Player);

        }

        public void Update(KeyboardState keyboardState,KeyboardState previousKeyboardState, GamePadState padState, GamePadState previousGamePadState)
        {
            Player.Update(keyboardState, previousKeyboardState, padState, previousGamePadState);
            UpdateCamera(Player);
        }

        public void UpdateCamera(Player player)
        {
            var sideBuffer = 60;
            var screenWidth = 800;
            var leftMargin = player.X - Camera.X;
            //Using player.X + 60 on the next line instead of Player.Frame.Right because
            //the frame dimensions vary each individual animation frame.  It could cause
            //inconsistent camera behavior
            var rightMargin = (Camera.X + screenWidth) - (player.X + 60);

            if (leftMargin < sideBuffer)
            {
                var cameraX = Camera.X;
                var backgroundCameraX = BackgroundCamera.X;
                var movement = sideBuffer - leftMargin;

                cameraX -= movement;
                backgroundCameraX -= movement / 2;

                Camera = new Point(cameraX, Camera.Y);
                BackgroundCamera = new Point(backgroundCameraX, BackgroundCamera.Y);
            }
            else if (rightMargin < sideBuffer)
            {
                var cameraX = Camera.X;
                var backgroundCameraX = BackgroundCamera.X;
                var movement = (rightMargin - sideBuffer);
                cameraX -= movement;
                backgroundCameraX -= movement / 2;

                Camera = new Point(cameraX, Camera.Y);
                BackgroundCamera = new Point(backgroundCameraX, BackgroundCamera.Y);
            }

            if(Camera.X <= 0)
            {
                var cameraX = 0;
                Camera = new Point(cameraX, Camera.Y);
                BackgroundCamera = new Point(cameraX, BackgroundCamera.Y);
            }
        }


    }


}
