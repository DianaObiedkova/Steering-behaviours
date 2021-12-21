using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steering_behaviours.Models
{
    public abstract class Animal: Creature
    {
        private const float Epsilon = 0.05f;
        public long Time { get; private set; }
        private float velocityLimit = 3;
        private float steeringForceLimit = 5;
        public override void Update()
        {
            ApplyFriction();
            ApplySteeringForce();
            ApplyForces();

        }

        private void ApplyForces()
        {
            //todo: implemenation
        }

        private void ApplySteeringForce()
        {
            //todo: implemenation
        }

        private void ApplyFriction()
        {
            //todo: implemenation
        }
    }

}
