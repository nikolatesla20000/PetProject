using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using PetProject.Models;
using PetProject.Repositories;

namespace PetProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPetRepository _repsitory;


        public AdminController(IPetRepository repsitory)
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
            ViewBag.animalD = animal;
            return View(animal);
        }

        [HttpPost]
        public IActionResult Delete(int animalId)
        {
            _repsitory.Delete(animalId);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int animalId)
        {
            var animal = _repsitory.GetAnimalDetails(animalId);
            ViewBag.Categories = _repsitory.GetCategories();
            return View(animal);
        }

        [HttpPost]
        public IActionResult Edit(Animal animal, IFormFile? newPicture)
        {
            if (newPicture != null && newPicture.Length > 0)
            {
                if (!newPicture.FileName.ToLower().EndsWith(".jpg") && !newPicture.FileName.ToLower().EndsWith(".jpeg") && !newPicture.FileName.ToLower().EndsWith(".png"))
                {
                    ModelState.AddModelError("PictureName", "The picture name must end with .jpg, .jpeg, or .png.");
                    ViewBag.Categories = _repsitory.GetCategories();
                    var existingAnimal = _repsitory.GetAnimalDetails(animal.AnimalId);
                    animal.PictureName = existingAnimal.PictureName;

                    return View(animal);
                }
                // Handle the new picture upload
                var filePath = Path.Combine("wwwroot/Images", newPicture.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    newPicture.CopyTo(stream);
                }
                animal.PictureName = newPicture.FileName;
            }
            else
            {
                // Retain the current picture name
                var existingAnimal = _repsitory.GetAnimalDetails(animal.AnimalId);
                if (existingAnimal != null)
                {
                    animal.PictureName = existingAnimal.PictureName;
                }
            }

            if (ModelState.IsValid)
            {
                _repsitory.Update(animal);
                return RedirectToAction("Details", new { animalId = animal.AnimalId });
            }

            ViewBag.Categories = _repsitory.GetCategories();
            return View(animal); 
        }


        public IActionResult Create()
        {
            ViewBag.Categories = _repsitory.GetCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Animal animal, IFormFile? newPicture)
        {
            if (ModelState.IsValid)
            {
                if (newPicture != null && newPicture.Length > 0)
                {
                    if (!newPicture.FileName.ToLower().EndsWith(".jpg") && !newPicture.FileName.ToLower().EndsWith(".jpeg") && !newPicture.FileName.ToLower().EndsWith(".png"))
                    {
                        ModelState.AddModelError("PictureName", "The picture name must end with .jpg, .jpeg, or .png.");
                        ViewBag.Categories = _repsitory.GetCategories();
                        
                        animal.PictureName = "NewDefault.jpg";    

                        return View(animal);
                    }
                    
                    var filePath = Path.Combine("wwwroot/Images", newPicture.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        newPicture.CopyTo(stream);
                    }
                    animal.PictureName = newPicture.FileName;
                }
                else
                {
                    animal.PictureName = "NewDefault.jpg"; 
                }

                _repsitory.Add(animal);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _repsitory.GetCategories();
            return View(animal);
        }


    }
}
