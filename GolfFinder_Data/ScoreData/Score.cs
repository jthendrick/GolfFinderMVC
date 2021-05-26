using GolfFinder_Data.CourseData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfFinder_Data.ScoreData
{
    public class Score
    {
        [Key]
        public int ScoreID { get; set; }
        public Guid OwnerID { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public int Hole1 { get; set; }
        public int ParHole1      { get; set; }
        public int Hole2 { get; set; }
        public int ParHole2 { get; set; }
        public int Hole3 { get; set; }
        public int ParHole3 { get; set; }
        public int Hole4 { get; set; }
        public int ParHole4 { get; set; }
        public int Hole5 { get; set; }
        public int ParHole5 { get; set; }
        public int Hole6 { get; set; }
        public int ParHole6 { get; set; }
        public int Hole7 { get; set; }
        public int ParHole7 { get; set; }
        public int Hole8 { get; set; }
        public int ParHole8 { get; set; }
        public int Hole9 { get; set; }
        public int ParHole9 { get; set; }
        public int Hole10 { get; set; }
        public int ParHole10 { get; set; }
        public int Hole11 { get; set; }
        public int ParHole11 { get; set; }
        public int Hole12 { get; set; }
        public int ParHole12 { get; set; }
        public int Hole13 { get; set; }
        public int ParHole13 { get; set; }
        public int Hole14 { get; set; }
        public int ParHole14 { get; set; }
        public int Hole15 { get; set; }
        public int ParHole15 { get; set; }
        public int Hole16 { get; set; }
        public int ParHole16 { get; set; }
        public int Hole17 { get; set; }
        public int ParHole17 { get; set; }
        public int Hole18 { get; set; }
        public int ParHole18 { get; set; }

        public int ParScore
        {
            get
            {
                var totalStrokes = Hole1 + Hole2 + Hole3 + Hole4 + Hole5 + Hole6 + Hole7 + Hole8 + Hole9 + Hole10 + Hole11 + Hole12 + Hole13 + Hole14 + Hole15 + Hole16 + Hole17 + Hole18;
                var overUnder = ParHole1 + ParHole2 + ParHole3 + ParHole4 + ParHole5 + ParHole6 + ParHole7 + ParHole8 + ParHole9 + ParHole10 + ParHole11 + ParHole12 + ParHole13 + ParHole14 + ParHole15 + ParHole16 + ParHole17 + ParHole18;
                var netScore = totalStrokes - overUnder;
                return netScore;
            }
        }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
