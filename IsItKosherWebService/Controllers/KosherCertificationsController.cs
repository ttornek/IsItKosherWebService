using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IsItKosherWebService.DbContexts;
using IsItKosherWebService.Entities;

namespace IsItKosherWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KosherCertificationsController : ControllerBase
    {
        private readonly KosherCertificationsContext _context;

        public KosherCertificationsController(KosherCertificationsContext context)
        {
            _context = context;
        }

        // GET: api/KosherCertifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KosherCertification>>> GetKosherCertifications()
        {
            return await _context.KosherCertifications.ToListAsync();
        }

        // GET: api/KosherCertifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KosherCertification>> GetKosherCertification(Guid id)
        {
            var kosherCertification = await _context.KosherCertifications.FindAsync(id);

            if (kosherCertification == null)
            {
                return NotFound();
            }

            return kosherCertification;
        }

        // PUT: api/KosherCertifications/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKosherCertification(Guid id, KosherCertification kosherCertification)
        {
            if (id != kosherCertification.Id)
            {
                return BadRequest();
            }

            _context.Entry(kosherCertification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KosherCertificationExists(id))
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

        // POST: api/KosherCertifications
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<KosherCertification>> PostKosherCertification(KosherCertification kosherCertification)
        {
            _context.KosherCertifications.Add(kosherCertification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKosherCertification", new { id = kosherCertification.Id }, kosherCertification);
        }

        // DELETE: api/KosherCertifications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KosherCertification>> DeleteKosherCertification(Guid id)
        {
            var kosherCertification = await _context.KosherCertifications.FindAsync(id);
            if (kosherCertification == null)
            {
                return NotFound();
            }

            _context.KosherCertifications.Remove(kosherCertification);
            await _context.SaveChangesAsync();

            return kosherCertification;
        }

        private bool KosherCertificationExists(Guid id)
        {
            return _context.KosherCertifications.Any(e => e.Id == id);
        }
    }
}
