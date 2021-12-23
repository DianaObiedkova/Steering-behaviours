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
        private int bullets = 20;
        private readonly int harm;
        private readonly int distance;

        public Gun(int bullets, int distance, int harm)
        {
            this.bullets = bullets;
            this.distance = distance;
            this.harm = harm;
        }

        public Bullet Shot(Vector3 startPosition, Vector3 direction)
        {
            if(bullets>0)
            {
                bullets--;
                return new Bullet(startPosition, direction.Normalize(), distance, harm);
            }
            return default;
        }
    }
}
