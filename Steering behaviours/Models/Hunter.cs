using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Steering_behaviours.Models
{
    public class Hunter : Creature
    {
        public Gun Gun { get; private set; }
        public List<Bullet> Bullets { get; private set; }

        readonly Dictionary<Direction, int> Directions = new Dictionary<Direction, int>(); //needed to be filled from mouse events in "Game"

        public Hunter() : base(1, 1, Color.FromName("SlateBlue"), new Vector3(ran.Next(1, Field.Width - 1), ran.Next(1, Field.Height - 1), 0), 5)
        {
            Bullets = new List<Bullet>();
            Directions.Add(Direction.Top, 0);
            Directions.Add(Direction.Left, 0);
            Directions.Add(Direction.Down, 1);
            Directions.Add(Direction.Right, 0);

            Gun = new Gun(500, 1);
        }
        public override void Update()
        {
            foreach(var b in Bullets.ToList())
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
            var delta = (GetMils() - Time) * 0.01;
            Time = GetMils();


            switch (GetCurrentDirection())
            {
                case Direction.Top:
                    {
                        Position = new Vector3(Position.X, (float)(Position.Y-MaxSpeed * delta), 0);
                        break;
                    }
                case Direction.Down:
                    {
                        Position = new Vector3(Position.X, (float)(Position.Y + MaxSpeed * delta), 0);
                        break;
                    }
                case Direction.Left:
                    {
                        Position = new Vector3((float)(Position.X - MaxSpeed * delta), Position.Y, 0);
                        break;
                    }
                case Direction.Right:
                    {
                        Position = new Vector3((float)(Position.X + MaxSpeed * delta), Position.Y, 0);
                        break;
                    }
            }
        }

        public void TakeShot(Vector3 targetPosition)
        {
            var bullet = Gun.Shot(new Vector3(Position.X, Position.Y, 0), new Vector3(targetPosition.X - Position.X, targetPosition.Y - Position.Y, 0));
            if (bullet != null) Bullets.Add(bullet);
        }

        public Direction GetCurrentDirection()
        {
            var counter = 0;
            foreach (var pair in Directions.ToList())
            {
                if (pair.Value == 1)
                {
                    counter++;
                }
            }

            return counter == 1 ? Directions.FirstOrDefault(x => x.Value == 1).Key : throw new ArgumentException("Not one current state specified, logic failure.");
        }

        public void UpdateDirections(Direction direction)
        {
            List<Direction> keys = new List<Direction>(Directions.Keys);
            foreach (Direction key in keys)
                Directions[key] = 0;
            if(!Directions.TryAdd(direction, 1))
                Directions[direction] = 1;
        }
    }
}
