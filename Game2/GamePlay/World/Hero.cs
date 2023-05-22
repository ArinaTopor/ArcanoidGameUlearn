using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    public class Hero : Draw2D
    {
        float velocity = 3f;
        bool isJump = false;
        float jump_count = 7f;


        public Hero(string nameTexture, Vector2 Position) : base(nameTexture, Position)
        {
        }

        public override void Update(GameTime gameTime)
        {
            MovementHero();
            base.Update(gameTime);
        }
        public void MovementHero()
        {
            if (Global.myKeyboard.GetPress("A") && position.X > this.texture.Width / 2)
            {
                position = new Vector2(position.X - velocity, position.Y);
            }
            else if (Global.myKeyboard.GetPress("D") && position.X < Game1.ScreenWidth - this.texture.Width / 2)
            {
                position = new Vector2(position.X + velocity, position.Y);
            }
            if (!isJump)
            {
                if (Global.myKeyboard.GetPress("W") || Global.myKeyboard.GetPress("Space"))
                    isJump = true;
            }
            else
            {
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
