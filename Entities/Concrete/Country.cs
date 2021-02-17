using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    class Country:IEntity
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
    }
}
