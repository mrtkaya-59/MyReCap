using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofact.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
           
           
            _carDal.Add(car);

            return new SuccesResult(Messages.CarAdded);
        }

        public IDataResult< List<Car>> GetAll()
        {
            // İş Kodları yazılır Buraya İş kodlarından geçtikten osnra veri erişim çağırmak gerek
            if (DateTime.Now.Hour==24)
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
