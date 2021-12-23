using Steering_behaviours.Helpers;
using Steering_behaviours.Models.Behaviours;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Steering_behaviours.Models
{
    public class Rabbit : Animal
    {
        public Rabbit() : base(1, 1, Color.FromName("SlateBlue"), new Vector3(), 60, 10, 5) // implement values for position
        {

        }
        protected override List<DesiredVelocityProvider> GetProviders()
        {
            var providers = new List<DesiredVelocityProvider>();

            providers.Add(new Wander(Position));

            providers.Add(new AvoidEdges(new Vector3(Position.X, Field.precipiceLength,0)));
            providers.Add(new AvoidEdges(new Vector3(Field.precipiceLength + Field.Width, Position.Y, 0)));
            providers.Add(new AvoidEdges(new Vector3(Field.precipiceLength, Field.precipiceLength + Field.Height, 0)));
            providers.Add(new AvoidEdges(new Vector3(Field.precipiceLength, Field.precipiceLength, 0)));


            foreach(var item in Field.Members)
            {
                if (item.Equals(this))
                    providers.Add(new Flee(item.Position));
            }

            return providers;
        }
    }
}
