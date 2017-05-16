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
    public class OrderItemsController : ApiController
    {
        private readonly BestillingContext db = new BestillingContext();

        // GET: api/OrderItems
        public IQueryable<OrderItem> GetOrderItem()
        {
            return db.OrderItem;
        }

        // GET: api/OrderItems/5
        [ResponseType(typeof(OrderItem))]
        public IHttpActionResult GetOrderItem(int id)
        {
            var orderItem = db.OrderItem.Find(id);
            if (orderItem == null)
                return NotFound();

            return Ok(orderItem);
        }

        // PUT: api/OrderItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderItem(int id, OrderItem orderItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != orderItem.ID)
                return BadRequest();

            db.Entry(orderItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OrderItems
        [ResponseType(typeof(OrderItem))]
        public IHttpActionResult PostOrderItem(OrderItem orderItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.OrderItem.Add(orderItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = orderItem.ID}, orderItem);
        }

        // DELETE: api/OrderItems/5
        [ResponseType(typeof(OrderItem))]
        public IHttpActionResult DeleteOrderItem(int id)
        {
            var orderItem = db.OrderItem.Find(id);
            if (orderItem == null)
                return NotFound();

            db.OrderItem.Remove(orderItem);
            db.SaveChanges();

            return Ok(orderItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool OrderItemExists(int id)
        {
            return db.OrderItem.Count(e => e.ID == id) > 0;
        }
    }
}