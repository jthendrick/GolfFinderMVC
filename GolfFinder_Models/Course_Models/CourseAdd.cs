using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfFinder_Models.Course_Models
{
    public class CourseAdd
    {
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string CourseAddress { get; set; }
        public bool BeginnerFriendly { get; set; }
        public bool AlcoholFriendly { get; set; }
        [Required]
        public decimal NineHoleCost { get; set; }
        [Required]
        public decimal EighteenHoleCost { get; set; }
    }
}
