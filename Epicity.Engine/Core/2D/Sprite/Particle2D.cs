using Werewolf.Engine.Maths;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Engine
{
    public class Particle2D : AnimatedSprite2D
    {
        public Particle2D(List<string> imageNames, float speed = 1, int loopDuration = 1, float scale = 1, string name = "Default", int layer = 0) 
            : base(new Vector2<float>(0, 0), imageNames, speed, scale, name, layer)
        {
            base.PlayOnStart = false;
            base.loopN = loopDuration;
            base.IsVisible = false;
        }

        public void Start(Vector2<float> position)
        {
            base.Position = position;
            
            if (base.IsPlaying) 
                return;

            base.IsVisible = true;
            base.Play(false, true);
        }

        public void Stop()
        {
            base.Stop(true);
        }
    }
}
