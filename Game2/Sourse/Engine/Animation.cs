using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    internal class Animation
    {
        public int CurrentFrame { get; set; }
        public int FrameCount { get; private set; }
        public int FrameHeight { get { return Texture.Height; } }
        public float FrameSpeed { get; set; }
        public int FrameWidth { get { return Texture.Width / FrameCount; } }

        public bool isLooping { get; set; }
        public Texture2D Texture { get;private set; }
        public Animation(int frameSpeed, Texture2D texture)
        {
            FrameSpeed = frameSpeed;
            Texture = texture;
            isLooping = true;
            FrameSpeed = 0.2f;
        }
    }
}
