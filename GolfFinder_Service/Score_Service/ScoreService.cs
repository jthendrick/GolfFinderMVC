using GolfFinder_Data;
using GolfFinder_Data.ScoreData;
using GolfFinder_Models.Score_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfFinder_Service.Score_Service
{
    public class ScoreService
    {
        private readonly Guid _userId;
        public ScoreService(Guid userId)
        {
            _userId = userId;
        }
        public bool AddScore(ScoreAdd model)
        {
            var entity =
                new Score()
                {
                    OwnerID = _userId,
                    Hole1 = model.Hole1,
                    ParHole1 = model.ParHole1,
                    Hole2 = model.Hole2,
                    ParHole2 = model.ParHole2,
                    Hole3 = model.Hole3,
                    ParHole3 = model.ParHole3,
                    Hole4 = model.Hole4,
                    ParHole4 = model.ParHole4,
                    Hole5 = model.Hole5,
                    ParHole5 = model.ParHole5,
                    Hole6 = model.Hole6,
                    ParHole6 = model.ParHole6,
                    Hole7 = model.Hole7,
                    ParHole7 = model.ParHole7,
                    Hole8 = model.Hole8,
                    ParHole8 = model.ParHole8,
                    Hole9 = model.Hole9,
                    ParHole9 = model.ParHole9,
                    Hole10 = model.Hole10,
                    ParHole10 = model.ParHole10,
                    Hole11 = model.Hole11,
                    ParHole11 = model.ParHole11,
                    Hole12 = model.Hole12,
                    ParHole12 = model.ParHole12,
                    Hole13 = model.Hole13,
                    ParHole13 = model.ParHole13,
                    Hole14 = model.Hole14,
                    ParHole14 = model.ParHole14,
                    Hole15 = model.Hole15,
                    ParHole15 = model.ParHole15,
                    Hole16 = model.Hole16,
                    ParHole16 = model.ParHole16,
                    Hole17 = model.Hole17,
                    ParHole17 = model.ParHole17,
                    Hole18 = model.Hole18,
                    ParHole18 = model.ParHole18


                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Scores.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ScoreList> GetScores()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Scores
                    .Where(e => e.OwnerID == _userId)
                    .Select(
                        e =>
                        new ScoreList
                        {
                            
                            Hole1 = e.Hole1,
                            ParHole1 = e.ParHole1,
                            Hole2 = e.Hole2,
                            ParHole2 = e.ParHole2,
                            Hole3 = e.Hole3,
                            ParHole3 = e.ParHole3,
                            Hole4 = e.Hole4,
                            ParHole4 = e.ParHole4,
                            Hole5 = e.Hole5,
                            ParHole5 = e.ParHole5,
                            Hole6 = e.Hole6,
                            ParHole6 = e.ParHole6,
                            Hole7 = e.Hole7,
                            ParHole7 = e.ParHole7,
                            Hole8 = e.Hole8,
                            ParHole8 = e.ParHole8,
                            Hole9 = e.Hole9,
                            ParHole9 = e.ParHole9,
                            Hole10 = e.Hole10,
                            ParHole10 = e.ParHole10,
                            Hole11 = e.Hole11,
                            ParHole11 = e.ParHole11,
                            Hole12 = e.Hole12,
                            ParHole12 = e.ParHole12,
                            Hole13 = e.Hole13,
                            ParHole13 = e.ParHole13,
                            Hole14 = e.Hole14,
                            ParHole14 = e.ParHole14,
                            Hole15 = e.Hole15,
                            ParHole15 = e.ParHole15,
                            Hole16 = e.Hole16,
                            ParHole16 = e.ParHole16,
                            Hole17 = e.Hole17,
                            ParHole17 = e.ParHole17,
                            Hole18 = e.Hole18,
                            ParHole18 = e.ParHole18

                        }
                        );
                return query.ToArray();
            }
        }
    }

}
