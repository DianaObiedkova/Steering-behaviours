using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Steering_behaviours.Models
{
    public abstract class Creature
    {
        private static int IDcounter = 0;
        public int ID { get; set; }
        public Vector3 Position { get; set; }
        public int Health { get; private set; }
        public float Weight { get; private set; }
        public Color Color { get; set; }
        public float MaxSpeed { get; private set; }

        public Creature(int health, float weight, Color color, Vector3 position, float maxSpeed)
        {
            Health = health; Weight = weight; Color = color; Position = position; MaxSpeed = maxSpeed;
            ID = IDcounter;
            IDcounter++;
        }
        public bool Injure(int harm)
        {
            Health -= harm;
            return Health > 0;
        }

        public abstract void Update();
        
    }
}
