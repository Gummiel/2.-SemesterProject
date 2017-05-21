#region References

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using BestillingWebService.Models;

#endregion

namespace BestillingWebService.Controllers
{
    public class InformationController : ApiController
    {
        private readonly BestillingContext db = new BestillingContext();

        // GET: api/Information
        public IQueryable<Information> GetInformation()
        {
            return db.Information;
        }

        // GET: api/Information/5
        [ResponseType(typeof(Information))]
        public IHttpActionResult GetInformation(int id)
        {
            var information = db.Information.Find(id);
            if (information == null)
                return NotFound();

            return Ok(information);
        }

        // PUT: api/Information/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInformation(int id, Information information)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != information.ID)
                return BadRequest();

            db.Entry(information).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformationExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Information
        [ResponseType(typeof(Information))]
        public IHttpActionResult PostInformation(Information information)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Information.Add(information);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = information.ID}, information);
        }

        // DELETE: api/Information/5
        [ResponseType(typeof(Information))]
        public IHttpActionResult DeleteInformation(int id)
        {
            var information = db.Information.Find(id);
            if (information == null)
                return NotFound();

            db.Information.Remove(information);
            db.SaveChanges();

            return Ok(information);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool InformationExists(int id)
        {
            return db.Information.Count(e => e.ID == id) > 0;
        }
    }
}