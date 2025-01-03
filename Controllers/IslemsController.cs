﻿using System;
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
    public class IslemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IslemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Islems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Islems.Include(i => i.IslemKategori);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Islems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var islem = await _context.Islems
                .Include(i => i.IslemKategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (islem == null)
            {
                return NotFound();
            }

            return View(islem);
        }

        // GET: Islems/Create
        public IActionResult Create()
        {
            ViewData["IslemKategoriId"] = new SelectList(_context.IslemKategoris, "Id", "Id");
            return View();
        }

        // POST: Islems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IslemAdi,IslemKategoriId,Sure,Fiyat,Aciklama")] Islem islem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(islem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IslemKategoriId"] = new SelectList(_context.IslemKategoris, "Id", "Id", islem.IslemKategoriId);
            return View(islem);
        }

        // GET: Islems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var islem = await _context.Islems.FindAsync(id);
            if (islem == null)
            {
                return NotFound();
            }
            ViewData["IslemKategoriId"] = new SelectList(_context.IslemKategoris, "Id", "Id", islem.IslemKategoriId);
            return View(islem);
        }

        // POST: Islems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IslemAdi,IslemKategoriId,Sure,Fiyat,Aciklama")] Islem islem)
        {
            if (id != islem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(islem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IslemExists(islem.Id))
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
            ViewData["IslemKategoriId"] = new SelectList(_context.IslemKategoris, "Id", "Id", islem.IslemKategoriId);
            return View(islem);
        }

        // GET: Islems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var islem = await _context.Islems
                .Include(i => i.IslemKategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (islem == null)
            {
                return NotFound();
            }

            return View(islem);
        }

        // POST: Islems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var islem = await _context.Islems.FindAsync(id);
            if (islem != null)
            {
                _context.Islems.Remove(islem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IslemExists(int id)
        {
            return _context.Islems.Any(e => e.Id == id);
        }
    }
}
