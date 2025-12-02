using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeThiThao_231230910.Models;

namespace LeThiThao_231230910.Controllers
{
    public class ChuyensController : Controller
    {
        private readonly VanTai2512V1Context _context;

        public ChuyensController(VanTai2512V1Context context)
        {
            _context = context;
        }

        // GET: Chuyens
        public async Task<IActionResult> Index()
        {
            var vanTai2512V1Context = _context.Chuyens.Include(c => c.MaLaiXeNavigation).Include(c => c.MaTuyenNavigation).Include(c => c.SoXeNavigation);
            return View(await vanTai2512V1Context.ToListAsync());
        }

        // GET: Chuyens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuyen = await _context.Chuyens
                .Include(c => c.MaLaiXeNavigation)
                .Include(c => c.MaTuyenNavigation)
                .Include(c => c.SoXeNavigation)
                .FirstOrDefaultAsync(m => m.MaChuyen == id);
            if (chuyen == null)
            {
                return NotFound();
            }

            return View(chuyen);
        }

        // GET: Chuyens/Create
        public IActionResult Create()
        {
            ViewData["MaLaiXe"] = new SelectList(_context.LaiXes, "MaLaiXe", "MaLaiXe");
            ViewData["MaTuyen"] = new SelectList(_context.Tuyens, "MaTuyen", "MaTuyen");
            ViewData["SoXe"] = new SelectList(_context.Xes, "SoXe", "SoXe");
            return View();
        }

        // POST: Chuyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaChuyen,MaTuyen,SoXe,MaLaiXe,NgayGio")] Chuyen chuyen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chuyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLaiXe"] = new SelectList(_context.LaiXes, "MaLaiXe", "MaLaiXe", chuyen.MaLaiXe);
            ViewData["MaTuyen"] = new SelectList(_context.Tuyens, "MaTuyen", "MaTuyen", chuyen.MaTuyen);
            ViewData["SoXe"] = new SelectList(_context.Xes, "SoXe", "SoXe", chuyen.SoXe);
            return View(chuyen);
        }

        // GET: Chuyens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuyen = await _context.Chuyens.FindAsync(id);
            if (chuyen == null)
            {
                return NotFound();
            }
            ViewData["MaLaiXe"] = new SelectList(_context.LaiXes, "MaLaiXe", "MaLaiXe", chuyen.MaLaiXe);
            ViewData["MaTuyen"] = new SelectList(_context.Tuyens, "MaTuyen", "MaTuyen", chuyen.MaTuyen);
            ViewData["SoXe"] = new SelectList(_context.Xes, "SoXe", "SoXe", chuyen.SoXe);
            return View(chuyen);
        }

        // POST: Chuyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaChuyen,MaTuyen,SoXe,MaLaiXe,NgayGio")] Chuyen chuyen)
        {
            if (id != chuyen.MaChuyen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chuyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChuyenExists(chuyen.MaChuyen))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLaiXe"] = new SelectList(_context.LaiXes, "MaLaiXe", "MaLaiXe", chuyen.MaLaiXe);
            ViewData["MaTuyen"] = new SelectList(_context.Tuyens, "MaTuyen", "MaTuyen", chuyen.MaTuyen);
            ViewData["SoXe"] = new SelectList(_context.Xes, "SoXe", "SoXe", chuyen.SoXe);
            return View(chuyen);
        }

        // GET: Chuyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chuyen = await _context.Chuyens
                .Include(c => c.MaLaiXeNavigation)
                .Include(c => c.MaTuyenNavigation)
                .Include(c => c.SoXeNavigation)
                .FirstOrDefaultAsync(m => m.MaChuyen == id);
            if (chuyen == null)
            {
                return NotFound();
            }

            return View(chuyen);
        }

        // POST: Chuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chuyen = await _context.Chuyens.FindAsync(id);
            if (chuyen != null)
            {
                _context.Chuyens.Remove(chuyen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChuyenExists(int id)
        {
            return _context.Chuyens.Any(e => e.MaChuyen == id);
        }
    }
}
