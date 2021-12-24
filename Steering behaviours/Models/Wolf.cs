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
    public class Wolf : Animal
    {
        private int damage = 1;
        
        public Wolf() : base(1, 1, Color.FromName("SlateBlue"), new System.Numerics.Vector3(), 40, 40, 20) // implement values for position
        {

        }
        protected override List<DesiredVelocityProvider> GetProviders()
        {
            var providers = new List<DesiredVelocityProvider>
            {
                new AvoidEdges(new Vector3(Position.X, Field.precipiceLength, 0)),
                new AvoidEdges(new Vector3(Field.precipiceLength + Field.Width, Position.Y, 0)),
                new AvoidEdges(new Vector3(Field.precipiceLength, Field.precipiceLength + Field.Height, 0)),
                new AvoidEdges(new Vector3(Field.precipiceLength, Field.precipiceLength, 0)),
                new Wander(Position)
            };

            foreach (var item in Field.Members)
            {
                if (!(item is Wolf))
                    providers.Add(new Seek(item.Position));
            }

            return providers;
        }
    }
}
