using Microsoft.AspNetCore.Mvc;
using NguyenVanKiet_N04_221230890.Models;

namespace NguyenVanKiet_N04_221230890.ViewComponents
{
    public class PhanLoaiPhuMenuViewComponent : ViewComponent
    {
        private readonly QlbanGiayContext _context;
        public PhanLoaiPhuMenuViewComponent(QlbanGiayContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var phanloaiphu = _context.PhanLoaiPhus.ToList();
            return View(phanloaiphu);
        }
    }
}
