using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    public class World
    {
        public Hero hero;
        public World()
        {
            hero = new Hero("Default", new Microsoft.Xna.Framework.Vector2(150, 300));
        }

        public virtual void Update()
        {
            hero.Update();
        }
        public virtual void Draw()
        {
            hero.Draw();
        }
    }
}
