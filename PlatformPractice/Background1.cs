using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformPractice
{
    class Background1
    {
        public Texture2D Bg1 { get; set; }
        public Texture2D Bg2 { get; set; }
        //public Rectangle SourceRectangle { get; set; }

        public Background1(Texture2D background1, Texture2D background2, Player player)
        {
            Bg1 = background1;
            Bg2 = background2;
            //SourceRectangle = new Rectangle(0, 0, 800, 480);
            //Run an initial update
            //Update(player);
        }

        public void Draw(SpriteBatch spritebatch, Point camera, Point bg2camera, Camera2D _camera)
        {
            //var sourceRectangle = new Rectangle(SourceRectangle.X - camera.X, SourceRectangle.Y - camera.Y, 800, 480);
            var bg1source = new Rectangle(camera.X, camera.Y, 800, 480);
            var bg2source = new Rectangle(bg2camera.X, bg2camera.Y, 800, 480);
            var destinationRectangle = new Rectangle(0, 0, 800, 480);

            var transformMatrix = _camera.GetViewMatrix();
            spritebatch.Begin(transformMatrix: _camera.GetViewMatrix());
            spritebatch.Draw(Bg2, destinationRectangle, bg2source, Color.White);
            spritebatch.Draw(Bg1, destinationRectangle, bg1source, Color.White);
            spritebatch.End();
        }

        //public void Update(Player player)
        //{
        //    var sideBuffer = 60;
        //    var playerLeft = player.X - SourceRectangle.Left;
        //    var playerRight = SourceRectangle.Right - player.X;

        //    var levelWidth = Texture.Width;


        //    //Test for being near the left edge of the screen.
        //    //If the left edge of the screen is reached, check whether
        //    //you are close to the edge of the entire level.
        //    if(playerLeft < sideBuffer)
        //    {
        //        //Frame.X -= pc;
        //        var frameX = SourceRectangle.X;
        //        frameX -= (sideBuffer - playerLeft);

        //        if(frameX < 0)
        //        {
        //            frameX = 0;
        //        }

        //        SourceRectangle = new Rectangle(frameX, SourceRectangle.Y, SourceRectangle.Width, SourceRectangle.Height); 
        //    }
        //    else if(playerRight < 60)
        //    {
        //        var frameX = SourceRectangle.X;
        //        frameX += (playerRight - sideBuffer);

        //        if(frameX > (Texture.Width - SourceRectangle.Width))
        //        {
        //            frameX = Texture.Width - SourceRectangle.Width;
        //        }

        //        SourceRectangle = new Rectangle(frameX, SourceRectangle.Y, SourceRectangle.Width, SourceRectangle.Height);
        //    }
        //}
    }




}
