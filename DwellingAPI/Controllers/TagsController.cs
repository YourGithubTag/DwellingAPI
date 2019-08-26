using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DwellingAPI.Model;

namespace DwellingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly DwellContext _context;

        public TagsController(DwellContext context)
        {
            _context = context;
        }

        // GET: api/Tags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tags>>> GetTags()
        {
            return await _context.Tags.ToListAsync();
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tags>> GetTags(int id)
        {
            var tags = await _context.Tags.FindAsync(id);

            if (tags == null)
            {
                return NotFound();
            }

            return tags;
        }

        // PUT: api/Tags/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTags(int id, Tags tags)
        {
            if (id != tags.TagId)
            {
                return BadRequest();
            }

            _context.Entry(tags).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagsExists(id))
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

        // POST: api/Tags
        [HttpPost]
        public async Task<ActionResult<Tags>> PostTags(Tags tags)
        {
            _context.Tags.Add(tags);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TagsExists(tags.TagId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTags", new { id = tags.TagId }, tags);
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tags>> DeleteTags(int id)
        {
            var tags = await _context.Tags.FindAsync(id);
            if (tags == null)
            {
                return NotFound();
            }

            _context.Tags.Remove(tags);
            await _context.SaveChangesAsync();

            return tags;
        }

        private bool TagsExists(int id)
        {
            return _context.Tags.Any(e => e.TagId == id);
        }
    }
}
