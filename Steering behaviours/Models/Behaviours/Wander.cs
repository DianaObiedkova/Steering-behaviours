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
        private readonly float circleDistance = 5;
        private readonly float circleRadius = 1;
        private readonly int angleChangeStep = 80;
        private int angle = 0;
        public Wander(Vector3 position) : base(position) { }
        public override Vector3 GetDesiredVelocity(Animal an)
        {
            angle += Creature.ran.NextDouble() < 0.5 ? angleChangeStep : -angleChangeStep;
            var futurePosition = an.Position.Add(an.Velocity.Normalize().Mult(circleDistance));
            var vector = new Vector3((float)Math.Cos(angle * Math.PI / 180), 0, (float)Math.Sin(angle * Math.PI / 180)).Mult(circleRadius);
            return futurePosition.Add(vector).Sub(an.Position).Normalize().Mult(an.VelocityLimit);
        }
    }
}
