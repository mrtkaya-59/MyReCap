using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetAllByColorId(int colorId);
        List<Car> GetByBrandId(int brandId);
        List<CarDetailDto> GetCarDetailDtos();
        IResult Add(Car car);
        Car GetById(int carId);

    }
}
