using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelerApp.Data;
using TravelerApp.Models;

namespace TravelerApp.Services
{
    public class RestaurantTypeService
    {
        private readonly Guid _userId;

        public RestaurantTypeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEat(RestaurantTypeCreate model)
        {
            var entity =
                new RestaurantType()
                {
                    Description = model.Description
                    
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.RestaurantTypes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RestaurantTypeListItem> GetRestaurantTypes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .RestaurantTypes
                        .Select(
                             e =>
                                new RestaurantTypeListItem
                                {
                                    RestaurantTypeId = e.RestaurantTypeId,
                                    Description = e.Description,
                                }
                         );
                return query.ToArray();
            }
        }

        public RestaurantTypeDetail GetRestaurantTypeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RestaurantTypes
                        .Single(e => e.RestaurantTypeId == id);
                return
                    new RestaurantTypeDetail
                    {
                        RestaurantTypeId = entity.RestaurantTypeId,
                        Description = entity.Description,
                    };
            }
        }

        public RestaurantTypeDetail GetRestaurantTypeByDescription(string description)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RestaurantTypes
                        .Single(e => e.Description == description);
                return
                    new RestaurantTypeDetail
                    {
                        RestaurantTypeId = entity.RestaurantTypeId,
                        Description = entity.Description,
                    };
            }
        }

        public bool UpdateRestaurantType(RestaurantTypeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RestaurantTypes
                        .Single(e => e.RestaurantTypeId == model.RestaurantTypeId);
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeleteRestaurantType(int id)
        { 
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .RestaurantTypes
                        .Single(e => e.RestaurantTypeId == id);

                ctx.RestaurantTypes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
