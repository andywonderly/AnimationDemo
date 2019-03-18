using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformPractice
{
    //This class contains the info for a single animation frame.
    class AnimationFrame
    {
        public int PixelX { get; set; }
        
        public int Width { get; set; }
        public int Height { get; set; }
        public int Xoffset { get; set; }
        public int Yoffset { get; set; }

        public FrameType Type { get; set; }
        public int PauseTicks { get; set; }
        public List<Rectangle> Hitboxes { get; set; }


        public AnimationFrame(int pixelX, int pixelHeight, int pixelWidth, int xOffset, int yOffset, FrameType type, int pauseTicks)
        {
            PixelX = pixelX;
            Height = pixelHeight;
            Width = pixelWidth;
            Xoffset = xOffset;
            Yoffset = yOffset;
            Type = type;
            PauseTicks = pauseTicks;
        }
    }
}
