using banhang.Repository;
using Microsoft.AspNetCore.Mvc;
namespace banhang.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private readonly ILoadSpRepo _loadSpRepo;
        public LoaiSpMenuViewComponent(ILoadSpRepo loadSpRepo)
        {
            _loadSpRepo = loadSpRepo;
        }
        public IViewComponentResult Invoke()
        {
            var loaiSp = _loadSpRepo.GetAllLoaiSp().OrderBy(x => x.Loai);
            return View(loaiSp);
        }
    }
}
