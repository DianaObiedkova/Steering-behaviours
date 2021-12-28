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
        public readonly int harm = 1;
        private long lifetime;

        public Wolf() : base(1, 1, 25, Color.FromName("SlateBlue"), new Vector3(ran.Next(1, Field.Width - 1), ran.Next(1, Field.Height - 1), 0), 20, 15, 75, 0, 10)
        {
            lifetime = GetMils();
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
                if (!(item is Wolf))
                    providers.Add(new Seek(item.Position));
            }

            providers.Add(new Wander(Position));

            return providers;
        }

        public bool CanHarm(Creature cr)
        {
            if (Position.Sub(cr.Position).Magnitude() <= cr.Diameter)
            {
                lifetime = GetMils();
                return true;
            }
            return false;
        }
    }
}
