using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steering_behaviours.Models
{
    public class Position
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Position()
        {

        }

        public Position(float x, float y)
        {
            X = x; Y = y;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Position p = (Position)obj;
                return (X == p.X) && (Y == p.Y);
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
