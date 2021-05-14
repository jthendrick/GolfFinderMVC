using GolfFinder_Data;
using GolfFinder_Data.RatingsData;
using GolfFinder_Models.Rating_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfFinder_Service.Rating_Service
{
    public class RatingService
    {
        private readonly Guid _userId;
        public RatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool AddRating(RatingAdd model)
        {
            var entity =
                new Rating()
                {
                    OwnerID = _userId,
                    //Course = model.Course,
                    //CourseID=model.CourseID,
                    Cleanliness = model.Cleanliness,
                    Amenities = model.Amenities,
                    Dificulty = model.Dificulty,
                    Layout = model.Layout,
                    
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RatingList> GetRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Ratings
                    .Where(e => e.OwnerID == _userId)
                    .Select(
                        e =>
                        new RatingList
                        {
                            //Course = e.Course,
                            Amenities = e.Amenities,
                            Cleanliness = e.Amenities,
                            Dificulty = e.Dificulty,
                            Layout = e.Layout
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
