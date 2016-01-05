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
using MediatorEE.Models;
using SecureSystemsMediator.Models;

namespace MediatorEE.Controllers
{
    public class MediatorPartKeysAsyncController : ApiController
    {
        private MedStorageContext db = new MedStorageContext();

        // GET: api/MediatorPartKeysAsync
        public IQueryable<MediatorPartKey> GetMediatorPartKeys()
        {
            return db.MediatorPartKeys;
        }

        // GET: api/MediatorPartKeysAsync/5
        [ResponseType(typeof(MediatorPartKey))]
        public async Task<IHttpActionResult> GetMediatorPartKey(string id)
        {
            MediatorPartKey mediatorPartKey = await db.MediatorPartKeys.FindAsync(id);
            if (mediatorPartKey == null)
            {
                return NotFound();
            }

            return Ok(mediatorPartKey);
        }

        // PUT: api/MediatorPartKeysAsync/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMediatorPartKey(string id, MediatorPartKey mediatorPartKey)
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
                await db.SaveChangesAsync();
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

        // POST: api/MediatorPartKeysAsync
        [ResponseType(typeof(MediatorPartKey))]
        public async Task<IHttpActionResult> PostMediatorPartKey(MediatorPartKey mediatorPartKey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MediatorPartKeys.Add(mediatorPartKey);

            try
            {
                await db.SaveChangesAsync();
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

        // DELETE: api/MediatorPartKeysAsync/5
        [ResponseType(typeof(MediatorPartKey))]
        public async Task<IHttpActionResult> DeleteMediatorPartKey(string id)
        {
            MediatorPartKey mediatorPartKey = await db.MediatorPartKeys.FindAsync(id);
            if (mediatorPartKey == null)
            {
                return NotFound();
            }

            db.MediatorPartKeys.Remove(mediatorPartKey);
            await db.SaveChangesAsync();

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