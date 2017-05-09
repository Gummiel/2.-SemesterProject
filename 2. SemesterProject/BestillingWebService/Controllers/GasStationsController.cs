#region References

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

#endregion

namespace BestillingWebService.Controllers
{
    public class GasStationsController : ApiController
    {
        private readonly BestillingContext db = new BestillingContext();

        // GET: api/GasStations
        public IQueryable<GasStation> GetGasStation()
        {
            return db.GasStation;
        }

        // GET: api/GasStations/5
        [ResponseType(typeof(GasStation))]
        public IHttpActionResult GetGasStation(int id)
        {
            var gasStation = db.GasStation.Find(id);
            if (gasStation == null)
                return NotFound();

            return Ok(gasStation);
        }

        // PUT: api/GasStations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGasStation(int id, GasStation gasStation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != gasStation.ID)
                return BadRequest();

            db.Entry(gasStation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GasStationExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GasStations
        [ResponseType(typeof(GasStation))]
        public IHttpActionResult PostGasStation(GasStation gasStation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.GasStation.Add(gasStation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GasStationExists(gasStation.ID))
                    return Conflict();
                throw;
            }

            return CreatedAtRoute("DefaultApi", new {id = gasStation.ID}, gasStation);
        }

        // DELETE: api/GasStations/5
        [ResponseType(typeof(GasStation))]
        public IHttpActionResult DeleteGasStation(int id)
        {
            var gasStation = db.GasStation.Find(id);
            if (gasStation == null)
                return NotFound();

            db.GasStation.Remove(gasStation);
            db.SaveChanges();

            return Ok(gasStation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool GasStationExists(int id)
        {
            return db.GasStation.Count(e => e.ID == id) > 0;
        }
    }
}