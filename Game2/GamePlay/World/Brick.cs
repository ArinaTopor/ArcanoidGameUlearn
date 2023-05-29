using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    public class Brick : Draw2D
    {
        //public Hero hero = World.hero;
        public Brick(string nameTexture, Vector2 Position) : base(nameTexture, Position)
        {
            speed = 0;
        }
        
        public void CollisionWithBrick()
        {
            if(World.hero.Boots.Intersects(scope))
            {
                World.hero.position.Y = position.Y - World.hero.texture.Height;
            }
            


        }

        public override void Update(GameTime gameTime)
        {
            CollisionWithBrick();
            base.Update(gameTime);
        }
        public override void Draw()
        {
            base.Draw();
        }


    }
}
