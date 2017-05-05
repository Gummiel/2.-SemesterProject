using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatNow.Model
{
    class Review
    {
        public int reviewID { get; set; }
        public string reviewDescription { get; set; }
        public int reviewStars { get; set; }

        public Review(int reviewId, string reviewDescription, int reviewStars)
        {
            reviewID = reviewId;
            this.reviewDescription = reviewDescription;
            this.reviewStars = reviewStars;
        }
    }
}
