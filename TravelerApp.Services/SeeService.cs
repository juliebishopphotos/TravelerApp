using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerApp.Data;
using TravelerApp.Models;

namespace TravelerApp.Services
{
    public class SeeService
    {
        private readonly Guid _userId;

        public SeeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSee(SeeCreate model)
        {
            var entity =
                new See()
                {
                    Name = model.Name,
                    Location = model.Location,
                    Description = model.Description

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<SeeListItem> GetSees() 
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sees
                        .Select(
                             e =>
                                new SeeListItem
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                }
                         );
                return query.ToArray();
            }
        }

        public SeeDetail GetSeeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sees
                        .Single(e => e.Id == id);
                return
                    new SeeDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Location = entity.Location,
                        Description = entity.Description,
                    };
            }
        }

        public SeeDetail GetSeeByLocation(string location)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sees
                        .Single(e => e.Location == location);
                return
                    new SeeDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Location = entity.Location,
                        Description = entity.Description,
                    };
            }
        }

        public bool UpdateSee(SeeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sees
                        .Single(e => e.Id == model.Id);
                entity.Name = model.Name;
                entity.Location = model.Location;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSee(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sees
                        .Single(e => e.Id == id);

                ctx.Sees.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
