using Business.Abstract;
using Business.Concrete;
using DataAccess.Conctrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            carManager.Add(new Car { Id = 5, BrandId = 2, ColorId = 3, ModelYear = 2015, DailyPrice = 180, Description = "Great car." });
            Console.WriteLine(carManager.GetById(5).Description);

            carManager.Update(carManager.GetById(5));
            carManager.Delete(carManager.GetById(5));

            Console.WriteLine("Hello World!");
        }
    }
}
