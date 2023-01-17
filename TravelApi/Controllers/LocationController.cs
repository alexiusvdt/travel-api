using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelApi.Models;

namespace TravelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly TravelApiContext _db;

        public LocationController(TravelApiContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> Get(string name, string country, int minimumWalkability, int minimumRating)
        {
        IQueryable<Location> query = _db.Locations.AsQueryable();

        if (name != null)
        {
            query = query.Where(entry => entry.Name == name);
        }
        if (country != null)
        {
            query = query.Where(entry => entry.Country == country);
        }
        if (minimumWalkability > 0)
        {
            query = query.Where(entry => entry.Walkability >= minimumWalkability);
        }
        if (minimumRating > 0)
        {
            query = query.Where(entry => entry.Rating >= minimumRating);
        }

        return await query.ToListAsync();
        }

        // GET: api/Location/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var location = await _db.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        // PUT: api/Location/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, Location location)
        {
            if (id != location.LocationId)
            {
                return BadRequest();
            }

            _db.Entry(location).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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

        // POST: api/Location
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            _db.Locations.Add(location);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetLocation", new { id = location.LocationId }, location);
        }

        // DELETE: api/Location/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _db.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _db.Locations.Remove(location);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool LocationExists(int id)
        {
            return _db.Locations.Any(e => e.LocationId == id);
        }
    }
}
