using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Steering_behaviours.Helpers
{
    public  abstract class DesiredVelocityProvider
    {
        private float Weight { get; set; }
        public abstract Vector3 GetDesiredVelocity();
    }
}
