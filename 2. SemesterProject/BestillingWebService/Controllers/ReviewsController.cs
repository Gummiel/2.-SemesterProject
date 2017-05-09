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
    public class ReviewsController : ApiController
    {
        private readonly BestillingContext db = new BestillingContext();

        // GET: api/Reviews
        public IQueryable<Review> GetReview()
        {
            return db.Review;
        }

        // GET: api/Reviews/5
        [ResponseType(typeof(Review))]
        public IHttpActionResult GetReview(int id)
        {
            var review = db.Review.Find(id);
            if (review == null)
                return NotFound();

            return Ok(review);
        }

        // PUT: api/Reviews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReview(int id, Review review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != review.ID)
                return BadRequest();

            db.Entry(review).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
                    return NotFound();
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Reviews
        [ResponseType(typeof(Review))]
        public IHttpActionResult PostReview(Review review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Review.Add(review);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ReviewExists(review.ID))
                    return Conflict();
                throw;
            }

            return CreatedAtRoute("DefaultApi", new {id = review.ID}, review);
        }

        // DELETE: api/Reviews/5
        [ResponseType(typeof(Review))]
        public IHttpActionResult DeleteReview(int id)
        {
            var review = db.Review.Find(id);
            if (review == null)
                return NotFound();

            db.Review.Remove(review);
            db.SaveChanges();

            return Ok(review);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

        private bool ReviewExists(int id)
        {
            return db.Review.Count(e => e.ID == id) > 0;
        }
    }
}