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
        public bool collisionWithBrick = false;
        public Rectangle RightColl;
        public Rectangle LeftColl;
        public Rectangle Shoe;
        public bool CollideWithRight = false;
        public bool CollideWithLeft = false;
        public Texture2D currentFrame;
        private float jump_count = 7f;
        private double lastTimeInSecond;
        private Vector2 heroVelocity;    
        private int currLeft = 2;
        private int currRight = 0;
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
            LeftColl = new Rectangle(scope.Location.X, scope.Location.Y, 10, texture.Height - 50);
            RightColl = new Rectangle(scope.Location.X + scope.Width - 10, scope.Location.Y, 10, texture.Height - 50);
            Shoe = new Rectangle(scope.Location.X + 10, scope.Location.Y + texture.Height - 10, texture.Width - 20, 10);
            lastTimeInSecond = gameTime.ElapsedGameTime.TotalSeconds;
            animationTimer += lastTimeInSecond;           
            MovementHero(gameTime);
            base.Update(gameTime);
        }

        public void MovementHero(GameTime gameTime)
        {
            heroVelocity = direction * speed * (float)lastTimeInSecond;

            if (MyKeyboard.GetPress("A") && position.X > 0 && !CollideWithLeft)
            {
                position -= heroVelocity;
                if(animationTimer > animationSpeed)
                {
                    currLeft++;
                    texture = animationSprite[currLeft];
                    if (currLeft == 4)
                        currLeft = 2;
                    animationTimer = 0;
                }
            }

            else if (MyKeyboard.GetPress("D") && position.X < Game1.ScreenWidth - texture.Width / 2 && !CollideWithRight)
            {
                position += heroVelocity;
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
            }

            if (!isJump)
            {
                if (MyKeyboard.GetPress("W") || MyKeyboard.GetPress("Space"))
                    isJump = true;
            }

            else
            {
                if (jump_count >= -7)
                {
                    if (jump_count > 0)
                        position.Y -=(jump_count * jump_count / 2);

                    else
                    {
                        position.Y +=  (jump_count * jump_count / 2);
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
