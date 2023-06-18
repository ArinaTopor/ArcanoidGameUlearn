using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    public class Ball : Draw2D
    {
        private double deltaTime = 0;
        private bool IsHeroPushBall;
        private readonly float accelarationRate = 1f;
        private float rotationAngle;
        private Vector2 ballPosition;
        private Vector2 ballOrigin;


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
            deltaTime = gameTime.ElapsedGameTime.TotalSeconds;
           
            HitWithHero(World.hero);
            BoundsMovement();
            float rotationSpeed = 0.1f;
            rotationAngle += rotationSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            Matrix rotationMatrix = Matrix.CreateRotationZ(rotationAngle);

            ballPosition = new Vector2(position.X, position.Y);
            ballOrigin = new Vector2(texture.Width / 2, texture.Height / 2); 

            position += direction * (float)deltaTime * speed;
            UpdateScope();
            base.Update(gameTime);
        }
        private void BoundsMovement()
        {
            if (position.X - texture.Width / 2 <= 0 || position.X >= Game1.ScreenWidth - texture.Width / 2)
            {
                direction.X *= -accelarationRate;
            }

            else if (position.Y - texture.Height/2 <= 0)
            {
                direction.Y *= -accelarationRate;
            }
            scope.Location = position.ToPoint();
        }
        public void HitWithHero(Hero hero)
        {
            scope.Location = position.ToPoint();
            if (hero.scope.Intersects(scope))
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
        private void UpdateScope()
        {
            Matrix transformMatrix = Matrix.CreateTranslation(new Vector3(-position, 0)) *
                                Matrix.CreateRotationZ(rotationAngle) *
                                Matrix.CreateTranslation(new Vector3(position, 0));
            scope = CalculateTransformedBounds(transformMatrix, scope);
        }
        private Rectangle CalculateTransformedBounds(Matrix transformMatrix, Rectangle bounds)
        {
            Vector2[] corners = new Vector2[4];
            corners[0] = new Vector2(bounds.Left, bounds.Top);
            corners[1] = new Vector2(bounds.Right, bounds.Top);
            corners[2] = new Vector2(bounds.Right, bounds.Bottom);
            corners[3] = new Vector2(bounds.Left, bounds.Bottom);

            Vector2.Transform(corners, ref transformMatrix, corners);
            float minX = Math.Min(Math.Min(corners[0].X, corners[1].X), Math.Min(corners[2].X, corners[3].X));
            float minY = Math.Min(Math.Min(corners[0].Y, corners[1].Y), Math.Min(corners[2].Y, corners[3].Y));

            Rectangle transformedBounds = new((int)minX, (int)minY, texture.Width - 10, texture.Height - 10);
            return transformedBounds;
        }
    
    public override void Draw()
        {
            Global.spriteBatch.Draw(texture, ballPosition, null, Color.White, rotationAngle, ballOrigin, 1.0f, SpriteEffects.None, 0f);
        }
    }
}
