using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steering_behaviours.Helpers
{
    public class FrontCreature
    {
        public FrontCreature(int iD, float x, float y)
        {
            ID = iD;
            X = x;
            Y = y;
        }
        public int ID { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
    }
}
