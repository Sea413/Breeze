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
        private readonly BreezeDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private BreezeDbContext db = new BreezeDbContext();

        public GamesController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, BreezeDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            return View(_db.Games.ToList());
        }
        public IActionResult Details(int id)
        {
            var gameList = _db.Games.Where(x => x.GameId == id).Include(game => game.Comments).ToList();
            ViewBag.GameId = id;
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
            var thisGame = _db.Games.FirstOrDefault(games => games.GameId == id);
            return View(thisGame);
        }

        [HttpPost]
        public IActionResult Edit(Game game)
        {
            _db.Entry(game).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var thisGame = db.Games.FirstOrDefault(x => x.GameId == id);
            _db.Games.Remove(thisGame);
            _db.SaveChanges();
            return RedirectToAction("Index");
        
     }
    }
   }
