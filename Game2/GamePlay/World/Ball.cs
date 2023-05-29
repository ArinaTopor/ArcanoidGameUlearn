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
        private float elapsedTime = 0;
        private bool IsHeroPushBall;
        private float accelarationRate = 1f;
        
        public Ball(string nameTexture, Vector2 Position) : base(nameTexture, Position)
        {
            IsHeroPushBall = false;           
            speed = 4f;
            position = Position;
            direction = new Vector2(0, 0);
        }
        public void Start()
        {
            direction = new Vector2(1, -1);
            direction.Normalize();
        }

        public override void Update(GameTime gameTime)
        {                     
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(elapsedTime >= 30 && elapsedTime <= 60)
            {
                accelarationRate = 1.1f;
            }
            if (elapsedTime > 60)
            {
                accelarationRate = 1.2f;
            }
            
            HitWithHero(World.hero);
            BoundsMovement();
            position += direction * speed;

            base.Update(gameTime);
        }
        private void BoundsMovement()
        {
            if (position.X <= 0 || position.X >= Game1.ScreenWidth - texture.Width)
                direction.X *= -accelarationRate;
            if (position.Y <= 0)
                direction.Y *= -accelarationRate;

            scope.Location = position.ToPoint();
        }
        public void HitWithHero(Hero hero)
        {
            scope.Location = position.ToPoint();
            if (scope.Intersects(hero.scope))
            {
                if(!IsHeroPushBall)
                {
                    Start();
                    IsHeroPushBall = true;
                }
                    direction.Y *= -accelarationRate;   
            }
        }
        public void CollisionBrick(Brick brick)
        {
            if(scope.Intersects(brick.scope))
            {
                direction.Y *= -1;
            }
        }
        public override void Draw()
        {
            base.Draw();
        }

    }
}
