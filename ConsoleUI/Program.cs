using Business.Concrete;
using Core.Utilities.Results.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User { Email = "kivanc.frh@gmail.com", Password = "123" };
            Car car = new Car { BrandId = 2, ModelId = 2, ColorId = 3, DailyPrice = 750, ModelYear = "2021", Description = "Kıvanç 2" };

            Login(user);
            AddCar(car);
            GetCarByBrandId(3);
            JoinTest();
        }

        private static void Login(User user)
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.CheckUser(user);

            if (result.Success)
            {
                Console.WriteLine(result.Message);
                UserOperations();
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UserOperations()
        {
            Console.WriteLine("---------------İşlemler---------------");
            Console.WriteLine("1) Add Car");
            Console.WriteLine("2) Add Customer");
            Console.WriteLine("3) Rent a Car \n");
            Console.Write("Bir işlem seçin = ");
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

        private static void GetCarByBrandId(int id)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarsByBrandId(id);

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandId);
                }
                Console.WriteLine(result.Message);
            }
        }

        private static void AddCar(Car car)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            var result = carManager.AddCar(car);

            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
