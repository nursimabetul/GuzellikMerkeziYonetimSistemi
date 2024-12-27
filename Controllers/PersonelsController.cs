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
	public class PersonelsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public PersonelsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Personels
		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Personels.Include(p => p.Salon).Include(p => p.Uzmanlik);
			return View(await applicationDbContext.ToListAsync());
		}

		// GET: Personels/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var personel = await _context.Personels
				.Include(p => p.Salon)
				.Include(p => p.Uzmanlik)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (personel == null)
			{
				return NotFound();
			}

			return View(personel);
		}

		// GET: Personels/Create
		public IActionResult Create()
		{
			ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id");
			ViewData["UzmanlikId"] = new SelectList(_context.Set<Uzmanlik>(), "Id", "Id");
			return View();
		}

		// POST: Personels/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Adi,Soyadi,GSM,EmailAdres,UzmanlikId,SalonId,DogumTarihi,Adres")] Personel personel)
		{
			if (ModelState.IsValid)
			{
				_context.Add(personel);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", personel.SalonId);
			ViewData["UzmanlikId"] = new SelectList(_context.Set<Uzmanlik>(), "Id", "Id", personel.UzmanlikId);
			return View(personel);
		}

		// GET: Personels/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var personel = await _context.Personels.FindAsync(id);
			if (personel == null)
			{
				return NotFound();
			}
			ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", personel.SalonId);
			ViewData["UzmanlikId"] = new SelectList(_context.Set<Uzmanlik>(), "Id", "Id", personel.UzmanlikId);
			return View(personel);
		}

		// POST: Personels/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Soyadi,GSM,EmailAdres,UzmanlikId,SalonId,DogumTarihi,Adres")] Personel personel)
		{
			if (id != personel.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(personel);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!PersonelExists(personel.Id))
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
			ViewData["SalonId"] = new SelectList(_context.Salons, "Id", "Id", personel.SalonId);
			ViewData["UzmanlikId"] = new SelectList(_context.Set<Uzmanlik>(), "Id", "Id", personel.UzmanlikId);
			return View(personel);
		}

		// GET: Personels/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var personel = await _context.Personels
				.Include(p => p.Salon)
				.Include(p => p.Uzmanlik)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (personel == null)
			{
				return NotFound();
			}

			return View(personel);
		}

		// POST: Personels/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var personel = await _context.Personels.FindAsync(id);
			if (personel != null)
			{
				_context.Personels.Remove(personel);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool PersonelExists(int id)
		{
			return _context.Personels.Any(e => e.Id == id);
		}
	}
}
