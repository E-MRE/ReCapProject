using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            carDal.Delete(car);
            return new ErrorResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(carDal.Get(c => c.Id == id), Messages.GetCar);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(carDal.GetCarDetails(), Messages.CarDetailsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(carDal.GetAll(c => c.BrandId == id), Messages.CarsListedByBrand);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(carDal.GetAll(c => c.ColorId == id), Messages.CarsListedByColor);
        }

        public IResult Update(Car car)
        {
            carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
