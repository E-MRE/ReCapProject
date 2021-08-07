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


            var carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
