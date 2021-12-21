using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Steering_behaviours.Helpers
{
    public static class VectorHelper
    {

        public static Vector3 Normalize(this Vector3 vector)
        {
            float m = vector.Magnitude();
            if (m != 0 && m != 1)
            {
                return vector.Divide(m);
            }

            return vector;
        }

        public static float Magnitude(this Vector3 vect)
        {
            return (float)Math.Sqrt(vect.X * vect.X + vect.Y * vect.Y + vect.Z * vect.Z);
        }

        public static Vector3 SetMagnitude(this Vector3 vect, float len)
        {
            return vect.Normalize().Mult(len);
        }

        public static Vector3 Divide(this Vector3 vect, float divider)
        {
            return new Vector3(vect.X / divider, vect.Y/divider, vect.Z / divider);
        }

        public static Vector3 Mult(this Vector3 vect, float mult)
        {
            return new Vector3(vect.X * mult, vect.Y * mult, vect.Z * mult);
        }

        public static Vector3 Add(this Vector3 vect, Vector3 vect2)
        {
            return new Vector3(vect.X + vect2.X, vect.Y + vect2.Y, vect.Z + vect2.Z);
        }
    }
}
