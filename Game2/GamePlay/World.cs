using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game2
{
    public class World
    {
        public static List<Brick> bricks = new();
        public static Hero hero;
        public static bool intersection = false;
        private static Ball[] balls;
        private readonly Song song;

        public World()
        {
            Start();
            hero = new Hero("Hero/Default", new Vector2(Game1.ScreenWidth / 4, Game1.ScreenHeight));        
            balls = new Ball[] {
                new Ball("Sprites/SmallBall", new Vector2(Game1.ScreenWidth / 4 - hero.texture.Width * 2, Game1.ScreenHeight - hero.texture.Height * 2f)),
                new Ball("Sprites/MiddleBall", new Vector2(Game1.ScreenWidth / 4, Game1.ScreenHeight - hero.texture.Height * 2f)),
                new Ball("Sprites/ball", new Vector2(Game1.ScreenWidth / 4 + hero.texture.Width * 2, Game1.ScreenHeight - hero.texture.Height * 2f))
            };
            song = Global.content.Load<Song>("Audio/Removal");
            MediaPlayer.Volume = 0.1f;
        }

        public virtual void Update(GameTime gameTime)
        {
            hero.Update(gameTime);
            foreach (var ball in balls)
                ball.Update(gameTime);

            foreach (var b in bricks)
            {
                b.Update(gameTime);
                Brick.CollisionForMovieWithBrick(b);
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

            CollisionBallWithBrick();           
        }

        public void CollisionBallWithBrick()
        {
            for (int i = 0; i < bricks.Count; i++)
            {
                foreach (var ball in balls)
                {
                    var brick = bricks[i];
                    if (ball.scope.Intersects(brick.scope))
                    {
                        bricks.RemoveAt(i);
                        ball.CollisionBrick(brick);
                        MediaPlayer.Play(song);
                        i--;
                        break;
                    }
                }
            }
        }
        public virtual void Draw()
        {
            hero.Draw();

            foreach (var ball in balls)
                ball.Draw();

            foreach (Brick brick in bricks)
                brick.Draw();
        }
        public static void Start()
        {
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    bricks.Add(new Brick(Brick.colorsBrick[i % Brick.colorsBrick.Count],
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
