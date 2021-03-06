using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerApp.Data;
using TravelerApp.Models;

namespace TravelerApp.Services
{
    public class StayService
    {
        private readonly Guid _userId;

        public StayService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateStay(StayCreate model)
        {
            var entity =
                new Stay()
                {
                    Name = model.Name,
                    Location = model.Location,
                    TypeOfLodging = model.TypeOfLodging

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Stays.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<StayListItem> GetStays()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Stays
                        .Select(
                             e =>
                                new StayListItem
                                {
                                    StayId = e.StayId,
                                    Name = e.Name,
                                    Location = e.Location
                                }
                         );
                return query.ToArray();
            }
        }

        public StayDetail GetStayById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Stays
                        .Single(e => e.StayId == id);
                return
                    new StayDetail
                    {
                        StayId = entity.StayId,
                        Name = entity.Name,
                        Location = entity.Location,
                        TypeOfLodging = entity.TypeOfLodging,
                    };
            }
        }

        public StayDetail GetStayByLocation(string location)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Stays
                        .Single(e => e.Location == location);
                return
                    new StayDetail
                    {
                        StayId = entity.StayId,
                        Name = entity.Name,
                        Location = entity.Location,
                        TypeOfLodging = entity.TypeOfLodging,
                    };
            }
        }

        public bool UpdateStay(StayEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Stays
                        .Single(e => e.StayId == model.StayId);
                entity.Name = model.Name;
                entity.Location = model.Location;
                entity.TypeOfLodging = model.TypeOfLodging;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteStay(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Stays
                        .Single(e => e.StayId == id);

                ctx.Stays.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
