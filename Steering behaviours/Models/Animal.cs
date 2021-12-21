using Steering_behaviours.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Steering_behaviours.Models
{
    public abstract class Animal: Creature
    {
        private const float Epsilon = 0.05f;
        public long Time { get; private set; }
        public const float velocityLimit = 3;
        public const float steeringForceLimit = 5;
        public Vector3 Velocity { get; set; }
        public Vector3 Acceleration { get; private set; }

        private void ApplyForce(Vector3 force)
        {
            force.Divide(Weight);
            Acceleration = new Vector3(Acceleration.X + force.X, Acceleration.Y + force.Y, Acceleration.Z + force.Z);
        }
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
            var friction = Velocity.Mult(-1).Normalize().Mult((float)0.5);
            ApplyForce(friction);                
        }
    }

}
