using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Engine.Maths
{
    public class Vector2<T>
    {
        public T X;
        public T Y;

        public Vector2(T x, T y)
        {
            this.X = x;
            this.Y = y;
        }

        public SKPoint ToSKPoint()
        {
            float floatX = Convert.ToSingle(X);
            float floatY = Convert.ToSingle(Y);

            return new SKPoint(floatX, floatY);
        }
        public SKSize ToSKSize()
        {
            float sizeX = Convert.ToSingle(X);
            float sizeY = Convert.ToSingle(Y);

            return new SKSize(sizeX, sizeY);
        }

        public override string ToString()
        {
            float floatX = Convert.ToSingle(X);
            float floatY = Convert.ToSingle(Y);

            return $"({Math.Round(floatX, 2)}, {Math.Round(floatY, 2)})";
        }

        public Vector2<T> Copy()
        {
            return new Vector2<T>(X, Y);
        }
    }
}
