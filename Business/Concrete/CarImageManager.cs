using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarId));
            if (result != null)
                return result;

            var imagePathResult = FileUpload.Add(formFile);
            if (!imagePathResult.Success)
                return imagePathResult;

            carImage.ImagePath = imagePathResult.Data;
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = GetCarImagePathIfExistsById(carImage.Id);
            if (!result.Success)
                return result;

            var deleteImageResult = FileUpload.Delete(result.Data);
            if (!deleteImageResult.Success)
                return deleteImageResult;

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ItemsListed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id), Messages.GetItem);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var carImages = _carImageDal.GetAll(c => c.CarId == carId);
            foreach (var carImage in carImages)
            {
                if (string.IsNullOrEmpty(carImage.ImagePath))
                    carImage.ImagePath = FileUpload.GetDefaultImagePath();
            }


            return new SuccessDataResult<List<CarImage>>(carImages, Messages.ItemsListed);
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var resultImagePath = GetCarImagePathIfExistsById(carImage.Id);
            if (!resultImagePath.Success)
                return resultImagePath;

            var deleteOldImageAndUpdate = FileUpload.Update(formFile, resultImagePath.Data);
            if (!deleteOldImageAndUpdate.Success)
                return deleteOldImageAndUpdate;

            carImage.ImagePath = deleteOldImageAndUpdate.Data;
            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.UpdatedSuccess);
        }

        private IResult CheckIfCarImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }

        private IDataResult<string> GetCarImagePathIfExistsById(int id)
        {
            var carImage = _carImageDal.Get(c => c.Id == id);

            if (carImage == null)
                return new ErrorDataResult<string>(Messages.CarImageNotFound, Messages.CarImageNotFound);

            return new SuccessDataResult<string>(carImage.ImagePath);
        }
    }
}
