using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game2
{
    public class World
    {
        public List<Brick> bricks = new();
        public Hero hero;
        public Ball ball1;
        public Ball ball2;
        public Ball ball3;

        public World()
        {
            Start();
            hero = new Hero("Default", new Vector2(Game1.ScreenWidth / 4, Game1.ScreenHeight));
            hero.position = new Vector2(Game1.ScreenWidth / 4, Game1.ScreenHeight - hero.texture.Height / 2 -bricks[0].texture.Height - 4);
            ball1 = new Ball("Sprites/ball", new Vector2(Game1.ScreenWidth / 4 - hero.texture.Width*2, Game1.ScreenHeight - hero.texture.Height * 2f));
            ball2 = new Ball("Sprites/ball", new Vector2(Game1.ScreenWidth / 4, Game1.ScreenHeight - hero.texture.Height * 2f));
            ball3 = new Ball("Sprites/ball", new Vector2(Game1.ScreenWidth / 4 + hero.texture.Width*2, Game1.ScreenHeight - hero.texture.Height * 2f));

        }

        public virtual void Update(GameTime gameTime)
        {
            hero.Update(gameTime);
            ball1.HitWithHero(hero);
            ball1.Update(gameTime);
            ball2.HitWithHero(hero);
            ball2.Update(gameTime);
            ball3.HitWithHero(hero);
            ball3.Update(gameTime);
            foreach (var b in bricks)
            {
                b.Update(gameTime);
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
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    bricks.Add(new Brick("Sprites/Brick2", 
                        new Vector2(i*80+(i + Game1.ScreenWidth/1.8f), (j*40)+(j + 13)*2)));
                }
            }
            for (int i = 0; i < Game1.ScreenWidth / bricks[0].texture.Width +2; i++)
            {
                bricks.Add(new Brick("Sprites/Brick2",
                    new Vector2(i * 80 + (i + 20) * 2, (13 * 40) + (13 + 15) * 2)));
            }

        }
        //public void CollisionBrickAndBall(GameTime gameTime)
        //{
        //    foreach(var b in bricks)
        //    {
        //        b.Update(gameTime);
        //        for (int  i = 0; i < bricks.Count; i++)
        //        {
        //            var brick = bricks[i];
        //            if(ball1.scope.Intersects(brick.scope))
        //            {
        //                bricks.RemoveAt(i);

        //            }
        //        }

        //    }
        //}
    }
}
