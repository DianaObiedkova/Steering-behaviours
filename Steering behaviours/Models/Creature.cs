using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Steering_behaviours.Models
{
    public abstract class Creature
    {
        protected Position Position { get; set; }
        public int Health { get; private set; }
        public double Weight { get; private set; }
        public Color Color { get; set; }
        public double MaxSpeed{get;private set;}

        public bool Injure(int harm)
        {
            Health -= harm;
            return Health > 0;
        }

        public abstract void Update();
        
    }
}
