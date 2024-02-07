using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Engine.Maths
{
    public class Vector2i
    {
        public int X,
                   Y;

        public Vector2i(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2<T> ToVec2T<T>()
        {
            return new Vector2<T>(ConvertToType<T>(X), ConvertToType<T>(Y));
        }

        private static T ConvertToType<T>(int value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public Vector2i Copy()
        {
            return new Vector2i(X, Y);
        }
    }
}
