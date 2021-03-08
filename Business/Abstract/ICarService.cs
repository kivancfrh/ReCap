using Core.Utilities.Results.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IResult AddCar(Car car);
        IResult Update(Car carOld, Car carNew);
        IResult Delete(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetAll();
        IResult AddTransactionalTest(Car car);
    }
}
