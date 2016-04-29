using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Breeze.Models;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Breeze.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly BreezeDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsController(
            UserManager<ApplicationUser> userManager,
            BreezeDbContext db
        )
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(int id)
        {
            ViewData["GameId"] = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {
            var currentUser = await _userManager.FindByIdAsync(User.GetUserId());
            comment.User = currentUser;
            _db.Comments.Add(comment);
            _db.SaveChanges();
            return RedirectToAction("Details", "Games");
        }
    }
}