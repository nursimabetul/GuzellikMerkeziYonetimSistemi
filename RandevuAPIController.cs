using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GuzellikMerkeziYonetimSistemi.Data;
using GuzellikMerkeziYonetimSistemi.Models;

namespace GuzellikMerkeziYonetimSistemi
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandevuAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RandevuAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RandevuAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Randevu>>> GetRandevus()
        {
            return await _context.Randevus.ToListAsync();
        }

        // GET: api/RandevuAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Randevu>> GetRandevu(int id)
        {
            var randevu = await _context.Randevus.FindAsync(id);

            if (randevu == null)
            {
                return NotFound();
            }

            return randevu;
        }

        // PUT: api/RandevuAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRandevu(int id, Randevu randevu)
        {
            if (id != randevu.Id)
            {
                return BadRequest();
            }

            _context.Entry(randevu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RandevuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RandevuAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Randevu>> PostRandevu(Randevu randevu)
        {
            _context.Randevus.Add(randevu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRandevu", new { id = randevu.Id }, randevu);
        }

        // DELETE: api/RandevuAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRandevu(int id)
        {
            var randevu = await _context.Randevus.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }

            _context.Randevus.Remove(randevu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RandevuExists(int id)
        {
            return _context.Randevus.Any(e => e.Id == id);
        }
    }
}
