using Microsoft.AspNetCore.Mvc;
using PetProject.Repositories;

namespace PetProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPetRepository _repsitory;

        public HomeController(IPetRepository repsitory)
        {
            _repsitory = repsitory;
        }

        public IActionResult Index()
        {
            return View(_repsitory.GetTwoTopAnimals());
        }
    }
}
