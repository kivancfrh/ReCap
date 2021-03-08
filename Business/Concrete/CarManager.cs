using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageDal _carImageDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //Claim - İddia etmek
        [SecuredOperation("car.add,admin")] //Yada operasyon bazında mesela "car.add" Claim'i
        [ValidationAspect(typeof(CarValidator))] //AddCar çalışmadan önce Car ı bulup ilgili valitador ı bulup validate yapacak.
        [CacheRemoveAspect("IProductService.Get")] //Yeni ürün eklerken Cache i siliyoruz. Çakışma olmasın ve veritabanı ile tutarsızlık olmasın diye!
        public IResult AddCar(Car car)
        {
            //Business codes - iş ihtiyaçlarımıza uygunluk.
            //Validation codes Eklemeye çalıştığımız nesnenin iş kurallarına dail olması için yapısal kurallarına uygun olup olmadığı

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Car car)
        {
            throw new NotImplementedException();
        }

        [CacheAspect] //key,value
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.Listed);
        }

        [CacheAspect] //Çok sık kullanılmayan metodlarda kullanma!!
        [PerformanceAspect(5)] //Bu metordun çalışması 5 sn yi geçerse beni uyar!
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), Messages.Listed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id), Messages.Listed);
        }

        [CacheRemoveAspect("Get")] //içinde Get olan tüm key leri sil
        [CacheRemoveAspect("IProductService.Get")] //Sadece Ürün Güncellemede Get olan tüm key leri sil

        public IResult Update(Car carOld, Car carNew)
        {
            throw new NotImplementedException();
        }
    }
}
