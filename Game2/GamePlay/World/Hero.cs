using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    public class Hero : Draw2D
    {
        public bool isJump = false;
        public float jump_count = 7f;
        private double lastTimeInSecond;
        private Vector2 heroVelocity;
        public bool collisionWithBrick = false;
        public Rectangle Boots;
        public Rectangle Shoe;
        public Rectangle RightColl;
        public Rectangle LeftColl;
        public bool CollideWithRight = false;
        public bool CollideWithLeft = false;


        public Hero(string nameTexture, Vector2 Position) : base(nameTexture, Position)
        {
            speed = 100f;
            direction = new Vector2(1, 0);
        }
            

        public override void Update(GameTime gameTime)
        {
            Boots = new Rectangle(scope.Location.X + 10, scope.Location.Y + texture.Height - 10, texture.Width - 20, 9);
            Shoe = new Rectangle(scope.Location.X, scope.Location.Y + texture.Height - 10, texture.Width, 11);
            LeftColl = new Rectangle(scope.Location.X, scope.Location.Y, 10, scope.Height);
            RightColl = new Rectangle(scope.Location.X + scope.Width - 10, scope.Location.Y, 10, scope.Height);
            lastTimeInSecond = gameTime.ElapsedGameTime.TotalSeconds;
            
            MovementHero(gameTime);
            
            base.Update(gameTime);
        }
        public void MovementHero(GameTime gameTime)
        {
            heroVelocity = direction * speed * (float)lastTimeInSecond;

            if (Global.myKeyboard.GetPress("A") && position.X > 0 && !CollideWithLeft)
            {
                position -= heroVelocity;
            }
            else if (Global.myKeyboard.GetPress("D") && position.X < Game1.ScreenWidth - texture.Width / 2 && !CollideWithRight)
            {
                position += heroVelocity;
            }
            else
            {
                CollideWithLeft = false;
                CollideWithRight = false;
            }
            if (!isJump)
            {
                if (Global.myKeyboard.GetPress("W") || Global.myKeyboard.GetPress("Space"))
                    isJump = true;
            }
            else
            {
                //переписать прыжок 
                if (jump_count >= -7)
                {
                    if (jump_count > 0)
                        position = new Vector2(position.X, position.Y - (jump_count * jump_count / 2));

                    else
                    {
                        position = new Vector2(position.X, position.Y + (jump_count * jump_count / 2));
                    }
                    jump_count--;
                }
                else
                {
                    isJump = false;
                    jump_count = 7;
                }
            }
            scope.Location = position.ToPoint();
        }
        //public void CollisionWithBrick()
        //{
        //    var bricks = World.bricks;
        //    foreach (var brick in bricks)
        //    {
        //        if (scope.Intersects(brick.scope))
        //        {
        //            if (!isJump && scope.Bottom == brick.scope.Top)
        //            {
        //                position.Y += 10;
        //                position.Y = position.Y > Game1.ScreenHeight - texture.Height ? position.Y - texture.Height : position.Y;
        //            }
        //            else if (scope.Right == brick.scope.Left || scope.Left == brick.scope.Right)
        //            {
        //                collisionWithBrick = true;
        //            }
        //        }
        //    }
        //}
        public override void Draw()
        {
            base.Draw();
        }
    }
}
