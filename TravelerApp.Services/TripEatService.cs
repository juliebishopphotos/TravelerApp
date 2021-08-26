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


        public bool DeleteTripEat(TripEatDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                      .TripEats
                      .Single(e => e.TripId == model.TripId && e.EatId == model.EatId);
                {
                    entity.TripId = model.TripId;
                    entity.EatId = model.EatId;
                };
                ctx.TripEats.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }   
}
