﻿using Steering_behaviours.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Steering_behaviours.Models
{
    public class Bullet
    {
        private Vector3 StartPosition { get; set; }
        private Vector3 Position { get; set; }
        private Vector3 Direction { get; set; }
        private int maxDistance;
        private long Time;
        private float velocityLimit=50;
        private int harm;

        public Bullet(Vector3 startPosition, Vector3 dir, int distance, int harm)
        {
            StartPosition = startPosition;
            Direction = dir;
            maxDistance = distance;
            this.harm = harm;

            Time = Animal.GetMils();
        }

        public bool IsActing
        => Position.Sub(StartPosition).Magnitude() <= maxDistance;

        internal void UpdatePosition()
        {
            double delta = (Animal.GetMils() - Time) * 0.01;
            Time = Animal.GetMils();

            Position.Add(Direction.Mult((float)(velocityLimit * delta)));
        }
    }
}
