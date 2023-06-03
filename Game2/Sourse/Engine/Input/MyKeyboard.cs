using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    public class MyKeyboard
    {
        private static KeyboardState newKeyboard;
        private static readonly List<MyKey> pressedKeys = new();
        private static readonly List<MyKey> previousPressedKeys = new();

        public virtual void Update()
        {
            newKeyboard = Keyboard.GetState();
            GetPressedKeys();
        }

        public static void UpdateOld()
        {
            for(int i = 0; i < pressedKeys.Count; i++)
                previousPressedKeys.Add(pressedKeys[i]);
        }
        public static bool GetPress(string Key)
        {
            for(int i = 0; i < pressedKeys.Count; i++)
            {
                if (pressedKeys[i].key == Key)
                    return true;
            }
            return false;
        }

        public virtual void GetPressedKeys()
        {
            pressedKeys.Clear();
            for(int i = 0; i < newKeyboard.GetPressedKeys().Length; i++) // проверяем наличие каждой нажатой клавиши
            {
                pressedKeys.Add(new MyKey(newKeyboard.GetPressedKeys()[i].ToString(), 1));
            }
        }
    }
}
