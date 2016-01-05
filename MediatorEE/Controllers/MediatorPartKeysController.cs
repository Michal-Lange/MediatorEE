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
using MediatorEE.Models;
using SecureSystemsMediator.Models;

namespace MediatorEE.Controllers
{
    public class MediatorPartKeysController : ApiController
    {
        private MedStorageContext db = new MedStorageContext();

        // GET: api/MediatorPartKeys
        public IQueryable<MediatorPartKey> GetMediatorPartKeys()
        {
            return db.MediatorPartKeys;
        }

        // GET: api/MediatorPartKeys/5
        [ResponseType(typeof(MediatorPartKey))]
        public IHttpActionResult GetMediatorPartKey(string id)
        {
            MediatorPartKey mediatorPartKey = db.MediatorPartKeys.Find(id);
            if (mediatorPartKey == null)
            {
                return NotFound();
            }

            return Ok(mediatorPartKey);
        }

        // PUT: api/MediatorPartKeys/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMediatorPartKey(string id, MediatorPartKey mediatorPartKey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mediatorPartKey.UserId)
            {
                return BadRequest();
            }

            db.Entry(mediatorPartKey).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediatorPartKeyExists(id))
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

        // POST: api/MediatorPartKeys
        [ResponseType(typeof(MediatorPartKey))]
        public IHttpActionResult PostMediatorPartKey(MediatorPartKey mediatorPartKey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MediatorPartKeys.Add(mediatorPartKey);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MediatorPartKeyExists(mediatorPartKey.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mediatorPartKey.UserId }, mediatorPartKey);
        }

        // DELETE: api/MediatorPartKeys/5
        [ResponseType(typeof(MediatorPartKey))]
        public IHttpActionResult DeleteMediatorPartKey(string id)
        {
            MediatorPartKey mediatorPartKey = db.MediatorPartKeys.Find(id);
            if (mediatorPartKey == null)
            {
                return NotFound();
            }

            db.MediatorPartKeys.Remove(mediatorPartKey);
            db.SaveChanges();

            return Ok(mediatorPartKey);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MediatorPartKeyExists(string id)
        {
            return db.MediatorPartKeys.Count(e => e.UserId == id) > 0;
        }
    }
}