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
    public class PaymentsController : ApiController
    {
        private readonly BestillingContext db = new BestillingContext();

        // GET: api/Payments
        public IQueryable<Payment> GetPayment()
        {
            return db.Payment;
        }

        // GET: api/Payments/5
        [ResponseType(typeof(Payment))]
        public IHttpActionResult GetPayment(int id)
        {
            var payment = db.Payment.Find(id);
            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        // PUT: api/Payments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPayment(int id, Payment payment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != payment.ID)
                return BadRequest();

            db.Entry(payment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Payments
        [ResponseType(typeof(Payment))]
        public IHttpActionResult PostPayment(Payment payment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Payment.Add(payment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = payment.ID}, payment);
        }

        // DELETE: api/Payments/5
        [ResponseType(typeof(Payment))]
        public IHttpActionResult DeletePayment(int id)
        {
            var payment = db.Payment.Find(id);
            if (payment == null)
                return NotFound();

            db.Payment.Remove(payment);
            db.SaveChanges();

            return Ok(payment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool PaymentExists(int id)
        {
            return db.Payment.Count(e => e.ID == id) > 0;
        }
    }
}