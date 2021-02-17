using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
        public int BrandId { get; set; }
        public string Year { get; set; }
        public int ColorId { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
