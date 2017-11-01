using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OperasWebSites.Models;

namespace OperasWebSites.Controllers
{
    public class OperasController : ApiController
    {
        private OperasDB db = new OperasDB();

        // GET: api/Operas
        public IQueryable<Opera> GetOperas()
        {
            return db.Operas;
        }

        // GET: api/Operas/5
        [ResponseType(typeof(Opera))]
        public IHttpActionResult GetOpera(int id)
        {
            Opera opera = db.Operas.Find(id);
            if (opera == null)
            {
                return NotFound();
            }

            return Ok(opera);
        }

        // PUT: api/Operas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOpera(int id, Opera opera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != opera.OperaID)
            {
                return BadRequest();
            }

            db.Entry(opera).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperaExists(id))
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

        // POST: api/Operas
        [ResponseType(typeof(Opera))]
        public IHttpActionResult PostOpera(Opera opera)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Operas.Add(opera);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = opera.OperaID }, opera);
        }

        // DELETE: api/Operas/5
        [ResponseType(typeof(Opera))]
        public IHttpActionResult DeleteOpera(int id)
        {
            Opera opera = db.Operas.Find(id);
            if (opera == null)
            {
                return NotFound();
            }

            db.Operas.Remove(opera);
            db.SaveChanges();

            return Ok(opera);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OperaExists(int id)
        {
            return db.Operas.Count(e => e.OperaID == id) > 0;
        }
    }
}