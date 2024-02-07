using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Engine.Maths
{
    public class GameMath
    {
        public static float Lerp(float current, float target, float lerpFactor = 0.1f)
        {
            return current + (target - current) * lerpFactor;
        }

        public static Vector2<float> Lerp(Vector2<float> current, Vector2<float> target, float lerpFactor = 0.1f)
        {
            float x = Lerp(current.X, target.X, lerpFactor);
            float y = Lerp(current.Y, target.Y, lerpFactor);

            return new Vector2<float>(x, y);
        }

        public static int GetMajorityValue(List<int> values)
        {
            if (values == null || values.Count == 0)
            {
                return 0; // or another default value
            }

            var majorityValue = values
                .GroupBy(size => size)
                .OrderByDescending(group => group.Count())
                .First()
                .Key;

            return majorityValue;
        }

        public static float GetMajorityValueF(List<float> values)
        {
            if (values == null || values.Count == 0)
            {
                return 0.0f; // or another default value
            }

            var majorityValue = values
                .GroupBy(size => size)
                .OrderByDescending(group => group.Count())
                .First()
                .Key;

            return majorityValue;
        }
    }
}
