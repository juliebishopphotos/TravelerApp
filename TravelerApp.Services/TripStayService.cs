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


        public TripStayDetail GetTripStayById(int tripId, int stayId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TripStays
                        .Single(e => e.TripId == tripId && e.StayId == stayId);
                return
                    new TripStayDetail
                    {
                        TripName = entity.Trip.Name,
                        StayName = entity.Stay.Name,
                    };
            }
        }

        public bool DeleteTripStay(int tripId ,int stayId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TripStays
                        .Single(e => e.TripId == tripId && e.StayId == stayId);

                ctx.TripStays.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
