using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerApp.Data;
using TravelerApp.Models;

namespace TravelerApp.Services
{
    public class EatService
    {
        private readonly Guid _userId;

        public EatService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEat(EatCreate model)
        {
            var entity =
                new Eat()
                {
                    Name = model.Name,
                    Location = model.Location,
                    Description = model.Description 

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Eats.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<EatListItem> GetEats()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Eats
                        .Select(
                             e =>
                                new EatListItem
                                {
                                    EatId = e.EatId,
                                    Name = e.Name,
                                }
                         );
                return query.ToArray();
            }
        }

        public EatDetail GetEatById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Eats
                        .Single(e => e.EatId == id);
                return
                    new EatDetail
                    {
                        EatId = entity.EatId,
                        Name = entity.Name,
                        Location = entity.Location,
                        Description= entity.Description,
                    };
            }
        }

        public EatDetail GetEatByLocation(string location)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Eats
                        .Single(e => e.Location == location);
                return
                    new EatDetail
                    {
                        EatId = entity.EatId,
                        Name = entity.Name,
                        Location = entity.Location,
                        Description = entity.Description,
                    };
            }
        }

        public bool UpdateEat(EatEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Eats
                        .Single(e => e.EatId == model.EatId);
                entity.Name = model.Name;
                entity.Location = model.Location;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEat(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Eats
                        .Single(e => e.EatId == id);

                ctx.Eats.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
