using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bART_Solutions_test.Domain;
using bART_Solutions_test.Domain.Entities;

namespace bArt_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly Test_DbContext _context;

        public IncidentsController(Test_DbContext context)
        {
            _context = context;
        }

        // GET: api/Incidents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Incident>>> GetIncidents()
        {
            return await _context.Incidents.Include(a => a.Accounts).ToListAsync();
        }

        // GET: api/Incidents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Incident>> GetIncident(string id)
        {
            var incident = await _context.Incidents.FindAsync(id);

            if (incident == null)
            {
                return NotFound();
            }

            return incident;
        }

        // PUT: api/Incidents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncident(string id, Incident incident)
        {
            if (id != incident.Name)
            {
                return BadRequest();
            }

            _context.Entry(incident).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentExists(id))
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

        // POST: api/Incidents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754        
        [HttpPost]
        public async Task<ActionResult<Incident>> PostIncident(Incident incident)
        {
            for (int i = 0; i < incident.Accounts.Count; i++)
            {
                var account = incident.Accounts.ElementAt(i);

                var dbAccount = _context.Accounts
                        .Include(x => x.Contacts)
                        .FirstOrDefault(x => x.Name == account.Name);

                if (dbAccount == null)
                {
                    return NotFound();
                }

                foreach (var contact in account.Contacts)
                {
                    var dbContact = dbAccount.Contacts.FirstOrDefault(x => x.Email == contact.Email);

                    if (dbContact != null)
                    {
                        dbContact.FirstName = contact.FirstName;
                        dbContact.LastName = contact.LastName;

                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.Contacts.Add(contact);
                        dbAccount.Contacts.Add(contact);
                        await _context.SaveChangesAsync();
                    }
                }

                incident.Accounts.Remove(account);
                incident.Accounts.Add(dbAccount);
            }
            _context.Incidents.Add(incident);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncident", new { id = incident.Name }, incident);
        }

        // DELETE: api/Incidents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncident(string id)
        {
            var incident = await _context.Incidents.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }

            _context.Incidents.Remove(incident);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncidentExists(string id)
        {
            return _context.Incidents.Any(e => e.Name == id);
        }
    }
}
