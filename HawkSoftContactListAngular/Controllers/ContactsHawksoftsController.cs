using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HawkSoftContacts;
using HawkSoftDomain;

namespace HawkSoftContactListAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsHawksoftsController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactsHawksoftsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ContactsHawksofts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactsHawksoft>>> GetContact()
        {
            return await _context.Contact.ToArrayAsync();
        }

        // GET: api/ContactsHawksofts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ContactsHawksoft>>> GetContactsHawksoft(int id)
        {
            var contactsHawksoft = await _context.Contact.Where(x => x.UsersHawksoftUserId == id).ToListAsync();               
            

            if (contactsHawksoft == null)
            {
                return NotFound();
            }

            return contactsHawksoft;
        }

        // PUT: api/ContactsHawksofts/5             
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactsHawksoft(int id, ContactsHawksoft contactsHawksoft)
        {
            if (id != contactsHawksoft.ContactId)
            {
                return BadRequest();
            }

            _context.Entry(contactsHawksoft).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactsHawksoftExists(id))
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

        // POST: api/ContactsHawksofts     
        [HttpPost]
        public async Task<ActionResult<ContactsHawksoft>> PostContactsHawksoft(ContactsHawksoft contactsHawksoft)
        {
            _context.Contact.Add(contactsHawksoft);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactsHawksoft", new { id = contactsHawksoft.ContactId }, contactsHawksoft);
        }

        // DELETE: api/ContactsHawksofts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactsHawksoft>> DeleteContactsHawksoft(int id)
        {
            var contactsHawksoft = await _context.Contact.Where(x => x.ContactId == id).ToListAsync();

            if (contactsHawksoft == null)
            {
                return NotFound();
            }

            _context.Contact.Remove(contactsHawksoft.FirstOrDefault());
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ContactsHawksoftExists(int id)
        {
            return _context.Contact.Any(e => e.ContactId == id);
        }
    }
}
