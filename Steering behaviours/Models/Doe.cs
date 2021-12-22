using Steering_behaviours.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Steering_behaviours.Models
{
    public class Doe : Animal
    {

        public Doe() : base(1, 1, Color.FromName("SlateBlue"), new System.Numerics.Vector3(), 10, 10, 5) // implement values for position
        {

        }

        protected override List<DesiredVelocityProvider> GetProviders()
        {
            throw new NotImplementedException();
        }
    }
}
