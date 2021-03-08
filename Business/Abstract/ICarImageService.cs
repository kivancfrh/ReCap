using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(Car car, List<Image> ListOfImage);
        IResult Update(Car carOld, Car carNew);
        IResult Delete(Car car);
        IDataResult<List<CarImage>> GetByCarId(int carId);
    }
}
