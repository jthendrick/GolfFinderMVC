using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfFinder_Models.Course_Models
{
    public class CourseDetails
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseAddress { get; set; }
        public bool BeginnerFriendly { get; set; }
        public bool AlcoholFriendly { get; set; }
        public decimal NineHoleCost { get; set; }
        public decimal EighteenHoleCost { get; set; }
    }
}
