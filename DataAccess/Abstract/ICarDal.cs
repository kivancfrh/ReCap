using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        // IEntityRepository'deki ortak operasyonlar haricinde özel operasyonlar buraya eklenir.
        List<CarDetailDto> GetCarDetails();
    }
}
