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
using BestillingWebService;

namespace BestillingWebService.Controllers
{
    public class ReceiptsController : ApiController
    {
        private BestillingContext db = new BestillingContext();

        // GET: api/Receipts
        public IQueryable<Receipt> GetReceipt()
        {
            return db.Receipt;
        }

        // GET: api/Receipts/5
        [ResponseType(typeof(Receipt))]
        public IHttpActionResult GetReceipt(int id)
        {
            Receipt receipt = db.Receipt.Find(id);
            if (receipt == null)
            {
                return NotFound();
            }

            return Ok(receipt);
        }

        // PUT: api/Receipts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReceipt(int id, Receipt receipt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != receipt.ID)
            {
                return BadRequest();
            }

            db.Entry(receipt).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptExists(id))
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

        // POST: api/Receipts
        [ResponseType(typeof(Receipt))]
        public IHttpActionResult PostReceipt(Receipt receipt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Receipt.Add(receipt);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = receipt.ID }, receipt);
        }

        // DELETE: api/Receipts/5
        [ResponseType(typeof(Receipt))]
        public IHttpActionResult DeleteReceipt(int id)
        {
            Receipt receipt = db.Receipt.Find(id);
            if (receipt == null)
            {
                return NotFound();
            }

            db.Receipt.Remove(receipt);
            db.SaveChanges();

            return Ok(receipt);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReceiptExists(int id)
        {
            return db.Receipt.Count(e => e.ID == id) > 0;
        }
    }
}