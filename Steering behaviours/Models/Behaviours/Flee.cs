using Steering_behaviours.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Steering_behaviours.Models.Behaviours
{
    public class Flee : DesiredVelocityProvider
    {
        public Flee(Vector3 position) : base(position) { }
        public override Vector3 GetDesiredVelocity(Animal an)
        {
            var distance = Position.Sub(an.Position);
            return distance.Magnitude() > an.FleeDistanceLimit ? new Vector3() : distance.Normalize().Mult(-an.VelocityLimit);
        }
    }
}
