using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    public class Draw2D
    {
        public Vector2 position, dims;
        public Texture2D texture;
        public Draw2D(string nameTexture, Vector2 Position)
        {
            texture = Global.content.Load<Texture2D>(nameTexture);
            position = Position;
            dims = new Vector2(texture.Width, texture.Height);
            

        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            if (texture != null)
                Global.spriteBatch.Draw(texture, new Rectangle((int)(position.X), (int)position.Y, (int)dims.X, (int)dims.Y),
                    null, Color.White, 0f, new Vector2(texture.Bounds.Width/2, texture.Bounds.Height/2), new SpriteEffects(), 0); // 0 - гдубина слоя

        }
    }
}
