﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using ReCapContext context = new ReCapContext();

            var addedEntity = context.Entry(entity);

            if (entity.DailyPrice > 0)
            {
                if (entity.Description.Length >= 2)
                {
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Car name must be at least 2 characters");
                }
            }
            else
            {
                Console.WriteLine("The daily price of the car must be greater than 0.");
            }
        }

        public void Update(Car entity)
        {
            using ReCapContext context = new ReCapContext();

            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Car entity)
        {
            using ReCapContext context = new ReCapContext();

            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using ReCapContext context = new ReCapContext();

            return context.Set<Car>().SingleOrDefault(filter);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using ReCapContext context = new ReCapContext();

            return filter == null
                ? context.Set<Car>().ToList()
                : context.Set<Car>().Where(filter).ToList();
        }
    }
}
