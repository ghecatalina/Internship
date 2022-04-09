using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Models
{
    public class Repository
    {
        public List<User> Users { get; set; } = new List<User>
        {
            new User {Username = "ana.ana", Email = "ana.ana@gmail.com", Password = "1234"},
            new User {Username = "vlad", Email = "vlad@gmail.com", Password = "1234"},
            new User {Username = "Maria", Email = "maria@gmail.com", Password = "1234"},
            new User {Username = "Adelin", Email = "adelin@gmail.com", Password = "1234"},
        };

        public List<Book> Books { get; set; } = new List<Book>
        {
            new Book {Title = "Book1", Author = "Author1", Description = "description1", OtherOption = "physical",
            Reviews = new List<Review>
            {
                new Review {Rating = 4, ReviewDescription = "book1 review1"},
                new Review {Rating = 4, ReviewDescription = "book1 review2"},
                new Review {Rating = 4, ReviewDescription = "book1 review3"},
            }
            },
            new Book {Title = "Book2", Author = "Author2", Description = "description2", OtherOption = "physical",
            Reviews = new List<Review>
            {
                new Review {Rating = 4, ReviewDescription = "book2 review1"},
                new Review {Rating = 4, ReviewDescription = "book2 review2"},
                new Review {Rating = 4, ReviewDescription = "book2 review3"},
            }
            },
        };
    }
}
