using Business.Abstract;
using Business.Constans;
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
                return new ErrorResult(Messages.CarNameInvalid);

            }
            
            _carDal.Add(car);

            return new SuccesResult(Messages.CarAdded);
        }

        public IDataResult< List<Car>> GetAll()
        {
            // İş Kodları yazılır Buraya İş kodlarından geçtikten osnra veri erişim çağırmak gerek
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
                       
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(),Messages.Listed);
        }

        public IDataResult< List<Car>> GetAllByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult< List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c=> c.BrandId==brandId));
        }

        public IDataResult< Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>( _carDal.Get(c=> c.CarId==carId));
        }

        public IDataResult < List<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetCarDetailDtos());
        }
    }
}
