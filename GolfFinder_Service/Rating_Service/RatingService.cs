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
                    //RatingID = model.RatingID,
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
                            RatingID = e.RatingID,
                            Amenities = e.Amenities,
                            Cleanliness = e.Amenities,
                            Dificulty = e.Dificulty,
                            Layout = e.Layout
                        }
                        );
                return query.ToArray();
            }
        }

        public RatingDetails GetRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ratings
                    .Single(e => e.RatingID == id && e.OwnerID == _userId);
                return
                    new RatingDetails
                    {
                        RatingID = entity.RatingID,
                        Amenities = entity.Amenities,
                        Cleanliness = entity.Cleanliness,
                        Dificulty = entity.Dificulty,
                        Layout = entity.Layout
                    };
            }
        }

        public bool UpdateRating(RatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Single(e => e.RatingID == model.RatingID && e.OwnerID == _userId);

                entity.Amenities = model.Amenities;
                entity.Cleanliness = model.Cleanliness;
                entity.Dificulty = model.Layout;
                entity.Layout = model.Layout;
                
                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteRating(int ratingID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Single(e => e.RatingID == ratingID && e.OwnerID == _userId);

                ctx.Ratings.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
