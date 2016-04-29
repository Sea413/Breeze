using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Breeze.Models;
using Microsoft.Data.Entity;

namespace Breeze.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private BreezeContext db = new BreezeContext();

        public GamesController(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext db
        )
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {

            return View(db.Games.ToList());
        }
        public IActionResult Details(int id)
        {
            var gameList = db.Games.Where(x => x.GameId == id).Include(game => game.Comments).ToList();
            return View(gameList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Game game)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            game.User = currentUser;
            _db.Games.Add(game);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisGame = db.Games.FirstOrDefault(games => games.GameId == id);
            return View(thisGame);
        }

        [HttpPost]
        public IActionResult Edit(Game game)
        {
            db.Entry(game).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var thisGame = db.Games.FirstOrDefault(x => x.GameId == id);
            db.Games.Remove(thisGame);
            db.SaveChanges();
            return RedirectToAction("Index");
        
     }
    }
   }
