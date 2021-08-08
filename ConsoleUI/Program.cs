using Business.Abstract;
using Business.Concrete;
using DataAccess.Conctrete.EntityFramework;
using DataAccess.Conctrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Sarı" });

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            colorManager.Update(new Color { ColorId = 3, ColorName = "Lacivert" });

            Console.WriteLine(colorManager.GetById(2));

            colorManager.Delete(new Color { ColorId = 5 });
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Ferrari" });

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            brandManager.Update(new Brand { BrandId = 3, BrandName = "Ferrari" });

            Console.WriteLine(brandManager.GetById(1));

            brandManager.Delete(new Brand { BrandId = 5 });
        }

        private static void CarTest()
        {
            var carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 1, ColorId = 2, ModelYear = 2016, DailyPrice = 200, Description = "My Car" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            carManager.Update(new Car { Id = 1, BrandId = 1, ColorId = 2, ModelYear = 2016, DailyPrice = 200, Description = "E-250" });

            Console.WriteLine(carManager.GetById(1).Description);

            carManager.Delete(new Car { Id = 2 });

            foreach (var carDetail in carManager.GetCarDetails())
            {
                Console.WriteLine(carDetail.CarName + "  -  " + carDetail.BrandName + "  -  " + carDetail.ColorName);
            }
        }
    }
}
