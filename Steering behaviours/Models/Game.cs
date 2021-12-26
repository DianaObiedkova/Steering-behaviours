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

        public List<string[]> UpdateCreatures(List<int[]> harmValues)
        {
            field.UpdateInjuries(harmValues);
            field.UpdatePositions();
            return field.GetCreatures();
        }

        public void TakeShot(Vector3 targetPosition)
        {
            field.GetHunter().TakeShot(targetPosition);
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