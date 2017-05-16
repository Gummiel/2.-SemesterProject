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
    public class ProductCatagoriesController : ApiController
    {
        private readonly BestillingContext db = new BestillingContext();

        // GET: api/ProductCatagories
        public IQueryable<ProductCatagory> GetProductCatagory()
        {
            return db.ProductCatagory;
        }

        // GET: api/ProductCatagories/5
        [ResponseType(typeof(ProductCatagory))]
        public IHttpActionResult GetProductCatagory(int id)
        {
            var productCatagory = db.ProductCatagory.Find(id);
            if (productCatagory == null)
                return NotFound();

            return Ok(productCatagory);
        }

        // PUT: api/ProductCatagories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductCatagory(int id, ProductCatagory productCatagory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != productCatagory.ID)
                return BadRequest();

            db.Entry(productCatagory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCatagoryExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProductCatagories
        [ResponseType(typeof(ProductCatagory))]
        public IHttpActionResult PostProductCatagory(ProductCatagory productCatagory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.ProductCatagory.Add(productCatagory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = productCatagory.ID}, productCatagory);
        }

        // DELETE: api/ProductCatagories/5
        [ResponseType(typeof(ProductCatagory))]
        public IHttpActionResult DeleteProductCatagory(int id)
        {
            var productCatagory = db.ProductCatagory.Find(id);
            if (productCatagory == null)
                return NotFound();

            db.ProductCatagory.Remove(productCatagory);
            db.SaveChanges();

            return Ok(productCatagory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool ProductCatagoryExists(int id)
        {
            return db.ProductCatagory.Count(e => e.ID == id) > 0;
        }
    }
}