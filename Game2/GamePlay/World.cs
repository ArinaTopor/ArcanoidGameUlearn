using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    public class World
    {
        public Hero hero;
        public Ball ball;
        public World()
        {
            hero = new Hero("Default", new Vector2(100, 300));
            ball = new Ball("Sprites/ball", new Vector2(100, 300 - hero.texture.Height));

        }

        public virtual void Update(GameTime gameTime)
        {
            hero.Update(gameTime);
            ball.Update(gameTime);
            ball.HitSomething(hero);
        }
        public virtual void Draw()
        {
            hero.Draw();
            ball.Draw();
        }
    }
}
