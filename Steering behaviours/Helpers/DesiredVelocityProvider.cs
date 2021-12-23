using Steering_behaviours.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Steering_behaviours.Helpers
{
    public  abstract class DesiredVelocityProvider
    {
        public Vector3 Position { get; private set; }
        private float Weight { get; set; }
        public abstract Vector3 GetDesiredVelocity(Animal an);

        public DesiredVelocityProvider(Vector3 position)
        {
            Position = position;
        }
    }
}
