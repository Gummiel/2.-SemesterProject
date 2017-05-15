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
    public class ItemTypesController : ApiController
    {
        private readonly BestillingContext db = new BestillingContext();

        // GET: api/ItemTypes
        public IQueryable<ItemType> GetItemType()
        {
            return db.ItemType;
        }

        // GET: api/ItemTypes/5
        [ResponseType(typeof(ItemType))]
        public IHttpActionResult GetItemType(int id)
        {
            var itemType = db.ItemType.Find(id);
            if (itemType == null)
                return NotFound();

            return Ok(itemType);
        }

        // PUT: api/ItemTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItemType(int id, ItemType itemType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != itemType.ID)
                return BadRequest();

            db.Entry(itemType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemTypeExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ItemTypes
        [ResponseType(typeof(ItemType))]
        public IHttpActionResult PostItemType(ItemType itemType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.ItemType.Add(itemType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = itemType.ID}, itemType);
        }

        // DELETE: api/ItemTypes/5
        [ResponseType(typeof(ItemType))]
        public IHttpActionResult DeleteItemType(int id)
        {
            var itemType = db.ItemType.Find(id);
            if (itemType == null)
                return NotFound();

            db.ItemType.Remove(itemType);
            db.SaveChanges();

            return Ok(itemType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool ItemTypeExists(int id)
        {
            return db.ItemType.Count(e => e.ID == id) > 0;
        }
    }
}