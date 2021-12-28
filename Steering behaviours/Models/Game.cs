using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Steering_behaviours.Models
{
    public class Game
    {
        private readonly Field field;
        public bool IsEnded { get; private set; }

        public Game()
        {
            field = new Field();
        }

        public void StartGame(int rabbitsNum, int wolvesNum, int doeNum)
        {
            field.Populate(rabbitsNum, wolvesNum, doeNum);
        }

        public List<Creature> GetCreatures()
        {
            return Field.Members.Where(x=>x.IsAlive).ToList();
        }

        public void UpdateCreatures()
        {
            field.UpdatePositions();
        }

        public int TakeShot(Vector3 targetPosition)
        {
            field.GetHunter().TakeShot(targetPosition);
            field.UpdateInjuries(targetPosition, 1);
            return field.GetHunter().Gun.Bullets;
        }

        //update hunter's direction
        public void MoveHunter(int X, int Y)
        {
            Hunter player = field.GetHunter();
            int currX = (int)player.Position.X;
            int currY = (int)player.Position.Y;
            if ((currX - X) > 0)
            {
                player.UpdateDirections(Direction.Left);
            }
            else if ((currX - X) < 0)
            {
                player.UpdateDirections(Direction.Right);
            }
            if ((currY - Y) > 0)
            {
                player.UpdateDirections(Direction.Top);
            }
            else if ((currY - Y) < 0)
            {
                player.UpdateDirections(Direction.Down);
            }
            player.UpdatePosition(new Vector3(X, Y, 0));
        }

        public float[] GetHunterPos()
        {
            Hunter player = field.GetHunter();
            float[] res = {player.Position.X, player.Position.Y};
            return res;
        }

        private void CheckGameEnd()
        {
            if (field.GetHunter().Health <= 0)
            {
                IsEnded = true;
            }
        }
    }
}