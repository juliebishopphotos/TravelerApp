using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerApp.Data;
using TravelerApp.Models;

namespace TravelerApp.Services
{
    public class TripService
    {
        private readonly Guid _userId;

        public TripService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTrip(TripCreate model)
        {
            var entity =
                new Trip()
                {
                    UserId = _userId,
                    Name = model.Name,
                    Location = model.Location
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Trips.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TripListItem> GetTrips()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Trips
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                        new TripListItem
                        {
                            TripId = e.TripId,
                            Name = e.Name,
                        }
                        );
                return query.ToArray();
            }
        }

        public TripDetail GetTripById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                     .Trips
                     .Single(e => e.TripId == id);
                ICollection<EatListItem> eats = new List<EatListItem>();
                ICollection<SeeListItem> sees = new List<SeeListItem>();
                ICollection<StayListItem> stays = new List<StayListItem>();
                return
                    new TripDetail
                    {
                        TripId = entity.TripId,
                        Name = entity.Name,
                        Location = entity.Location,
                        Eats = eats,
                        Sees = sees,
                        Stays = stays
                    };
            }

        }


        public bool UpdateTrip(TripEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Trips
                    .Single(e => e.TripId == model.TripId && e.UserId == _userId);

                entity.TripId = model.TripId;
                entity.Name = model.Name;
                entity.Location = model.Location;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTrip(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Trips
                    .Single(e => e.TripId == id && e.UserId == _userId);

                ctx.Trips.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
