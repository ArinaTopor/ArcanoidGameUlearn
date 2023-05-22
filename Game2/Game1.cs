
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static int ScreenWidth = 1000;
        public static int ScreenHeight = 600;
        World world;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
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

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime) // вся игровая логика обновляется здесь
        {
            
            Global.myKeyboard.Update();
            world.Update(gameTime);
            Global.myKeyboard.UpdateOld();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) // поток рисования
        {
            GraphicsDevice.Clear(Color.LightGreen);
            Global.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);           
            world.Draw();
            Global.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}