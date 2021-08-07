﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Conctrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2019, DailyPrice = 650, Description = "Nice car."},
                new Car{Id = 2, BrandId = 2, ColorId = 2, ModelYear = 2015, DailyPrice = 500, Description = "Nice car."},
                new Car{Id = 3, BrandId = 2, ColorId = 1, ModelYear = 2013, DailyPrice = 300, Description = "Nice car."},
                new Car{Id = 4, BrandId = 1, ColorId = 2, ModelYear = 2020, DailyPrice = 750, Description = "Nice car."}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.First(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.First(c => c.Id == id);
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.First(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
