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
        public bool IsHeroPushBall;
        public float interpol = 0.1f;
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
            
            
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //if (!IsHeroPushBall)
            //{
            //    IsHeroPushBall = true;
            //}

            //if (IsHeroPushBall)
            //{
            //   // direction = new Vector2(-direction.X, -direction.Y);
            //    if (direction.X == 0)
            //        Start();
            //    //position += speed * direction * deltaTime;
            //    //position = Vector2.Lerp(position, position + direction, interpol);
            //}

            BoundsMovement();
            
            base.Update(gameTime);
        }
        private void BoundsMovement()
        {
            if (position.X <= 0 || position.X >= Game1.ScreenWidth - texture.Width)
                direction.X *= -1;
            if (position.Y <= 0)
                direction.Y *= -1;


            //if (position.X + direction.X < 0
            //     || position.X + texture.Width >= Game1.ScreenWidth)
            //{
            //    direction = new Vector2(-direction.X, direction.Y);

            //}
            //if (position.Y + texture.Height / 10 >= 0)
            //{

            //    direction = new Vector2(direction.X, -direction.Y);
            //}
            //if (position.Y + texture.Height / 2 >= Game1.ScreenHeight)
            //{
            //    // Если мяч достиг нижней границы окна, то удаляем его
            //    // из игры
            //    //direction.Y *= -1;
            //    position = new Vector2(this.position.X, Game1.ScreenHeight + 100);
            //}

            scope.Location = position.ToPoint();
        }
        //private void StartPosition(Hero hero)
        //{
        //    position.X = hero.position.X + hero.texture.Width / 2 - texture.Width / 2;

        //    position.Y = hero.position.Y + texture.Height * 2;
        //    direction = new Vector2(1, -1);
        //}
        public void HitWithHero(Hero hero)
        {
            scope.Location = position.ToPoint();
            if (scope.Intersects(hero.scope))
            {
                //if(scope.Center.X <= hero.position.X + 2 *  hero.texture.Width / 3)
                //{
                //    direction = new Vector2(-direction.X, direction.Y);
                //}
                //else if(scope.Center.X >= hero.position.X + hero.texture.Width / 3)
                //    direction = new Vector2(-direction.X, direction.Y);
                //else
                //{
                if(!IsHeroPushBall)
                {
                    Start();
                    IsHeroPushBall = true;
                }
                    direction.Y *= -1;
                    //direction.Normalize();
                //}
               


                
            }
            //scope.Location = position.ToPoint();
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
