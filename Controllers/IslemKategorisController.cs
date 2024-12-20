using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuzellikMerkeziYonetimSistemi.Data;
using GuzellikMerkeziYonetimSistemi.Models;

namespace GuzellikMerkeziYonetimSistemi.Controllers
{
    public class IslemKategorisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IslemKategorisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IslemKategoris
        public async Task<IActionResult> Index()
        {
            return View(await _context.IslemKategoris.ToListAsync());
        }

        // GET: IslemKategoris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var islemKategori = await _context.IslemKategoris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (islemKategori == null)
            {
                return NotFound();
            }

            return View(islemKategori);
        }

        // GET: IslemKategoris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IslemKategoris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kategori,KategoriAciklama")] IslemKategori islemKategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(islemKategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(islemKategori);
        }

        // GET: IslemKategoris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var islemKategori = await _context.IslemKategoris.FindAsync(id);
            if (islemKategori == null)
            {
                return NotFound();
            }
            return View(islemKategori);
        }

        // POST: IslemKategoris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kategori,KategoriAciklama")] IslemKategori islemKategori)
        {
            if (id != islemKategori.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(islemKategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IslemKategoriExists(islemKategori.Id))
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
            return View(islemKategori);
        }

        // GET: IslemKategoris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var islemKategori = await _context.IslemKategoris
                .FirstOrDefaultAsync(m => m.Id == id);
            if (islemKategori == null)
            {
                return NotFound();
            }

            return View(islemKategori);
        }

        // POST: IslemKategoris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var islemKategori = await _context.IslemKategoris.FindAsync(id);
            if (islemKategori != null)
            {
                _context.IslemKategoris.Remove(islemKategori);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IslemKategoriExists(int id)
        {
            return _context.IslemKategoris.Any(e => e.Id == id);
        }
    }
}
