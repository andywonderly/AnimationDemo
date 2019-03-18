using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformPractice
{
    class Idle
    {
        public Texture2D Texture { get; set; }
        public Rectangle Hitbox { get; set; }
        public List<IdleFrame> Frames { get; set; }

        public Idle(Texture2D texture)
        {
            Texture = texture;
            Frames = LoadFrames();
        }

        public static List<IdleFrame> LoadFrames()
        {
            var list = new List<IdleFrame>();
            var pauseTicks = 2;
            list.Add(new PlatformPractice.IdleFrame(0, 54, 0, pauseTicks));
            list.Add(new PlatformPractice.IdleFrame(68, 52, 0, pauseTicks));
            list.Add(new PlatformPractice.IdleFrame(128, 53, 0, pauseTicks));
            list.Add(new PlatformPractice.IdleFrame(197, 52, 0, pauseTicks));

            return list;

        }
    }
}
