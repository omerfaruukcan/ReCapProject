using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CarAddTest();

            //CarDeleteTest();

            // GetCarsByBrandIdTest();

            // GetCarDetailsTest();

            // GetTest();

            // GetAllTest();

            // BrandAddTest();

            // BrandDeleteTest();
        }

        private static void CarDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { CarId = 8 });
 
        }

        private static void CarAddTest()
        {
            Car car1 = new Car()
            {
                BrandId = 2,
                CarName = "c200",
                ColorId = 2,
                DailyPrice = 200,
                Description = "safasfas",
                ModelYear = 2020
            };

            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine(carManager.Add(car1).Message); 
        }

        private static void BrandDeleteTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Delete(new Brand{ BrandId = 4 });
        }

        private static void BrandAddTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Add(new Brand{ BrandName = "Ford" });
        }

        private static void GetAllTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void GetTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.Get("Black");
            Console.WriteLine(result.Data);
        }

        private static void GetCarsByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                Console.WriteLine(result.Message + "\n");

                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}", car.BrandName, car.CarName, car.ColorName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
