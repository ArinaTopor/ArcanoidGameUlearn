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
        private double elapsedTime = 0;
        private bool IsHeroPushBall;
        private readonly float accelarationRate = 1f;

        
        public Ball(string nameTexture, Vector2 Position) : base(nameTexture, Position)
        {
            IsHeroPushBall = false;           
            speed = 150f;
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
            elapsedTime = gameTime.ElapsedGameTime.TotalSeconds;
           
            HitWithHero(World.hero);
            BoundsMovement();
            position += direction * (float)elapsedTime * speed;
            base.Update(gameTime);
        }
        private void BoundsMovement()
        {
            if (position.X <= 0 || position.X >= Game1.ScreenWidth - texture.Width)
            {
                direction.X *= -accelarationRate;
            }

            else if (position.Y <= 0)
            {
                direction.Y *= -accelarationRate;
            }
            scope.Location = position.ToPoint();

        }
        public void HitWithHero(Hero hero)
        {
            scope.Location = position.ToPoint();
            if (scope.Intersects(hero.scope))
            {
                if (!IsHeroPushBall)
                {
                    Start();
                    IsHeroPushBall = true;
                }
                direction.Y *= -accelarationRate;
            }
        }     

        public void CollisionBrick(Brick brick)
        {
            if (scope.Intersects(brick.scope))
            {
                direction.Y *= -accelarationRate;
            }
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
