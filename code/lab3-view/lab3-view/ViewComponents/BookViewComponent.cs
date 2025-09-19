using lab3_view.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3_view.ViewComponents
{
    public class BookViewComponent : ViewComponent
    {
        protected Book book = new Book();
        public IViewComponentResult Invoke()
        {
            var books = book.GetBookList();
            return View(books);
        }
    }
}
