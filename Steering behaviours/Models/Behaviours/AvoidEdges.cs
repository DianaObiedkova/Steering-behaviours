using Steering_behaviours.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Steering_behaviours.Models.Behaviours
{
    public class AvoidEdges : DesiredVelocityProvider
    {
        public AvoidEdges(Vector3 position) : base(position) { }
        public override Vector3 GetDesiredVelocity(Animal an)
        {
            var avoidDistance = 75;
            var distance = Position.Sub(an.Position);

            if(an.Position.X>0 && an.Position.Y>0 && an.Position.X<750 && an.Position.Y<500)
                return distance.Magnitude() > avoidDistance ? new Vector3() : distance.Normalize().Mult(-an.VelocityLimit);
            else {
                if(an.Position.X<0)
                    an.UpdatePosition(new Vector3(an.Position.X-an.Position.X, an.Position.Y, 0));
                if(an.Position.Y<0)
                    an.UpdatePosition(new Vector3(an.Position.X, an.Position.Y-an.Position.Y, 0));
                if(an.Position.X>750)
                    an.UpdatePosition(new Vector3(an.Position.X-(an.Position.X-750), an.Position.Y, 0));
                if(an.Position.Y>500)
                    an.UpdatePosition(new Vector3(an.Position.X, an.Position.Y-(an.Position.Y-500), 0));
                an.UpdatePosition(new Vector3( ));
                return distance.Normalize().Mult(-an.VelocityLimit);
            }
        }
    }
}
