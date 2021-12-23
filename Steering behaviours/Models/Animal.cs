using Steering_behaviours.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Steering_behaviours.Models
{
    public abstract class Animal : Creature
    {
        private const float Epsilon = 0.05f;
        public long Time { get; private set; }
        public float VelocityLimit { get; set; }
        public float SteeringForceLimit { get; set; }
        public float FleeDistanceLimit { get; private set; }
        public float MinFleeDistance { get; private set; }
        public Vector3 Velocity { get; set; }
        public Vector3 Acceleration { get; private set; }

        public static Random ran = new Random();

        public Animal(int health, float weight, Color color, Vector3 position, float maxSpeed, float minVelocityLimit, 
            float steeringForceLimit) :
            base(health, weight, color, position, maxSpeed)
        {
            VelocityLimit = minVelocityLimit;
            SteeringForceLimit = steeringForceLimit;

            Time = GetMils();
        }
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
            double delta = (GetMils() - Time) * 0.01;
            Time = GetMils();

            Velocity.Add(Acceleration.Mult((float)delta));

            if (Velocity.Magnitude() > MaxSpeed)
            {
                Velocity.SetMagnitude(MaxSpeed);
            }
            else if(Velocity.Magnitude() < Epsilon)
            {
                Velocity = new Vector3(0);
                return;
            }

            Acceleration = new Vector3(0);
            Position.Add(Velocity.Mult((float)delta));
            //todo: !!
            //transform.rotation = Quaternion.LookRotation(velocity);
        }

        private void ApplySteeringForce()
        {
            var providers = GetProviders();
            var steering = new Vector3(0);

            foreach(var item in providers)
            {
                var desiredVelocity = item.GetDesiredVelocity(this);
                if (desiredVelocity != default)
                {
                    steering.Add(desiredVelocity.Sub(Velocity));
                }
            }

            steering.Sub(Velocity);

            SetMarnitudeIfLargerMax(steering);

            ApplyForce(steering);
        }

        private void ApplyFriction()
        {
            var friction = Velocity.Mult(-1).Normalize().Mult((float)0.5);
            ApplyForce(friction);                
        }

        private long GetMils() => DateTimeOffset.Now.ToUnixTimeMilliseconds();
        protected abstract List<DesiredVelocityProvider> GetProviders();

        public void SetMarnitudeIfLargerMax(Vector3 vect)
        {
            if (vect.Magnitude() > SteeringForceLimit)
                vect.SetMagnitude(SteeringForceLimit);
        }
    }

}
