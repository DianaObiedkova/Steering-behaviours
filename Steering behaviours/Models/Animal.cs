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
        
        public float VelocityLimit { get; set; }
        public float SteeringForceLimit { get; set; }
        public float FleeDistanceLimit { get; private set; }
        public float MinFleeDistance { get; private set; }
        public Vector3 Velocity { get; set; }
        public Vector3 Acceleration { get; private set; }       

        public Animal(int health, float weight, int diameter, Color color, Vector3 position, float maxSpeed, float minVelocityLimit, 
            float fleeDistanceLimit, float minFleeDistance, float steeringForceLimit) :
            base(health, weight,diameter, color, position, maxSpeed)
        {
            VelocityLimit = minVelocityLimit;
            SteeringForceLimit = steeringForceLimit;
            FleeDistanceLimit = fleeDistanceLimit;
            MinFleeDistance = minFleeDistance;
            Velocity = new Vector3(0);
            Acceleration = new Vector3(0);
        }
        private void ApplyForce(Vector3 force)
        {
            force.Divide(Weight);
            Acceleration = Acceleration.Add(force);
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

            Velocity = Velocity.Add(Acceleration.Mult((float)delta));

            if (Velocity.Magnitude() > MaxSpeed)
            {
                Velocity = Velocity.SetMagnitude(MaxSpeed);
            }
            else if(Velocity.Magnitude() < Epsilon)
            {
                Velocity = new Vector3(0);
                return;
            }

            Acceleration = new Vector3(0);
            Position = Position.Add(Velocity.Mult((float)delta));
            Console.WriteLine("ID:"+ID+" X:"+Position.X+" Y:"+Position.Y);
            //todo: !!
            //transform.rotation = Quaternion.LookRotation(velocity);
        }

        private void ApplySteeringForce()
        {
            var providers = GetProviders();
            var steering = new Vector3(0);

            var maxXsteering  = new Vector3(0);
            var maxYsteering  = new Vector3(0);

            foreach(var item in providers)
            {
                var desiredVelocity = item.GetDesiredVelocity(this);
                //if (desiredVelocity.Equals(default))
                if (desiredVelocity.X != 0 || desiredVelocity.Y != 0 || desiredVelocity.Z != 0)
                {
                    if(Math.Abs(desiredVelocity.X) > Math.Abs(maxXsteering.X))
                        maxXsteering = desiredVelocity.Sub(Velocity);
                    if(Math.Abs(desiredVelocity.Y) > Math.Abs(maxYsteering.Y))
                        maxYsteering = desiredVelocity.Sub(Velocity);
                    //steering = steering.Add(desiredVelocity.Sub(Velocity));
                }
            }
            steering = steering.Add(new Vector3(maxXsteering.X, maxYsteering.Y, 0));
            steering = steering.Sub(Velocity);

            SetMarnitudeIfLargerMax(steering);

            ApplyForce(steering);
        }

        private void ApplyFriction()
        {
            var friction = Velocity.Mult(-1).Normalize().Mult((float)0.5);
            ApplyForce(friction);                
        }
        protected abstract List<DesiredVelocityProvider> GetProviders();

        public void SetMarnitudeIfLargerMax(Vector3 vect)
        {
            if (vect.Magnitude() > SteeringForceLimit)
                vect.SetMagnitude(SteeringForceLimit);
        }
    }

}
