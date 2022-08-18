using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using _4.DatabaseContext;
using _4.Models;

namespace _4.Controllers
{
    public class Authors1Controller : ApiController
    {
        private Context db = new Context();

        // GET: api/Authors1
        public IQueryable<Author> GetAuthors()
        {
            return db.Authors;
        }

        // GET: api/Authors1/5
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> GetAuthor(int id)
        {
            Author author = await db.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // PUT: api/Authors1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAuthor(int id, Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != author.AuthorId)
            {
                return BadRequest();
            }

            db.Entry(author).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Authors1
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> PostAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Authors.Add(author);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = author.AuthorId }, author);
        }

        // DELETE: api/Authors1/5
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> DeleteAuthor(int id)
        {
            Author author = await db.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            db.Authors.Remove(author);
            await db.SaveChangesAsync();

            return Ok(author);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuthorExists(int id)
        {
            return db.Authors.Count(e => e.AuthorId == id) > 0;
        }
    }
}