using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Steering_behaviours.Helpers;
using Steering_behaviours.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Steering_behaviours.Controllers
{
    public class GameController:Controller
    {
        public static Game Game { get; set; }
        private readonly ILogger<HomeController> _logger;

        public GameController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult StartGame()
        {
            Game = new Game();
            Game.StartGame(10, 3, 15);
            return View();
        }

        public void MoveHunter(int X, int Y)
        {
            float[] hunterPos = Game.GetHunterPos();
            int currX = (int)hunterPos[0];
            int currY = (int)hunterPos[1];
            if((currX-X)>0) {
                Game.MoveHunter("left");
            } else if ((currX-X)<0) {
                Game.MoveHunter("right");
            }
            if((currY-Y)>0) {
                Game.MoveHunter("top");
            } else if((currY-Y)<0) {
                Game.MoveHunter("down");
            }
        }
        [HttpGet]
        public IEnumerable<FrontCreature> GetMembersPositions()
        {
            return Game.GetCreatures().Select(x => new FrontCreature(x.ID, x.Position.X, x.Position.Y));
        }

        //params: string "Xpos Ypos"
        public void TakeShot(int X, int Y)
        {
            Game.TakeShot(new Vector3(X, Y, 0));
        }

        //returns current creatures' positions
        //harmValues int[]: [ID, harmValue]
        public void UpdateField(List<int[]> harmValues)
        {
            Game.UpdateCreatures(harmValues);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
