using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    public class MyKey
    {
        public int state;
        public string key, print, display;
        public MyKey(string key, int state)
        {
            this.state = state;
            this.key = key;
        }
        public virtual void Update()
        {
            state = 2;
        }
        public void MakePrint(string Key)
        {
            display = Key;
            string tempStr = "";
            if (Key == "A" || Key == "S" || Key == "D" || Key == "W")
                tempStr = Key;
            if (Key == "Space")
                tempStr = " ";
            print = tempStr;
        }
    }
}
