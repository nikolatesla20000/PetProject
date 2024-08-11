using Microsoft.AspNetCore.Mvc;
using PetProject.Models;
using PetProject.Repositories;

namespace PetProject.Controllers
{
    public class CatalogController : Controller
    {

        private readonly IPetRepository _repsitory;
        private static int currentId;


        public CatalogController(IPetRepository repsitory)
        {
            _repsitory = repsitory;
        }


        public IActionResult Index(string? SelectedCategory)
        {

            var animals = _repsitory.GetAnimals(SelectedCategory!);
            ViewBag.Categories = _repsitory.GetCategories().Select(c => c.Name).ToList();
            ViewBag.SelectedCategory = SelectedCategory;
            return View(animals);

        }



        public IActionResult Details(int animalId)
        {
            var animal = _repsitory.GetAnimalDetails(animalId);
            currentId = animalId;
            ViewBag.animalD = animal;

            return View(animal);
        }



        [HttpPost]
        public IActionResult AddComment(string comment)
        {
            Comment newComment = new Comment
            {
                AnimalId = currentId,
                CommentText = comment,
                Date = DateTime.Now
            };

            _repsitory.AddComment(newComment);
            ViewBag.Comment = comment;

            return RedirectToAction("Details", new { animalId = currentId });
        }

    }
}
