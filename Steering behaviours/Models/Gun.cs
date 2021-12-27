using Steering_behaviours.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Steering_behaviours.Models
{
    public class Gun
    {
        private readonly int harm;
        private readonly int distance;
        public int Bullets { get; private set; } = 20;

        public Gun(int distance, int harm)
        {
            this.distance = distance;
            this.harm = harm;
        }

        public Bullet Shot(Vector3 startPosition, Vector3 direction)
        {
            if(Bullets>0)
            {
                Bullets--;
                return new Bullet(startPosition, direction.Normalize(), distance, harm);
            }
            return default;
        }
    }
}
