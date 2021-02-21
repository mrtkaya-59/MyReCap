using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    { // Bellekte çalıştığımız için kendi listemizi kendimiz oluşturacaz Proje Çalıştığında bellekte veri oluşturcaz
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            { 
            new Car {CarId=1,BrandId=1,ColorId=1,CarName="Citroen",DailyPrice=120,Description="500 000 km de ",ModelYear=2016},
            new Car {CarId=2,BrandId=2,ColorId=2,CarName="Bmw",DailyPrice=150,Description="Araç Bakımda",ModelYear=2018},
                       
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=> c.CarId==car.CarId);

            _cars.Remove(carToDelete);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
           //Return _cars.SingleOrDefault(c => c.CarId == carId);
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carUpdate = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            carUpdate.CarId = car.CarId;
            carUpdate.CarName = car.CarName;
            carUpdate.BrandId = car.BrandId;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.ModelYear = car.ModelYear;
            carUpdate.ColorId = car.ColorId;
                       
        }
    }
}
