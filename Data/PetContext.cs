using Microsoft.EntityFrameworkCore;
using PetProject.Models;

namespace PetProject.Data
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> options) : base(options)
        {
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Comment>? Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Cats" },
                new Category { CategoryId = 2, Name = "Dogs" },
                new Category { CategoryId = 3, Name = "Birds" },
                new Category { CategoryId = 4, Name = "Reptiles" },
                new Category { CategoryId = 5, Name = "Rodents" },
                new Category { CategoryId = 6, Name = "Fish" }
                );
            modelBuilder.Entity<Animal>().HasData(
                new Animal
                {
                    AnimalId = 1,
                    Name = "Akita Inu",
                    Age = 3,
                    PictureName = "Akitainu.jpg",
                    CategoryId = 2,
                    Description = "The Akita Inu is a large, powerful Japanese breed known for loyalty, courage, and a dignified presence. Historically used for guarding and hunting, they have a thick double coat in various colors like white, brindle, and red shades. Their fox-like face, erect ears, and curled tail give a noble appearance. Akitas are reserved with strangers but affectionate and protective with family. They need consistent training and socialization early due to their strong-willed, independent nature."
                },
                new Animal
                {
                    AnimalId = 2,
                    Name = "Capybara",
                    Age = 4,
                    PictureName = "Capybaraa.jpg",
                    CategoryId = 5,
                    Description = "The Capybara is the largest rodent in the world, native to South America. Capybaras are highly social animals and live in groups. They are known for their friendly and gentle nature. Capybaras are excellent swimmers and can hold their breath underwater for up to five minutes. They have webbed feet, which aid in swimming. Capybaras are herbivores and graze mainly on grasses and aquatic plants."
                },
                new Animal
                {
                    AnimalId = 3,
                    Name = "Cockatiel",
                    Age = 2,
                    PictureName = "Cockatiel.jpg",
                    CategoryId = 3,
                    Description = "The Cockatiel is a small parrot native to Australia. Known for their friendly and affectionate nature, Cockatiels are popular pets. They have a distinctive crest on their head, which they can raise and lower depending on their mood. Cockatiels are highly trainable and can learn to mimic sounds and whistles. They enjoy social interaction and require regular attention from their owners."
                },
                new Animal
                {
                    AnimalId = 4,
                    Name = "Komodo Dragon",
                    Age = 5,
                    PictureName = "KomodoDragon.jpg",
                    CategoryId = 4,
                    Description = "The Komodo Dragon is the largest living species of lizard, found in the Indonesian islands. Known for their impressive size and strength, Komodo Dragons are apex predators. They have a powerful bite and venomous saliva, which help them take down large prey. Komodo Dragons are solitary animals and have a keen sense of smell. They can detect carrion from miles away."
                },
                new Animal
                {
                    AnimalId = 5,
                    Name = "Pufferfish",
                    Age = 1,
                    PictureName = "Pufferfish.jpg",
                    CategoryId = 6,
                    Description = "Pufferfish are known for their ability to inflate their bodies when threatened, making them appear larger and more intimidating. They are found in tropical and subtropical waters around the world. Pufferfish are highly toxic; their bodies contain tetrodotoxin, which is deadly to most predators. Despite their toxicity, pufferfish are considered a delicacy in some cultures, prepared by specially trained chefs to avoid poisoning."
                },
                new Animal
                {
                    AnimalId = 6,
                    Name = "Siberian Cat",
                    Age = 3,
                    PictureName = "SberianCat.jpg",
                    CategoryId = 1,
                    Description = "The Siberian Cat is a large, strong breed with origins in Russia. Known for their thick, water-resistant triple coat, Siberians are well-suited to cold climates. They are affectionate, playful, and get along well with children and other pets. Siberian Cats are known for their hypoallergenic properties, making them a good choice for people with allergies. They are intelligent and enjoy interactive play."
                },
                 new Animal
                 {
                     AnimalId = 7,
                     Name = "Test Animal",
                     Age = 3,
                     PictureName = "NewDefault.jpg",
                     CategoryId = 1,
                     Description = "Test testing test"
                 }
                );
            modelBuilder.Entity<Comment>().HasData(
    // Comments for Akita Inu (AnimalId = 1)
    new Comment { CommentId = 1, AnimalId = 1, CommentText = "Such a cool breed!", Date = DateTime.Now },
    new Comment { CommentId = 2, AnimalId = 1, CommentText = "Akitas are so loyal and brave.", Date = DateTime.Now },
    new Comment { CommentId = 3, AnimalId = 1, CommentText = "I love their dignified presence.", Date = DateTime.Now },
    new Comment { CommentId = 4, AnimalId = 1, CommentText = "Perfect guard dogs!", Date = DateTime.Now },
    new Comment { CommentId = 5, AnimalId = 1, CommentText = "Beautiful and powerful dogs.", Date = DateTime.Now },
    new Comment { CommentId = 6, AnimalId = 1, CommentText = "I would love to have an Akita Inu.", Date = DateTime.Now },
    new Comment { CommentId = 24, AnimalId = 1, CommentText = "I would love to have an Akita Inu.", Date = DateTime.Now },

    // Comments for Capybara (AnimalId = 2)
    new Comment { CommentId = 7, AnimalId = 2, CommentText = "Capybaras are the cutest!", Date = DateTime.Now },
    new Comment { CommentId = 8, AnimalId = 2, CommentText = "Such gentle giants.", Date = DateTime.Now },
    new Comment { CommentId = 9, AnimalId = 2, CommentText = "I love how social they are.", Date = DateTime.Now },
    new Comment { CommentId = 10, AnimalId = 2, CommentText = "Amazing swimmers!", Date = DateTime.Now },
    new Comment { CommentId = 11, AnimalId = 2, CommentText = "Capybaras are so friendly.", Date = DateTime.Now },
    new Comment { CommentId = 12, AnimalId = 2, CommentText = "They have such a calm demeanor.", Date = DateTime.Now },

    // Comments for Cockatiel (AnimalId = 3)
    new Comment { CommentId = 13, AnimalId = 3, CommentText = "Cockatiels are so charming!", Date = DateTime.Now },
    new Comment { CommentId = 14, AnimalId = 3, CommentText = "Their whistles are so cute.", Date = DateTime.Now },
    new Comment { CommentId = 15, AnimalId = 3, CommentText = "Very affectionate birds.", Date = DateTime.Now },

    // Comments for Komodo Dragon (AnimalId = 4)
    new Comment { CommentId = 16, AnimalId = 4, CommentText = "Komodo Dragons are fascinating!", Date = DateTime.Now },
    new Comment { CommentId = 17, AnimalId = 4, CommentText = "Such powerful creatures.", Date = DateTime.Now },
    new Comment { CommentId = 18, AnimalId = 4, CommentText = "I love learning about them.", Date = DateTime.Now },

    // Comments for Pufferfish (AnimalId = 5)
    new Comment { CommentId = 19, AnimalId = 5, CommentText = "Pufferfish are so interesting!", Date = DateTime.Now },
    new Comment { CommentId = 20, AnimalId = 5, CommentText = "Amazing defense mechanism.", Date = DateTime.Now },
    new Comment { CommentId = 21, AnimalId = 5, CommentText = "They look so cute when they puff up.", Date = DateTime.Now },

    // Comments for Siberian Cat (AnimalId = 6)
    new Comment { CommentId = 22, AnimalId = 6, CommentText = "Siberian Cats are beautiful!", Date = DateTime.Now },
    new Comment { CommentId = 23, AnimalId = 6, CommentText = "Such a playful and affectionate breed.", Date = DateTime.Now }
                );
        }
    }
}
