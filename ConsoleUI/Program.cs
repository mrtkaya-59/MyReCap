using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {   // productTest();
            //colorTest();
            //brandTest();

            //CarManager carManager = new CarManager(new EfCarDal());

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.CarName);
            //}

            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetailDtos())
            {
                Console.WriteLine(car.CarName + "/" + car.BrandName);
            }

           

        }

        private static void brandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void colorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void productTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAllByColorId(1))
            {
                Console.WriteLine(car.CarName);
            }
        }
    }
}
