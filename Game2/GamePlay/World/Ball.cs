using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    public class Ball : Draw2D
    {
        public bool Outside;
        public Ball(string nameTexture, Vector2 Position) : base(nameTexture, Position)
        {
            Outside = false;
            speed = 4f;
            position = Position;
            //direction.Normalize();
            direction = new Vector2(0, 0);
            //direction.Normalize(); 
        }
        public override void Update(GameTime gameTime)
        {
            BoundsMovement();
            
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += speed * direction * deltaTime;
            base.Update(gameTime);
        }
        private void BoundsMovement()
        {

            if (position.X <= 0 || position.X >= Game1.ScreenWidth - texture.Width)
            {
                direction.X *= -1;
            }
        }
        //private void StartPosition(Hero hero)
        //{
        //    position.X = hero.position.X + hero.texture.Width / 2 - texture.Width / 2;
           
        //    position.Y = hero.position.Y + texture.Height * 2;
        //    direction = new Vector2(1, -1);
        //}
        public void HitSomething(Hero hero)
        {
            if (this.scope.Intersects(hero.scope))
            {
                direction.Y -= 4f;
                direction.X -= 4f;
            }

        }
        public override void Draw()
        {
            base.Draw();
        }
    }
}
