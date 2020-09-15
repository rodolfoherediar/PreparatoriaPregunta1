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
using Pregunta1.Models;

namespace Pregunta1.Controllers
{
    public class herediasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/heredias
        [Authorize]
        public IQueryable<heredia> Getheredias()
        {
            return db.heredias;
        }

        // GET: api/heredias/5
        [Authorize]
        [ResponseType(typeof(heredia))]
        public IHttpActionResult Getheredia(int id)
        {
            heredia heredia = db.heredias.Find(id);
            if (heredia == null)
            {
                return NotFound();
            }

            return Ok(heredia);
        }

        // PUT: api/heredias/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Putheredia(int id, heredia heredia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != heredia.herediaID)
            {
                return BadRequest();
            }

            db.Entry(heredia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!herediaExists(id))
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

        // POST: api/heredias
        [Authorize]
        [ResponseType(typeof(heredia))]
        public IHttpActionResult Postheredia(heredia heredia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.heredias.Add(heredia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = heredia.herediaID }, heredia);
        }

        // DELETE: api/heredias/5
        [Authorize]
        [ResponseType(typeof(heredia))]
        public IHttpActionResult Deleteheredia(int id)
        {
            heredia heredia = db.heredias.Find(id);
            if (heredia == null)
            {
                return NotFound();
            }

            db.heredias.Remove(heredia);
            db.SaveChanges();

            return Ok(heredia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool herediaExists(int id)
        {
            return db.heredias.Count(e => e.herediaID == id) > 0;
        }
    }
}