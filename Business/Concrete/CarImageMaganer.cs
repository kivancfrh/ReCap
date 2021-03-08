using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Business.Concrete
{
    public class CarImageMaganer : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageMaganer(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        public IResult Add(Car car, List<Image> ListOfImage)
        {
            foreach (var image in ListOfImage)
            {
                MoveImagesTo(image);
                CarImage carImage = new CarImage { Date = DateTime.Now, CarId = car.Id, ImagePath = @"F:\EGITIM\Yazılım\C#\OOP (Engin Demiroğ)\Projects\images\" + Guid.NewGuid().ToString() + @"\.jpg" };
                _carImageDal.Add(carImage);
            }
            return new SuccessResult();
        }

        private void MoveImagesTo(Image image)
        {
                //Resimlerin ilgili dosyaya taşınması
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Car carOld, Car carNew)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
