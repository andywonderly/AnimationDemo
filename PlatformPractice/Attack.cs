using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformPractice
{

    public enum AttackType
    {
        Jab,
        Short,
        PunchUppercut,
        KickOverhead,
        KickUppercut,
    }

    public enum FrameType
    {
        Startup,
        Active,
        Recovery,
    }
    class Attack
    {
        public Texture2D Texture { get; set; }
        public Rectangle Hitbox { get; set; }
        //public List<AnimationFrame> Frames { get; set; }
        public int FrameCounter { get; set; }
        public int TickCounter { get; set; }

        public Attack(Texture2D texture)
        {
            Texture = texture;
            FrameCounter = 0;
            TickCounter = 0;

        }

        //public static List<AnimationFrame> LoadFrames(AttackType type)
        //{


        //    switch (type)
        //    {
        //        case AttackType.Jab:
        //            return Jab();
        //            break;
        //        case AttackType.Short:
        //            return Short();
        //            break;
        //        case AttackType.PunchUppercut:
        //            return PunchUppercut();
        //            break;
        //        case AttackType.KickOverhead:
        //            return KickOverhead();
        //            break;
        //        default:
        //        case AttackType.KickUppercut:
        //            return KickUppercut();
        //            break;
        //    }
        //}


        public static List<AnimationFrame> Short()
        {
            var frames = new List<AnimationFrame>();


            return frames;

        }

        public static List<AnimationFrame> PunchUppercut()
        {
            var frames = new List<AnimationFrame>();


            return frames;

        }

        public static List<AnimationFrame> KickOverhead()
        {
            var frames = new List<AnimationFrame>();


            return frames;

        }

        public static List<AnimationFrame> KickUppercut()
        {
            var frames = new List<AnimationFrame>();


            return frames;

        }
    }


}
