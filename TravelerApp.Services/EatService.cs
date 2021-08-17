﻿using System;
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
        public bool CreateEat(EatCreate model)
        {
            var entity =
                new Eat()
                {
                    Name = model.Name,
                    Location = model.Location,
                    RestaurantType = model.RestaurantType

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
                                    Id = e.Id,
                                    Name = e.Name,
                                    Location = e.Location,
                                    RestaurantTypeId = (int)e.RestaurantTypeId
                                }
                         );
                return query.ToArray();
            }
        }

        public EatDetail GetEatByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Eats
                        .Single(e => e.Id == id);
                return
                    new EatDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Location = entity.Location,
                        RestaurantTypeId= (int)entity.RestaurantTypeId,
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
                        Id = entity.Id,
                        Name = entity.Name,
                        Location = entity.Location,
                        RestaurantTypeId = (int)entity.RestaurantTypeId,
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
                        .Single(e => e.Id == model.Id);
                entity.Name = model.Name;
                entity.Location = model.Location;
                entity.RestaurantType = model.RestaurantType;

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
                        .Single(e => e.Id == id);

                ctx.Eats.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
