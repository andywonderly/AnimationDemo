using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System.Collections.Generic;

namespace PlatformPractice
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public enum PlayerState
        {
            IdleLeft,
            IdleRight,
            WalkingRight,
            WalkingLeft,
            JabRight,
            JabLeft,
            UppercutRight,
            UppercutLeft,
            JumpingLeft,
            JumpingRight,
            JumpingUp,
            HitStunLeft,
            HitStunRight,
            KnockdownLeft,
            KnockdownRight,
        }

        public enum EnemyState
        {
            IdleLeft,
            IdleRight,
            WalkingLeft,
            WalkingRight,
            AttackLeft,
            AttackRight,
            HitStun,
        }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameClass game;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;

            //Manual setting for the game logic resolution
            //Does not appear to change anything.
            //graphics.PreferredBackBufferWidth = 800;
            //graphics.PreferredBackBufferHeight = 480; 
            //graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        /// 

        private Camera2D _camera;

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 800, 480);
            _camera = new Camera2D(viewportAdapter);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var sketchTextures = new List<Texture2D>();

            var sketchJabRight = Content.Load<Texture2D>("JabRight");
            sketchJabRight.Name = "JabRight";
            sketchTextures.Add(sketchJabRight);

            var sketchJabLeft = Content.Load<Texture2D>("JabLeft");
            sketchJabLeft.Name = "JabLeft";
            sketchTextures.Add(sketchJabLeft);

            var sketchIdleRight = Content.Load<Texture2D>("IdleRight");
            sketchIdleRight.Name = "IdleRight";
            sketchTextures.Add(sketchIdleRight);

            var sketchIdleLeft = Content.Load<Texture2D>("IdleLeft");
            sketchIdleLeft.Name = "IdleLeft";
            sketchTextures.Add(sketchIdleLeft);

            var sketchWalkRight = Content.Load<Texture2D>("WalkRight");
            sketchWalkRight.Name = "WalkRight";
            sketchTextures.Add(sketchWalkRight);

            var sketchWalkLeft = Content.Load<Texture2D>("WalkLeft");
            sketchWalkLeft.Name = "WalkLeft";
            sketchTextures.Add(sketchWalkLeft);

            var sketchUppercutRight = Content.Load<Texture2D>("UppercutRight");
            sketchUppercutRight.Name = "UppercutRight";
            sketchTextures.Add(sketchUppercutRight);

            var sketchUppercutLeft = Content.Load<Texture2D>("UppercutLeft");
            sketchUppercutLeft.Name = "UppercutLeft";
            sketchTextures.Add(sketchUppercutLeft);

            var sketchTakeHitLeft = Content.Load<Texture2D>("TakeHitLeft");
            sketchTakeHitLeft.Name = "TakeHitLeft";
            sketchTextures.Add(sketchTakeHitLeft);

            var sketchTakeHitRight = Content.Load<Texture2D>("TakeHitRight");
            sketchTakeHitRight.Name = "TakeHitRight";
            sketchTextures.Add(sketchTakeHitRight);

            var sketchKnockdownRight = Content.Load<Texture2D>("KnockdownRight");
            sketchKnockdownRight.Name = "KnockdownRight";
            sketchTextures.Add(sketchKnockdownRight);

            var sketchKnockdownLeft = Content.Load<Texture2D>("KnockdownLeft");
            sketchKnockdownLeft.Name = "KnockdownLeft";
            sketchTextures.Add(sketchKnockdownLeft);

            var sketchTexturesRed = new List<Texture2D>();

            var sketchJabRight_Red = Content.Load<Texture2D>("JabRight_Red");
            sketchJabRight_Red.Name = "JabRight_Red";
            sketchTexturesRed.Add(sketchJabRight_Red);

            var sketchJabLeft_Red = Content.Load<Texture2D>("JabLeft_Red");
            sketchJabLeft_Red.Name = "JabLeft_Red";
            sketchTexturesRed.Add(sketchJabLeft_Red);

            var sketchUppercutRight_Red = Content.Load<Texture2D>("UppercutRight_Red");
            sketchUppercutRight_Red.Name = "UppercutRight_Red";
            sketchTexturesRed.Add(sketchUppercutRight_Red);

            var sketchUppercutLeft_Red = Content.Load<Texture2D>("UppercutLeft_Red");
            sketchUppercutLeft_Red.Name = "UppercutLeft_Red";
            sketchTexturesRed.Add(sketchUppercutLeft_Red);

            var sketchWalkLeft_Red = Content.Load<Texture2D>("WalkLeft_Red");
            sketchWalkLeft_Red.Name = "WalkLeft_Red";
            sketchTexturesRed.Add(sketchWalkLeft_Red);

            var sketchWalkRight_Red = Content.Load<Texture2D>("WalkRight_Red");
            sketchWalkRight_Red.Name = "WalkRight_Red";
            sketchTexturesRed.Add(sketchWalkRight_Red);

            var sketchIdleRight_Red = Content.Load<Texture2D>("IdleRight_Red");
            sketchIdleRight_Red.Name = "IdleRight_Red";
            sketchTexturesRed.Add(sketchIdleRight_Red);

            var sketchIdleLeft_Red = Content.Load<Texture2D>("IdleLeft_Red");
            sketchIdleLeft_Red.Name = "IdleLeft_Red";
            sketchTexturesRed.Add(sketchIdleLeft_Red);

            var sketchKnockdownLeft_Red = Content.Load<Texture2D>("KnockdownLeft_Red");
            sketchKnockdownLeft_Red.Name = "KnockdownLeft_Red";
            sketchTexturesRed.Add(sketchKnockdownLeft_Red);

            var sketchKnockdownRight_Red = Content.Load<Texture2D>("KnockdownRight_Red");
            sketchKnockdownRight_Red.Name = "KnockdownRight_Red";
            sketchTexturesRed.Add(sketchKnockdownRight_Red);

            var sketchTakeHitRight_Red = Content.Load<Texture2D>("TakeHitRight_Red");
            sketchTakeHitRight_Red.Name = "TakeHitRight_Red";
            sketchTexturesRed.Add(sketchTakeHitRight_Red);

            var sketchTakeHitLeft_Red = Content.Load<Texture2D>("TakeHitLeft_Red");
            sketchTakeHitLeft_Red.Name = "TakeHitLeft_Red";
            sketchTexturesRed.Add(sketchTakeHitLeft_Red);




            game = new GameClass(sketchTextures);

            var background1 = Content.Load<Texture2D>("Background1");
            var background2 = Content.Load<Texture2D>("Background2");
            game.SetBackground1(background1, background2);

                        

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            game.KeyboardState = Keyboard.GetState();
            game.GamePadState = GamePad.GetState(PlayerIndex.One);

            game.Update(game.KeyboardState, game.PreviousKeyboardState, game.GamePadState, game.PreviousGamePadState);

            game.PreviousKeyboardState = game.KeyboardState;
            game.PreviousGamePadState = game.GamePadState;

            //game.Background1.Update(game.Player);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var transformMatrix = _camera.GetViewMatrix(); // oder Begin(transformMatrix: _camera.GetViewMatrix)


            // TODO: Add your drawing code here
            game.Background1.Draw(spriteBatch, game.Camera, game.BackgroundCamera, _camera);
            game.Player.CurrentAnimation.Draw(spriteBatch, game.Camera, game.Player.X, game.Player.Y, _camera);

            base.Draw(gameTime);
        }
    }
}
