using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<string[]> UpdateCreatures(List<int[]> harmValues)
        {
            field.UpdateInjuries(harmValues);
            field.UpdatePositions();
            return field.GetCreatures();
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