using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game2
{
    public class World
    {
        private bool intersection = false;
        public static List<Brick> bricks = new();
        public static Hero hero;
        public Ball ball1;
        public Ball ball2;
        public Ball ball3;

        public World()
        {
            Start();
            hero = new Hero("Default", new Vector2(Game1.ScreenWidth / 4, Game1.ScreenHeight));
            hero.position = new Vector2(Game1.ScreenWidth / 4, Game1.ScreenHeight - hero.texture.Height / 2 - bricks[0].texture.Height - 100);
            ball1 = new Ball("Sprites/SmallBall", new Vector2(Game1.ScreenWidth / 4 - hero.texture.Width * 2, Game1.ScreenHeight - hero.texture.Height * 2f));
            ball2 = new Ball("Sprites/MiddleBall", new Vector2(Game1.ScreenWidth / 4, Game1.ScreenHeight - hero.texture.Height * 2.5f));
            ball3 = new Ball("Sprites/ball", new Vector2(Game1.ScreenWidth / 4 + hero.texture.Width * 2, Game1.ScreenHeight - hero.texture.Height * 2f));
        }

        public virtual void Update(GameTime gameTime)
        {
            hero.Update(gameTime);
            ball1.Update(gameTime);
            ball2.Update(gameTime);
            ball3.Update(gameTime);
            foreach (var b in bricks)
            {
                b.Update(gameTime);
                if (hero.Shoe.Intersects(b.scope))
                {
                    intersection = true;
                }
                if (b.scope.Intersects(hero.RightColl))
                {
                    hero.CollideWithRight = true;
                }
                if (b.scope.Intersects(hero.LeftColl))
                {
                    hero.CollideWithLeft = true;
                }

                //if (intersection && hero.scope.Bottom == b.scope.Top && hero.isJump)
                //{
                //    hero.position.Y = b.position.Y + b.texture.Height;
                //}
                //else if (intersection && (hero.scope.Right <= b.scope.Left || hero.scope.Left <= b.scope.Right))
                //{
                //    //hero.direction.X = 0;
                //}
            }
            if (!intersection && !hero.isJump)
            {
                hero.position.Y += 5;
                hero.position.Y = hero.position.Y > Game1.ScreenHeight - hero.texture.Height ? Game1.ScreenHeight - hero.texture.Height : hero.position.Y;
            }

            else
            {
                intersection = false;
            }
            for (int i = 0; i < bricks.Count; i++)
            {
                
                var brick = bricks[i];
                if (ball1.scope.Intersects(brick.scope))
                {
                    bricks.RemoveAt(i);
                    ball1.CollisionBrick(brick);

                    i--;
                }
                if (ball2.scope.Intersects(brick.scope))
                {
                    bricks.RemoveAt(i);
                    ball2.CollisionBrick(brick);

                    i--;
                }
                if (ball3.scope.Intersects(brick.scope))
                {
                    bricks.RemoveAt(i);
                    ball3.CollisionBrick(brick);
                    i--;
                }
            }
            //foreach (var b in bricks)
            //{
            //    b.Update(gameTime);
            //}
            //for (int i = 0; i < bricks.Count; i++)
            //{
            //    var brick = bricks[i];
            //    if (ball1.scope.Intersects(brick.scope))
            //    {
            //        bricks.RemoveAt(i);
            //        ball1.CollisionBrick(brick);

            //        i--;
            //    }
            //    if (ball2.scope.Intersects(brick.scope))
            //    {
            //        bricks.RemoveAt(i);
            //        ball2.CollisionBrick(brick);

            //        i--;
            //    }
            //    if (ball3.scope.Intersects(brick.scope))
            //    {
            //        bricks.RemoveAt(i);
            //        ball3.CollisionBrick(brick);
            //        i--;
            //    }
            //}
        }
        public virtual void Draw()
        {
            hero.Draw();
            ball1.Draw();
            ball2.Draw();
            ball3.Draw();
            foreach (Brick brick in bricks)
                brick.Draw();
        }
        public void Start()
        {
            var colorBricks = new Dictionary<int, string>()
            {
                { 0, "Sprites/BlueBrick" },
                { 1, "Sprites/RedBrick" },
                { 2, "Sprites/GreenBrick"},
                { 3, "Sprites/YellowBrick"}


            };
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    bricks.Add(new Brick(colorBricks[i % colorBricks.Count],
                        new Vector2(Game1.ScreenWidth - (i + 1) * 40, (j * 40))));
                }
            }
            for (int i = 0; i < Game1.ScreenWidth / bricks[0].texture.Width + 2; i++)
            {
                bricks.Add(new Brick("Sprites/BlueBrick",
                    new Vector2(i * 40, Game1.ScreenHeight - bricks[0].texture.Height)));
            }
        }
    }
}
