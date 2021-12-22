using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Steering_behaviours.Models
{
    public class Hunter : Creature
    {
        public Hunter() : base(1, 1, Color.FromName("SlateBlue"), new System.Numerics.Vector3(),10) // implement values for position
        {

        }
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
