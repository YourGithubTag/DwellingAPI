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
    public class RoomsController : ControllerBase
    {
        private readonly DwellContext _context;

        public RoomsController(DwellContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rooms>>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rooms>> GetRooms(int id)
        {
            var rooms = await _context.Rooms.FindAsync(id);

            if (rooms == null)
            {
                return NotFound();
            }

            return rooms;
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRooms(int id, Rooms rooms)
        {
            if (id != rooms.RoomId)
            {
                return BadRequest();
            }

            _context.Entry(rooms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomsExists(id))
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

        // POST: api/Rooms
        [HttpPost]
        public async Task<ActionResult<Rooms>> PostRooms(Rooms rooms)
        {
            _context.Rooms.Add(rooms);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RoomsExists(rooms.RoomId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRooms", new { id = rooms.RoomId }, rooms);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rooms>> DeleteRooms(int id)
        {
            var rooms = await _context.Rooms.FindAsync(id);
            if (rooms == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(rooms);
            await _context.SaveChangesAsync();

            return rooms;
        }

        private bool RoomsExists(int id)
        {
            return _context.Rooms.Any(e => e.RoomId == id);
        }
    }
}
