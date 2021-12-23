using Steering_behaviours.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Steering_behaviours.Models.Behaviours
{
    public class Wander : DesiredVelocityProvider
    {
        private readonly float circleDistance = 1;
        private readonly float circleRadius = 2;
        private readonly int angleChangeStep = 15;
        private int angle = 0;
        public Wander(Vector3 position) : base(position) { }
        public override Vector3 GetDesiredVelocity(Animal an)
        {
            angle += Animal.ran.Next(0, 2) < 1 ? angleChangeStep : -angleChangeStep;
            var futurePosition = an.Position.Add(an.Velocity.Normalize().Mult(circleDistance));
            var vector = new Vector3((float)Math.Cos(angle * Math.PI / 180), 0, (float)Math.Sin(angle * Math.PI / 180)*circleRadius);
            return futurePosition.Add(vector).Sub(an.Position).Normalize().Mult(an.VelocityLimit);
        }
    }
}
