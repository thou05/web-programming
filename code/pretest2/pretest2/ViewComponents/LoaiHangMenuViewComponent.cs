using Microsoft.AspNetCore.Mvc;
using pretest2.Models;

namespace pretest2.ViewComponents
{
    public class LoaiHangMenuViewComponent:ViewComponent
    {
        private readonly QlhangHoaContext _context;
        public LoaiHangMenuViewComponent(QlhangHoaContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var loaihang = _context.LoaiHangs.ToList();
            return View(loaihang);
        }
    }
}
