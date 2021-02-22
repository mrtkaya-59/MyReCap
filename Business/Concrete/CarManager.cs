using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length<2)
            {
                return new ErrorResult("araç ismi en az 2 karakter olmalı");

            }
            
            _carDal.Add(car);

            return new SuccesResult("Araç eklendi");
        }

        public List<Car> GetAll()
        {
            // İş Kodları yazılır Buraya İş kodlarından geçtikten osnra veri erişim çağırmak gerek

            return _carDal.GetAll();
        }

        public List<Car> GetAllByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _carDal.GetAll(c=> c.BrandId==brandId);
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(c=> c.CarId==carId);
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            return _carDal.GetCarDetailDtos();
        }
    }
}
