﻿using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        //params: direction
        public void MoveHunter()
        {
            
        }
        [HttpGet]
        public IEnumerable<FrontCreature> GetMembersPositions()
        {
            return Game.GetCreatures().Select(x => new FrontCreature(x.ID, x.Position.X, x.Position.Y));
        }

        //params: string "Xpos Ypos"
        public void TakeShot(string targetPosition)
        {
            string[] result = targetPosition.Split(" ");
            Game.TakeShot(new Vector3(float.Parse(result[0]), float.Parse(result[1]), 0));
        }

        //returns current creatures' positions
        //harmValues int[]: [ID, harmValue]
        public List<string[]> UpdateField(List<int[]> harmValues)
        {
            return Game.UpdateCreatures(harmValues);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
