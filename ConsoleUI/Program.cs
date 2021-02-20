using Business.Concrete;
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
            
            User user = Login();



            Console.WriteLine("---------------İşlemler---------------");



            //AddCar();
            //GetCarByBrandId();


            //JoinTest();

        }

        private static User Login()
        {
            User user = new User();
            Console.WriteLine("---------------LOGIN---------------");
            Console.Write("Mail Adresi = ");
            user.Email = Console.ReadLine();
            Console.Write("Şifre = ");
            user.LastName = Console.ReadLine();
            return user;

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
                    Console.WriteLine(car.ColorId);
                }
                Console.WriteLine(result.Message);
            }
        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car { BrandId = 2, ColorId = 3, DailyPrice = 750, ModelYear = "2021", Description = "Kıvanç 2" };
            
            var result = carManager.AddCar(car);

            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
