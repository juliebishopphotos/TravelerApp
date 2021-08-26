using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerApp.Data;
using TravelerApp.Models;

namespace TravelerApp.Services
{
    public class TripStayService
    {
        private readonly Guid _userId;

        public TripStayService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTripStay(TripStayCreate model)
        {
            var entity =
                new TripStay()
                {
                    TripId = model.TripId,
                    StayId = model.StayId

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.TripStays.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTripStay(TripStayDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                      .TripStays
                      .Single(e => e.TripId == model.TripId && e.StayId == model.StayId);
                {
                    entity.TripId = model.TripId;
                    entity.StayId = model.StayId;
                };
                ctx.TripStays.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
