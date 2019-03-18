using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformPractice
{
    class Animation
    {
        //This class contains animation info.  The animation will be advanced by the player logic,
        //not by the animation itself.

        public Texture2D Texture { get; set; }
        public string Name { get; set; }
        public List<AnimationFrame> Frames { get; set; }
        public int CurrentFrame { get; set; }
        public int TickCounter { get; set; }

        public Animation(Texture2D texture, string name)
        {
            Texture = texture;
            CurrentFrame = 0;
            TickCounter = 0;
            Name = name;

            //Load individual frames here based on name
            switch(name)
            {
                case "JabRight":
                case "JabRight_Red":
                    Frames = JabRightFrames();
                    break;
                case "JabLeft":
                case "JabLeft_Red":
                    Frames = JabLeftFrames();
                    break;
                case "IdleRight":
                case "IdleRight_Red":
                    Frames = IdleRightFrames();
                    break;
                case "IdleLeft":
                case "IdleLeft_Red":
                    Frames = IdleLeftFrames();
                    break;
                case "WalkRight":
                case "WalkRight_Red":
                    Frames = WalkRightFrames();
                    break;
                case "WalkLeft":
                case "WalkLeft_Red":
                    Frames = WalkLeftFrames();
                    break;
                case "UppercutRight":
                case "UppercutRight_Red":
                    Frames = UppercutRightFrames();
                    break;
                case "UppercutLeft":
                case "UppercutLeft_Red":
                    Frames = UppercutLeftFrames();
                    break;
                case "TakeHitRight":
                case "TakeHitRight_Red":
                    Frames = TakeHitRightFrames();
                    break;
                case "TakeHitLeft":
                case "TakeHitLeft_Red":
                    Frames = TakeHitLeftFrames();
                    break;
                case "KnockdownRight":
                case "KnockdownRight_Red":
                    Frames = KnockdownRightFrames();
                    break;
                case "KnockdownLeft":
                case "KnockdownLeft_Red":
                    Frames = KnockdownLeftFrames();
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point camera, int playerX, int playerY, Camera2D _camera)
        {
            var currentFrame = Frames[CurrentFrame];
            var x = playerX + currentFrame.Xoffset - camera.X;
            var y = playerY + currentFrame.Yoffset - camera.Y;
            var frameWidth = currentFrame.Width;
            var frameHeight = currentFrame.Height;
            
            Rectangle sourceRectangle = new Rectangle(currentFrame.PixelX, 0, currentFrame.Width, currentFrame.Height);
            Rectangle destinationRectangle = new Rectangle(x, y, frameWidth, frameHeight);
            var transformMatrix = _camera.GetViewMatrix();
            spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix());
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public static List<AnimationFrame> JabRightFrames()
        {
            var frames = new List<AnimationFrame>();
            var pauseTicks = 4;

            frames.Add(new AnimationFrame(0, 69, 63, 0, 0, FrameType.Startup, pauseTicks));
            frames.Add(new AnimationFrame(71, 69, 98, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(174, 69, 66, 0, 0, FrameType.Recovery, pauseTicks));
            //These are commented out to make this a single strike for the time being.
            //I am guessing that in the normal operation of Comix Zone, you can mash the jab
            //button and have the player continuously swing right, left, right, left
            //similar to early Mortal Kombats.
            //frames.Add(new AnimationFrame(255, 62, 0, FrameType.Startup, 2));
            //frames.Add(new AnimationFrame(323, 92, 0, FrameType.Active, 2));
            //frames.Add(new AnimationFrame(420, 66, 0, FrameType.Recovery, 2));

            return frames;
        }

        public static List<AnimationFrame> JabLeftFrames()
        {
            var frames = new List<AnimationFrame>();
            var pauseTicks = 4;

            frames.Add(new AnimationFrame(423, 69, 63, -10, 0, FrameType.Recovery, pauseTicks));
            frames.Add(new AnimationFrame(317, 69, 98, 63-98-10, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(246, 69, 66, 63-66-10, 0, FrameType.Startup, pauseTicks));
            //These are commented out to make this a single strike for the time being.
            //I am guessing that in the normal operation of Comix Zone, you can mash the jab
            //button and have the player continuously swing right, left, right, left
            //similar to early Mortal Kombats.
            //frames.Add(new AnimationFrame(255, 62, 0, FrameType.Startup, 2));
            //frames.Add(new AnimationFrame(323, 92, 0, FrameType.Active, 2));
            //frames.Add(new AnimationFrame(420, 66, 0, FrameType.Recovery, 2));

            return frames;
        }

        public static List<AnimationFrame> IdleRightFrames()
        {
            var frames = new List<AnimationFrame>();
            var pauseTicks = 4;

            frames.Add(new AnimationFrame(0, 74, 54, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(68, 74, 52, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(128, 74, 53, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(196, 74, 52, 0, 0, FrameType.Active, pauseTicks));

            return frames;
        }

        public static List<AnimationFrame> IdleLeftFrames()
        {
            var frames = new List<AnimationFrame>();
            var pauseTicks = 4;

            frames.Add(new AnimationFrame(196, 74, 52, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(128, 74, 53, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(68, 74, 52, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(0, 74, 54, 0, 0, FrameType.Active, pauseTicks));

            return frames;
        }

        public static List<AnimationFrame> WalkRightFrames()
        {
            var frames = new List<AnimationFrame>();
            var pauseTicks = 4;

            frames.Add(new AnimationFrame(0, 76, 53, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(62, 76, 49, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(130, 76, 52, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(199, 76, 53, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(271, 76, 58, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(350, 76, 54, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(421, 76, 53, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(490, 76, 49, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(558, 76, 63, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(640, 76, 65, 0, 0, FrameType.Active, pauseTicks));

            return frames;
        }
        public static List<AnimationFrame> WalkLeftFrames()
        {
            var frames = new List<AnimationFrame>();
            var pauseTicks = 4;

            frames.Add(new AnimationFrame(654, 76, 52, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(595, 76, 49, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(524, 76, 52, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(454, 76, 53, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(377, 76, 58, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(302, 76, 54, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(232, 76, 53, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(167, 76, 49, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(85, 76, 63, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(1, 76, 65, 0, 0, FrameType.Active, pauseTicks));

            return frames;
        }

        public static List<AnimationFrame> UppercutRightFrames()
        {
            var frames = new List<AnimationFrame>();
            var pauseTicks = 4;

            frames.Add(new AnimationFrame(0, 93, 51, 0, -20, FrameType.Startup, pauseTicks));
            frames.Add(new AnimationFrame(59, 93, 57, 0, -20, FrameType.Startup, pauseTicks));
            frames.Add(new AnimationFrame(125, 93, 74, 0, -20, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(204, 93, 84, -8, -20, FrameType.Active, 8));
            frames.Add(new AnimationFrame(301, 93, 62, -6, -20, FrameType.Active, 6));
            frames.Add(new AnimationFrame(374, 93, 53, 0, -20, FrameType.Recovery, pauseTicks));
            frames.Add(new AnimationFrame(440, 93, 51, 0, -20, FrameType.Recovery, pauseTicks));
            frames.Add(new AnimationFrame(499, 93, 51, 0, -20, FrameType.Recovery, pauseTicks));

            return frames;
        }

        public static List<AnimationFrame> UppercutLeftFrames()
        {
            var frames = new List<AnimationFrame>();
            var pauseTicks = 4;

            frames.Add(new AnimationFrame(499, 93, 51, 0, -20, FrameType.Startup, pauseTicks));
            frames.Add(new AnimationFrame(434, 93, 57, 0, -20, FrameType.Startup, pauseTicks));
            frames.Add(new AnimationFrame(351, 93, 74, 0, -20, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(262, 93, 84, -8, -20, FrameType.Active, 8));
            frames.Add(new AnimationFrame(187, 93, 62, -6, -20, FrameType.Active, 6));
            frames.Add(new AnimationFrame(123, 93, 53, 0, -20, FrameType.Recovery, pauseTicks));
            frames.Add(new AnimationFrame(59, 93, 51, 0, -20, FrameType.Recovery, pauseTicks));
            frames.Add(new AnimationFrame(0, 93, 51, 0, -20, FrameType.Recovery, pauseTicks));

            return frames;
        }

        public static List<AnimationFrame> TakeHitRightFrames()
        {
            var frames = new List<AnimationFrame>();
            var pauseTicks = 4;

            frames.Add(new AnimationFrame(0, 70, 67, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(0, 70, 67, -8, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(0, 70, 67, -16, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(0, 70, 67, -24, 0, FrameType.Active, pauseTicks));

            return frames;
        }

        public static List<AnimationFrame> TakeHitLeftFrames()
        {
            var frames = new List<AnimationFrame>();
            var pauseTicks = 4;

            frames.Add(new AnimationFrame(0, 70, 67, 0, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(0, 70, 67, 8, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(0, 70, 67, 16, 0, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(0, 70, 67, 24, 0, FrameType.Active, pauseTicks));

            return frames;
        }

        public static List<AnimationFrame> KnockdownRightFrames()
        {
            var frames = new List<AnimationFrame>();
            var pauseTicks = 4;
            var yOffset = 18;
            var yOffset2 = 23;

            frames.Add(new AnimationFrame(0, 63, 68, 0, yOffset, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(90, 63, 78, 0, yOffset, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(187, 63, 69, 0, yOffset, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(269, 63, 91, 0, yOffset, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(371, 63, 88, 0, yOffset, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(466, 63, 84, 0, yOffset2, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(557, 63, 69, 0, yOffset2, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(646, 63, 51, 0, yOffset2, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(705, 63, 51, 0, yOffset2, FrameType.Active, pauseTicks));

            return frames;
        }

        public static List<AnimationFrame> KnockdownLeftFrames()
        {
            var frames = new List<AnimationFrame>();
            var pauseTicks = 4;
            var pauseTicks2 = 30;
            var yOffset = 18;
            var yOffset2 = 23;

            frames.Add(new AnimationFrame(688, 63, 68, 0, yOffset, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(588, 63, 78, 0, yOffset, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(500, 63, 69, 0, yOffset, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(396, 63, 91, 0, yOffset, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(297, 63, 88, 0, yOffset, FrameType.Active, pauseTicks));
            frames.Add(new AnimationFrame(207, 63, 84, 0, yOffset2, FrameType.Active, pauseTicks2));
            frames.Add(new AnimationFrame(130, 63, 69, 0, yOffset2, FrameType.Active, pauseTicks2));
            frames.Add(new AnimationFrame(59, 63, 51, 0, yOffset2, FrameType.Active, pauseTicks2));
            frames.Add(new AnimationFrame(0, 63, 51, 0, yOffset2, FrameType.Active, pauseTicks2));

            return frames;
        }


    }
}


