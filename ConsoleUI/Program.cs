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
            AddCar();
            //GetCarByBrandId();


            //JoinTest();

        }

        private static void JoinTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + " / " + car.BrandName);
                }
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarByBrandId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarsByBrandId(3);

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CompanyId);
                }
                Console.WriteLine(result.Message);
            }
        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car { CompanyId = 1, BrandId = 2, ColorId = 3, CountryId = 2, DailyPrice = 750, Year = "2021", Description = "Kıvanç 2" };
            
            var result = carManager.AddCar(car);

            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
