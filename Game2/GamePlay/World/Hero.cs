using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private float jump_count = 7f;
        private double lastTimeInSecond;
        private Vector2 heroVelocity;
        public bool collisionWithBrick = false;
        public Rectangle Boots;
        public Rectangle Shoe;
        public Rectangle RightColl;
        public Rectangle LeftColl;
        public bool CollideWithRight = false;
        public bool CollideWithLeft = false;
        public Texture2D currentFrame;
        private int currLeft = 2;
        private int currRight = 0;

        private bool IsMovingRight = false;
        private bool IsMovingLeft = false;
        private double animationTimer;
        private const float animationSpeed = 0.2f;
        private Dictionary<int, Texture2D> animationSprite = new();


        public Hero(string nameTexture, Vector2 Position) : base(nameTexture, Position)
        {
            currentFrame = texture;
            animationSprite = new Dictionary<int, Texture2D>
            {
                {0, Global.content.Load<Texture2D>("Hero/Default")},
                {1, Global.content.Load<Texture2D>("Hero/RunRight") },
                {2, Global.content.Load<Texture2D>("Hero/Run") },
                {3, Global.content.Load<Texture2D>("Hero/RunToLeft") },
                {4, Global.content.Load<Texture2D>("Hero/RunLeft") }
            };
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
            animationTimer += lastTimeInSecond;
            
            MovementHero(gameTime);
            //if (IsMovingLeft && animationTimer > animationSpeed)
            //{
            //    currLeft++;
            //    texture = animationSprite[currLeft];
            //    if (currLeft == 4)
            //        currLeft = 2;
            //    animationTimer = 0;
            //}
            //if (IsMovingRight && animationTimer > animationSpeed)
            //{
            //    currRight++;
            //    texture = animationSprite[currRight];
            //    if (currRight == 2)
            //        currRight = 0;
            //    animationTimer = 0;
            //}
            //else if(!IsMovingRight && !IsMovingLeft)
            //    texture = animationSprite[0];

            base.Update(gameTime);
        }
        public void MovementHero(GameTime gameTime)
        {
            heroVelocity = direction * speed * (float)lastTimeInSecond;

            if (Global.myKeyboard.GetPress("A") && position.X > 0 && !CollideWithLeft)
            {
                position -= heroVelocity;
                IsMovingLeft = true;
                if(animationTimer > animationSpeed)
                {
                    currLeft++;
                    texture = animationSprite[currLeft];
                    if (currLeft == 4)
                        currLeft = 2;
                    animationTimer = 0;
                }
            }
            else if (Global.myKeyboard.GetPress("D") && position.X < Game1.ScreenWidth - texture.Width / 2 && !CollideWithRight)
            {
                position += heroVelocity;
                IsMovingRight = true;
                if(animationTimer > animationSpeed)
                {
                    currRight++;
                    texture = animationSprite[currRight];
                    if (currRight == 2)
                        currRight = 0;
                    animationTimer = 0;
                }
            }
            else
            {
                texture = animationSprite[0];
                CollideWithLeft = false;
                CollideWithRight = false;
                IsMovingLeft = false;
                IsMovingRight = false;
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
        public override void Draw()
        {
            base.Draw();
        }
    }
}
