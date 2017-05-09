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
    public class CustomersController : ApiController
    {
        private readonly BestillingContext db = new BestillingContext();

        // GET: api/Customers
        public IQueryable<Customer> GetCustomer()
        {
            return db.Customer;
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = db.Customer.Find(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != customer.ID)
                return BadRequest();

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Customer.Add(customer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CustomerExists(customer.ID))
                    return Conflict();
                throw;
            }

            return CreatedAtRoute("DefaultApi", new {id = customer.ID}, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = db.Customer.Find(id);
            if (customer == null)
                return NotFound();

            db.Customer.Remove(customer);
            db.SaveChanges();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customer.Count(e => e.ID == id) > 0;
        }
    }
}