using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuzellikMerkeziYonetimSistemi.Data;
using GuzellikMerkeziYonetimSistemi.Models;

namespace GuzellikMerkeziYonetimSistemi
{
    public class RandevusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RandevusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Randevus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Randevus.Include(r => r.Islem).Include(r => r.Salon);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Randevus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevus
                .Include(r => r.Islem)
                .Include(r => r.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // GET: Randevus/Create
        public IActionResult Create()
        {
            ViewData["IslemId"] = new SelectList(_context.Islems, "Id", "Id");
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id");
            return View();
        }

        // POST: Randevus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RandevuTarihi,UserID,IslemId,SalonId,durum,Aciklama")] Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(randevu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IslemId"] = new SelectList(_context.Islems, "Id", "Id", randevu.IslemId);
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", randevu.SalonId);
            return View(randevu);
        }

        // GET: Randevus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevus.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }
            ViewData["IslemId"] = new SelectList(_context.Islems, "Id", "Id", randevu.IslemId);
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", randevu.SalonId);
            return View(randevu);
        }

        // POST: Randevus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RandevuTarihi,UserID,IslemId,SalonId,durum,Aciklama")] Randevu randevu)
        {
            if (id != randevu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randevu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandevuExists(randevu.Id))
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
            ViewData["IslemId"] = new SelectList(_context.Islems, "Id", "Id", randevu.IslemId);
            ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", randevu.SalonId);
            return View(randevu);
        }

        // GET: Randevus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevus
                .Include(r => r.Islem)
                .Include(r => r.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // POST: Randevus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var randevu = await _context.Randevus.FindAsync(id);
            if (randevu != null)
            {
                _context.Randevus.Remove(randevu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandevuExists(int id)
        {
            return _context.Randevus.Any(e => e.Id == id);
        }
    }
}
