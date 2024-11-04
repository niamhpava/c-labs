using Microsoft.AspNetCore.Mvc;
using QAForum.Areas.Users.ViewModels;
using QAForum.EF;

namespace QAForum.Controllers
{
    public class ForumController : Controller
    {
        private readonly ForumDbContext context;

        public ForumController(ForumDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(ForumViewModel.FromForums(context.Forums));
        }
    }
}
