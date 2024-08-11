using PetProject.Models;

namespace PetProject.Repositories
{
    public interface IPetRepository
    {
        IEnumerable<Animal> GetAnimals();
        //Animal GetById(int id);
        void Add(Animal animal);
        void Update(Animal animal);
        void Delete(int id);

        IEnumerable<Animal> GetTwoTopAnimals();
        IEnumerable<Animal> GetAnimals(string categoryName = "All Categories");
        IEnumerable<Category> GetCategories();
        Animal? GetAnimalDetails(int id);
        void AddComment(Comment comment);
        Animal? GetAnimalWithComments(int id);

        Animal GetAnimalForCommentPost(int id);
        int CommentCount();


    }
}
