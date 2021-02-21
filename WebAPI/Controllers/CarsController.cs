using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
        //Loosely coupled - gevşek bağlılık - bir bağımlılığ var ama soyuta var.
        //isimlendirme standartı
        //IoC Container - Inversion of control
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result); //Http dönüş kodu 200 olur (olumlu)
            }
            else
            {
                return BadRequest(result); //Http dönüş kodu 400 olur (olumsuz)
            }
            
        }

        //Ayrıca silme ve güncelleme için de post kullanılabilir.
        [HttpPost("add")]

        public IActionResult Add(Car car)
        {
            var result = _carService.AddCar(car);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbybrandid")]

        public IActionResult GetByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
