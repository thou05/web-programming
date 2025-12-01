using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using day09LabCodeFirst.Models;

namespace day09LabCodeFirst.Controllers
{
    public class LttLoaiSanPhamsController : Controller
    {
        private readonly Day09LabCFContext _context;

        public LttLoaiSanPhamsController(Day09LabCFContext context)
        {
            _context = context;
        }

        // GET: LttLoaiSanPhams
        public async Task<IActionResult> lttIndex()
        {
            return View(await _context.LttLoaiSanPhams.ToListAsync());
        }

        // GET: LttLoaiSanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lttLoaiSanPham = await _context.LttLoaiSanPhams
                .FirstOrDefaultAsync(m => m.lttId == id);
            if (lttLoaiSanPham == null)
            {
                return NotFound();
            }

            return View(lttLoaiSanPham);
        }

        // GET: LttLoaiSanPhams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LttLoaiSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("lttId,lttMaLoai,lttTenLoai,lttTrangThai")] LttLoaiSanPham lttLoaiSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lttLoaiSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(lttIndex));
            }
            return View(lttLoaiSanPham);
        }

        // GET: LttLoaiSanPhams/Edit/5
        public async Task<IActionResult> lttEdit(int? lttId)
        {
            if (lttId == null)
            {
                return NotFound();
            }

            var lttLoaiSanPham = await _context.LttLoaiSanPhams.FindAsync(lttId);
            if (lttLoaiSanPham == null)
            {
                return NotFound();
            }
            return View(lttLoaiSanPham);
        }

        // POST: LttLoaiSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> lttEdit(int lttId, [Bind("lttId,lttMaLoai,lttTenLoai,lttTrangThai")] LttLoaiSanPham lttLoaiSanPham)
        {
            if (lttId != lttLoaiSanPham.lttId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lttLoaiSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LttLoaiSanPhamExists(lttLoaiSanPham.lttId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(lttIndex));
            }
            return View(lttLoaiSanPham);
        }

        // GET: LttLoaiSanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lttLoaiSanPham = await _context.LttLoaiSanPhams
                .FirstOrDefaultAsync(m => m.lttId == id);
            if (lttLoaiSanPham == null)
            {
                return NotFound();
            }

            return View(lttLoaiSanPham);
        }

        // POST: LttLoaiSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lttLoaiSanPham = await _context.LttLoaiSanPhams.FindAsync(id);
            if (lttLoaiSanPham != null)
            {
                _context.LttLoaiSanPhams.Remove(lttLoaiSanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LttLoaiSanPhamExists(int id)
        {
            return _context.LttLoaiSanPhams.Any(e => e.lttId == id);
        }
    }
}
