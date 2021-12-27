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
        public Rabbit() : base(1, 1, Color.FromName("SlateBlue"), new Vector3(ran.Next(1, Field.Width - 1), ran.Next(1, Field.Height - 1), 0), 60, 10, 100, 0, 5)
        {

        }
        protected override List<DesiredVelocityProvider> GetProviders()
        {
            var providers = new List<DesiredVelocityProvider>
            {
                new AvoidEdges(new Vector3(Position.X, 0, 0)),
                new AvoidEdges(new Vector3(Field.Width, Position.Y, 0)),
                new AvoidEdges(new Vector3(Position.X, Field.Height, 0)),
                new AvoidEdges(new Vector3(0, Position.Y, 0))
            };


            foreach (var item in Field.Members)
            {
                if (!item.Equals(this))
                    providers.Add(new Flee(item.Position));
            }

            providers.Add(new Wander(Position));

            return providers;
        }
    }
}
