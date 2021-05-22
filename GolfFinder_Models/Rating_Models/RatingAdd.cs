using GolfFinder_Data.CourseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfFinder_Models.Rating_Models
{
    public class RatingAdd
    {
        //[ForeignKey(nameof(Course))]
        public int RatingID { get; set; }
        //public virtual Course Course { get; set; }
        [Required, Range(0, 10)]
        public int Cleanliness { get; set; }

        [Required, Range(0, 10)]
        public int Layout { get; set; }

        [Required, Range(0, 10)]
        public int Dificulty { get; set; }

        [Required, Range(0, 10)]
        public int Amenities { get; set; }
    }
}
