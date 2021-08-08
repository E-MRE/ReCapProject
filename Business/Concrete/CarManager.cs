using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal carDal;

        public CarManager(ICarDal carDal)
        {
            this.carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
                carDal.Add(car);
            else
                Console.WriteLine("Araba ismi en az 2 karakter olmalıdır ve günlük fiyat 0'dan büyük olmalıdır");
        }

        public void Delete(Car car)
        {
            carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return carDal.Get(c => c.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            carDal.Update(car);
        }
    }
}
