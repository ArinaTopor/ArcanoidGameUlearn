using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Game2.Ball;

namespace Game2
{
    public class Brick : Draw2D
    {
        public Brick(string nameTexture, Vector2 Position) : base(nameTexture, Position)
        {
            speed = 0;
        }
        //public bool BallCollision(Ball ball)
        //{
        //    if(ball.scope.Intersects(scope))
        //    {

        //    }
        //}
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw()
        {
            base.Draw();
        }


    }
}
