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
	public class KullaniciTurusController : Controller
	{
		private readonly ApplicationDbContext _context;

		public KullaniciTurusController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: KullaniciTurus
		public async Task<IActionResult> Index()
		{
			return View(await _context.KullaniciTurus.ToListAsync());
		}

		// GET: KullaniciTurus/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var kullaniciTuru = await _context.KullaniciTurus
				.FirstOrDefaultAsync(m => m.Id == id);
			if (kullaniciTuru == null)
			{
				return NotFound();
			}

			return View(kullaniciTuru);
		}

		// GET: KullaniciTurus/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: KullaniciTurus/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,KullanıcıTuruAdi")] KullaniciTuru kullaniciTuru)
		{
			if (ModelState.IsValid)
			{
				_context.Add(kullaniciTuru);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(kullaniciTuru);
		}

		// GET: KullaniciTurus/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var kullaniciTuru = await _context.KullaniciTurus.FindAsync(id);
			if (kullaniciTuru == null)
			{
				return NotFound();
			}
			return View(kullaniciTuru);
		}

		// POST: KullaniciTurus/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,KullanıcıTuruAdi")] KullaniciTuru kullaniciTuru)
		{
			if (id != kullaniciTuru.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(kullaniciTuru);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!KullaniciTuruExists(kullaniciTuru.Id))
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
			return View(kullaniciTuru);
		}

		// GET: KullaniciTurus/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var kullaniciTuru = await _context.KullaniciTurus
				.FirstOrDefaultAsync(m => m.Id == id);
			if (kullaniciTuru == null)
			{
				return NotFound();
			}

			return View(kullaniciTuru);
		}

		// POST: KullaniciTurus/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var kullaniciTuru = await _context.KullaniciTurus.FindAsync(id);
			if (kullaniciTuru != null)
			{
				_context.KullaniciTurus.Remove(kullaniciTuru);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool KullaniciTuruExists(int id)
		{
			return _context.KullaniciTurus.Any(e => e.Id == id);
		}
	}
}
