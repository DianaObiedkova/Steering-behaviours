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
            ViewData["bullets"] = Game.Bullets;
            return View();
        }
        [HttpPost]
        public void MoveHunter(string X, string Y)
        {
            if (float.TryParse(X.Replace('.', ','), out float fX) && float.TryParse(Y.Replace('.', ','), out float fY))
            {
                Game.MoveHunter(fX, fY);
            }
        }
        [HttpGet]
        public IEnumerable<FrontCreature> GetMembersPositions()
        {
            Game.UpdateCreatures();
            return Game.GetCreatures().Select(x => new FrontCreature(x.ID, x.Position.X, x.Position.Y, x.GetType().Name));
        }

        //params: string "Xpos Ypos"
       //[HttpPost]
        public int TakeShot(string X, string Y)
        {
            if (float.TryParse(X.Replace('.', ','), out float fX) && float.TryParse(Y.Replace('.', ','), out float fY))
            {
                return Game.TakeShot(new Vector3(fX, fY, 0));
            }
            return default;
        }

        //returns current creatures' positions
        //harmValues int[]: [ID, harmValue]
        public void UpdateField()
        {
            Game.UpdateCreatures();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
