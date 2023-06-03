using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    public class MyKey
    {
        public string key, print, display;
        public MyKey(string key, int state)
        {
            this.key = key;
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
