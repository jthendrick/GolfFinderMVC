using GolfFinder_Data.CourseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfFinder_Models.Rating_Models
{
    public class RatingDetails
    {
        //public virtual Course Course { get; set; }
        public int RatingID { get; set; }
        public int Cleanliness { get; set; }

        public int Layout { get; set; }

        public int Dificulty { get; set; }

        public int Amenities { get; set; }
    }
}
