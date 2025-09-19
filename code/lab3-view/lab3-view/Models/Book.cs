using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab3_view.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Summary { get; set; }

        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chi Pheo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/b1.jpg",
                    Price = 50000,
                    TotalPage = 250,
                    Summary = "Chi Pheo is a short story by the Vietnamese writer Nam Cao. It was first published in 1941 and is considered one of the most important works of modern Vietnamese literature. The story follows the life of Chi Pheo, a poor and"
                },
                new Book()
                {
                    Id = 2,
                    Title = "Doraemon",
                    AuthorId = 2,
                    GenreId = 2,
                    Image = "/images/products/b2.jpg",
                    Price = 30000,
                    TotalPage = 150,
                    Summary = "Doraemon is a Japanese manga series created by Fujiko F. Fujio. The series follows the adventures of a robotic cat named Doraemon, who travels back in time from the 22nd century to help"
                },
                new Book()
                {
                    Id = 3,
                    Title = "Harry Potter",
                    AuthorId = 3,
                    GenreId = 3,
                    Image = "/images/products/b3.jpg",
                    Price = 200000,
                    TotalPage = 500,
                    Summary = "Harry Potter is a series of fantasy novels written by British author J.K. Rowling. The series follows the life of a young wizard, Harry Potter, and his friends Hermione Granger and Ron Weasley, all of whom are students at the Hogwarts School of Witchcraft and Wizardry."
                }
            };
            return books;
        }

        public Book GetBookById(int id)
        {
            return GetBookList().FirstOrDefault(b => b.Id == id);
        }

        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "-1", Text = "Unknown" },
            new SelectListItem { Value = "1", Text = "Nam Cao" },
            new SelectListItem { Value = "2", Text = "Fujiko F. Fujio" },
            new SelectListItem { Value = "3", Text = "J.K. Rowling" }
        };

        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Classic" },
            new SelectListItem { Value = "2", Text = "Comic" },
            new SelectListItem { Value = "3", Text = "Fantasy" }
        };
    }
}
