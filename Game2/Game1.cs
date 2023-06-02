
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public static readonly int ScreenWidth = 1000;
        public static readonly int ScreenHeight = 600;
        World world;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent() 
        {
            Global.content = this.Content;
            Global.spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.myKeyboard = new MyKeyboard();
            world = new World();
        }

        protected override void Update(GameTime gameTime)
        {           
            Global.myKeyboard.Update();
            world.Update(gameTime);
            MyKeyboard.UpdateOld();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGreen);
            Global.spriteBatch.Begin();           
            world.Draw();
            Global.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}