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
            return Field.Members;
        }

        public void UpdateCreatures(List<int[]> harmValues)
        {
            field.UpdateInjuries(harmValues);
            field.UpdatePositions();
        }

        public void TakeShot(Vector3 targetPosition)
        {
            field.GetHunter().TakeShot(targetPosition);
        }

        //update hunter's direction
        public void MoveHunter(string directionName)
        {
            Hunter player = field.GetHunter();
            Direction direction;
            switch(directionName) {
                case "top":
                    direction = Direction.Top;
                    break;
                case "down":
                    direction = Direction.Down;
                    break;
                case "left":
                    direction = Direction.Left;
                    break;
                case "right":
                    direction = Direction.Right;
                    break;
                default:
                direction = Direction.Top;
                    break;
            }
            player.UpdateDirections(direction);
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