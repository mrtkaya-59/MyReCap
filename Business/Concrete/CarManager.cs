using Business.Abstract;
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

        public List<CarDetailDto> GetCarDetailDtos()
        {
            return _carDal.GetCarDetailDtos();
        }
    }
}
