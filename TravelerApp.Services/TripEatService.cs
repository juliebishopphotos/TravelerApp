using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerApp.Data;
using TravelerApp.Models;

namespace TravelerApp.Services
{
    public class TripEatService
    {
        private readonly Guid _userId;

        public TripEatService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTripEat(TripEatCreate model)
        {
            var entity =
                new TripEat()
                {
                    TripId = model.TripId,
                    EatId = model.EatId

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.TripEats.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public TripEatDetail GetTripEatById(int tripId, int eatId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TripEats
                        .Single(e => e.TripId == tripId && e.EatId == eatId);
                return
                    new TripEatDetail
                    {
                        TripName = entity.Trip.Name,
                        EatName = entity.Eat.Name,
                    };
            }
        }

        public bool DeleteTripEat(int eatId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TripEats
                        .Single(e => e.EatId == eatId);

                ctx.TripEats.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
