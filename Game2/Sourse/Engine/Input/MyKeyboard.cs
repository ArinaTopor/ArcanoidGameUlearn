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
        public KeyboardState newKeyboard, oldKeyboard;
        public List<MyKey> pressedKeys = new List<MyKey>(), previousPressedKeys = new List<MyKey>();
        public MyKeyboard()
        {

        }
        public virtual void Update()
        {
            newKeyboard = Keyboard.GetState();
            GetPressedKeys();
        }

        public void UpdateOld()
        {
            oldKeyboard = newKeyboard;
            previousPressedKeys = new List<MyKey>();
            for(int i = 0; i < pressedKeys.Count; i++)
                previousPressedKeys.Add(pressedKeys[i]);
        }
        public bool GetPress(string Key)
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
            var found = false;
            pressedKeys.Clear();
            for(int i = 0; i < newKeyboard.GetPressedKeys().Length; i++) // проверяем наличие каждой нажатой клавиши
            {
                pressedKeys.Add(new MyKey(newKeyboard.GetPressedKeys()[i].ToString(), 1));
            }

        }

    }
}
