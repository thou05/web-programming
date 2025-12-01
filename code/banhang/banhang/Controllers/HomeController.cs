using banhang.Models;
using banhang.Models.Authentication;
using banhang.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing.Printing;
using X.PagedList;

namespace banhang.Controllers
{
    
    public class HomeController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //[Authentication]        
        
        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listsp = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(listsp, pageNumber, pageSize);
            return View(lst);
        }

        //[Authentication]   
        public IActionResult SanPhamTheoLoai(String maloai, int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listsp = db.TDanhMucSps.AsNoTracking().Where
                              (x => x.MaLoai == maloai).OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(listsp, pageNumber, pageSize);
            ViewBag.maloai = maloai;

            return View(lst);
        }

        public IActionResult ChiTietSanPham(string masp)
        {
            var sp = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == masp);
            var anhSp = db.TAnhSps.Where(x => x.MaSp == masp).ToList();
            ViewBag.anhSanPham = anhSp;
            return View(sp);

        }

        public IActionResult ProductDetail(string masp)
        {
            var sp = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == masp);
            var anhSp = db.TAnhSps.Where(x => x.MaSp == masp).ToList();

            var homeProductDetailViewModel = new HomeProductDetailViewModel
            {
                danhMucSp = sp,
                anhSps = anhSp
            };
            return View(homeProductDetailViewModel);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
