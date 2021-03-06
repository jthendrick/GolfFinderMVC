using GolfFinder_Data.RatingsData;
using GolfFinder_Data.ScoreData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfFinder_Data.CourseData
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        
        public string CourseName { get; set; }
       
        public string CourseAddress { get; set; }
        public bool BeginnerFriendly { get; set; }
        public bool AlcoholFriendly { get; set; }
        
        public decimal NineHoleCost { get; set; }
    
        public decimal EighteenHoleCost { get; set; }

        public virtual List<Score> Score { get; set; } = new List<Score>();

        public virtual List<Rating> Rating { get; set; } = new List<Rating>();
    }
}
