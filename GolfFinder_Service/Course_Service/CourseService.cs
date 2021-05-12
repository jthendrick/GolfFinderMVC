using GolfFinder_Data;
using GolfFinder_Data.CourseData;
using GolfFinder_Models.Course_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfFinder_Service.Course_Service
{
    public class CourseService
    {
        private readonly Guid _userId;
        public CourseService(Guid userId)
        {
            _userId = userId;
        }
        public bool AddCourse(CourseAdd model)
        {
            var entity =
                new Course()
                {
                    OwnerID = _userId,
                    CourseName = model.CourseName,
                    CourseAddress = model.CourseAddress,
                    NineHoleCost = model.NineHoleCost,
                    EighteenHoleCost = model.EighteenHoleCost,
                    AlcoholFriendly = model.AlcoholFriendly,
                    BeginnerFriendly = model.BeginnerFriendly
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Courses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CourseList> GetCourses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Courses
                    .Where(e => e.OwnerID == _userId)
                    .Select(
                        e =>
                        new CourseList
                        {
                            CourseID = e.CourseID,
                            CourseName = e.CourseName,
                            CourseAddress = e.CourseAddress
                        }
                        );
                return query.ToArray();
            }
        }

        public CourseDetails GetCourseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Courses
                    .Single(e => e.CourseID == id && e.OwnerID == _userId);
                return
                    new CourseDetails
                    {
                        CourseID = entity.CourseID,
                        CourseName = entity.CourseName,
                        CourseAddress = entity.CourseAddress,
                        NineHoleCost = entity.NineHoleCost,
                        EighteenHoleCost = entity.EighteenHoleCost,
                        AlcoholFriendly = entity.AlcoholFriendly,
                        BeginnerFriendly = entity.BeginnerFriendly
                    };
            }
        }

        public bool UpdateCourse(CourseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Courses.Single(e => e.CourseID == model.CourseID && e.OwnerID == _userId);

                entity.CourseName = model.CourseName;
                entity.CourseAddress = model.CourseAddress;
                entity.NineHoleCost = model.NineHoleCost;
                entity.EighteenHoleCost = model.EighteenHoleCost;
                entity.BeginnerFriendly = model.BeginnerFriendly;
                entity.AlcoholFriendly = model.AlcoholFriendly;
                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteCourse(int courseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Courses.Single(e => e.CourseID == courseId && e.OwnerID == _userId);

                ctx.Courses.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }

}
