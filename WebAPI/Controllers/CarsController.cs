using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  //--> Attribute (bir class ile ilgili bilgi verme, onu imzalama yetkilisidir)
    public class CarsController : ControllerBase
    {

        [HttpGet]
        public List<Car> Get()
        {
            return new List<Car>
            {
                new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 200, ModelId = 2, ModelYear = "2020", Description = "Kıvanç ekledi" },
                new Car { Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 300, ModelId = 3, ModelYear = "2021", Description = "Kıvanç ekledi 2" }
            };
        }
    }
}
