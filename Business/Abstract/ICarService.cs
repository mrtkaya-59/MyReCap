﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult< List<Car>> GetAllByColorId(int colorId);
        IDataResult< List<Car>> GetByBrandId(int brandId);
        IDataResult< List<CarDetailDto>> GetCarDetailDtos();
        IResult Add(Car car);
        IDataResult< Car> GetById(int carId);

    }
}
