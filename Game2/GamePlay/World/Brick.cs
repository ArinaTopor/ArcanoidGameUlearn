using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    public class Brick : Draw2D
    {
        public static Dictionary<int, string> colorsBrick = new() { 
                { 0, "Sprites/BlueBrick" },
                { 1, "Sprites/RedBrick" },
                { 2, "Sprites/GreenBrick"},
                { 3, "Sprites/YellowBrick"}};
        public Brick(string nameTexture, Vector2 Position) : base(nameTexture, Position)
        {
            speed = 0;
        }
        
        public void CollisionWithBrickForJump()
        {
            if (World.hero.Shoe.Intersects(scope))
            {
                World.hero.position.Y = position.Y - World.hero.texture.Height;
            }
        }

        public static void CollisionForMovieWithBrick(Brick b)
        {
            if (AxisCollision.CheckCollision(World.hero.Shoe, b.scope))
            {
                World.intersection = true;
            }
            if (AxisCollision.CheckCollision(World.hero.RightColl, b.scope))
            {
                World.hero.CollideWithRight = true;
                World.hero.position.X = b.position.X - World.hero.scope.Width;
            }
            if (AxisCollision.CheckCollision(World.hero.LeftColl, b.scope))
            {
                World.hero.CollideWithLeft = true;
                World.hero.position.X = b.position.X + b.scope.Width;
            }
        }

        public override void Update(GameTime gameTime)
        {
            CollisionWithBrickForJump();
            base.Update(gameTime);
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
