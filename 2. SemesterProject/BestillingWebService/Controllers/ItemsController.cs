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
    public class ItemsController : ApiController
    {
        private readonly BestillingContext db = new BestillingContext();

        // GET: api/Items
        public IQueryable<Item> GetItem()
        {
            return db.Item;
        }

        // GET: api/Items/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult GetItem(int id)
        {
            var item = db.Item.Find(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // PUT: api/Items/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItem(int id, Item item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != item.ID)
                return BadRequest();

            db.Entry(item).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Items
        [ResponseType(typeof(Item))]
        public IHttpActionResult PostItem(Item item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Item.Add(item);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = item.ID}, item);
        }

        // DELETE: api/Items/5
        [ResponseType(typeof(Item))]
        public IHttpActionResult DeleteItem(int id)
        {
            var item = db.Item.Find(id);
            if (item == null)
                return NotFound();

            db.Item.Remove(item);
            db.SaveChanges();

            return Ok(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool ItemExists(int id)
        {
            return db.Item.Count(e => e.ID == id) > 0;
        }
    }
}