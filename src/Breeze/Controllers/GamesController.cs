using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Breeze.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Breeze.Controllers
{
    public class GamesController : Controller
    {
        private BreezeContext db = new BreezeContext();
        public IActionResult Index()
        {
            return View(db.Games.ToList());
        }
        public IActionResult Details(int id)
        {
            var thisGame = db.Games.FirstOrDefault(games => games.GameId == id);
            return View(thisGame);
        }
    }
}
