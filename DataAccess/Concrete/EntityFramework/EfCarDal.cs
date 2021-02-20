﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(User user)
        {
            using (ReCapContext context = new ReCapContext())
            {
                //var result = from c in context.Cars
                //             join b in context.Brands
                //             on c.BrandId equals b.Id
                //             select new CarDetailDto
                //             {
                //                 CarId = c.Id,
                //                 BrandName = b.Name
                //             };
                //return result.ToList();

                var result = from c in context.Cars
                             select{  };
                return result.ToList();
            }
        }
    }
}
