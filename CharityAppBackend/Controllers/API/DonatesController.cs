using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CharityAppBackend.Data;
using CharityAppBackend.Models;

namespace CharityAppBackend.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DonatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Donates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donate>>> GetDonates()
        {
            return await _context.Donates.ToListAsync();
        }

        // GET: api/Donates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donate>> GetDonate(int id)
        {
            var donate = await _context.Donates.FindAsync(id);

            if (donate == null)
            {
                return NotFound();
            }

            return donate;
        }

        // PUT: api/Donates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonate(int id, Donate donate)
        {
            if (id != donate.Id)
            {
                return BadRequest();
            }

            _context.Entry(donate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonateExists(id))
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

        // POST: api/Donates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Donate>> PostDonate(Donate donate)
        {
            _context.Donates.Add(donate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonate", new { id = donate.Id }, donate);
        }

        // DELETE: api/Donates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Donate>> DeleteDonate(int id)
        {
            var donate = await _context.Donates.FindAsync(id);
            if (donate == null)
            {
                return NotFound();
            }

            _context.Donates.Remove(donate);
            await _context.SaveChangesAsync();

            return donate;
        }

        private bool DonateExists(int id)
        {
            return _context.Donates.Any(e => e.Id == id);
        }
    }
}
