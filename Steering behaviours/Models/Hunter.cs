using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Steering_behaviours.Models
{
    public class Hunter : Creature
    {
        public Gun Gun { get; set; }
        public List<Bullet> Bullets { get; private set; }

        public Hunter() : base(1, 1, Color.FromName("SlateBlue"), new System.Numerics.Vector3(),10) // implement values for position
        {
            Bullets = new List<Bullet>();
        }
        public override void Update()
        {
            foreach(var b in Bullets)
            {
                b.UpdatePosition();
                if (!b.IsActing)
                {
                    Bullets.Remove(b);
                }
            }

            ApplyMove();
        }

        private void ApplyMove()
        {
            throw new NotImplementedException();
        }
    }
}
