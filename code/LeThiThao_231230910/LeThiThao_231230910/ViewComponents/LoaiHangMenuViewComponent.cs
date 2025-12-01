using LeThiThao_231230910.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeThiThao_231230910.ViewComponents
{
    public class LoaiHangMenuViewComponent : ViewComponent
    {
        private readonly QlhangHoaContext _context;

        public LoaiHangMenuViewComponent(QlhangHoaContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var loaiHangs = _context.LoaiHangs.ToList();
            return View(loaiHangs);
        }

    }
}
