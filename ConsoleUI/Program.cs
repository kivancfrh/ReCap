using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddCar();
            //GetCarByBrandId();


            JoinTest();

        }

        private static void JoinTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarId + " / " + car.BrandName);
            }
        }

        private static void GetCarByBrandId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(car.CompanyId);
            }
        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.AddCar(new Car { CompanyId = 2, BrandId = 1, ColorId = 4, CountryId = 1, DailyPrice = 800, Year = "2020", Description = "Kıvanç" });
        }
    }
}
