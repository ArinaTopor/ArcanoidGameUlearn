using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    public abstract class Draw2D
    {
        public Vector2 position, dims, frameSize;
        public Texture2D texture;
        public float speed;
        public Vector2 direction;
        public Rectangle scope;
        public Color color = Color.White;
        
        public Draw2D(string nameTexture, Vector2 Position)
        {
            texture = Global.content.Load<Texture2D>(nameTexture);
            position = Position;
            dims = new Vector2(texture.Width, texture.Height);
            speed = 0;
            scope = new Rectangle((int)(position.X), (int)position.Y, (int)dims.X, (int)dims.Y);
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw()
        {
            if (texture != null)
                Global.spriteBatch.Draw(texture, new Rectangle(position.ToPoint(), dims.ToPoint()),
                    null, color, 0f, new Vector2(0, 0), new SpriteEffects(), 0); // 0 - глубина слоя
        }
    }
}
