using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerApp.Data;
using TravelerApp.Models;

namespace TravelerApp.Services
{
    public class TripSeeService
    {
        private readonly Guid _userId;

        public TripSeeService(Guid userId) 
        {
            _userId = userId;
        }

        public bool CreateTripSee(TripSeeCreate model)
        {
            var entity =
                new TripSee()
                {
                    TripId = model.TripId,
                    SeeId = model.SeeId

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.TripSees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeleteTripSee(TripSeeDetail model) 
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                      .TripSees
                      .Single(e => e.TripId == model.TripId && e.SeeId == model.SeeId);
                {
                    entity.TripId = model.TripId;
                    entity.SeeId = model.SeeId;
                };
                ctx.TripSees.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
