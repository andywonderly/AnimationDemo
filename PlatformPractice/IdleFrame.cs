using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformPractice
{
    class IdleFrame
    {
        public int PixelX { get; set; }
        public int PixelWidth { get; set; }
        public int Xoffset { get; set; }
        public int PauseTicks { get; set; }

        public IdleFrame(int pixelX, int pixelWidth, int xOffset, int pauseTicks)
        {
            PixelX = pixelX;
            PixelWidth = pixelWidth;
            Xoffset = xOffset;
            PauseTicks = pauseTicks;
        }
    }
}
