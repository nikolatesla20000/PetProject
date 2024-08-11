using Microsoft.EntityFrameworkCore;
using PetProject.Data;
using PetProject.Models;

namespace PetProject.Repositories
{
    public class PetRepository : IPetRepository
    {
        private PetContext _context;
        public PetRepository(PetContext context)
        {
            _context = context;
        }


        public void Add(Animal animal)
        {
            _context.Animals!.Add(animal);
            _context.SaveChanges();
        }

        public void AddComment(Comment comment)
        {
            _context.Comments!.Add(comment);
            _context.SaveChanges();
        }

        public int CommentCount()
        {
            return _context.Comments!.Count() + 1;
        }

        public void Delete(int id)
        {
            //var animal = _context.Animals!.Single(a => a.AnimalId == id);
            //_context.Animals.Remove(animal);
            //_context.SaveChanges();
            var animal = _context.Animals.SingleOrDefault(a => a.AnimalId == id);
            if (animal != null)
            {
                _context.Animals.Remove(animal);
                _context.SaveChanges();
            }
        }

        public Animal? GetAnimalDetails(int id)
        {
            var animal = _context!.Animals!
                           .Include(a => a.Comments)
                           .Include(a => a.Category)
                           .FirstOrDefault(a => a.AnimalId == id);

            return animal;
        }

        public Animal GetAnimalForCommentPost(int id)
        {
            var animal = _context?.Animals!.First(animal => animal.AnimalId == id);
            return animal;
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return _context.Animals;
        }

        public IEnumerable<Animal> GetAnimals(string categoryName = "All Categories")
        {
            IQueryable<Animal> query = _context.Animals!;
            if (!string.IsNullOrEmpty(categoryName) && categoryName != "All Categories")
            {
                query = query.Join(_context.Categories!,
                    animal => animal.CategoryId,
                    Category => Category.CategoryId,
                    (animal, category) => new { Animal = animal, Category = category })
                    .Where(ac => ac.Category.Name == categoryName)
                    .Select(ac => ac.Animal);
            }
            return query.ToList();
        }

        public Animal? GetAnimalWithComments(int id)
        {
            return _context!.Animals!
                .Include(a => a.Comments)
                .FirstOrDefault(a => a.AnimalId == id);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories!.ToList();
        }

        public IEnumerable<Animal> GetTwoTopAnimals()
        {
            var topAnimals = _context.Animals
                             .Include(a => a.Comments)
                             .AsEnumerable()
                             .OrderByDescending(a => a.Comments!.Count)
                             .Take(2)
                             .ToList();

            return topAnimals;
        }

        public void Update(Animal animal)
        {
            var existingAnimal = _context.Animals.Single(a => a.AnimalId == animal.AnimalId);
            if (existingAnimal != null)
            {
                _context.Entry(existingAnimal).CurrentValues.SetValues(animal);
                _context.SaveChanges();
            }


        }
    }
}
