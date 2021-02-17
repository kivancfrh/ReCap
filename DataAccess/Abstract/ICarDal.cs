using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        void GetByld();
        void GetAll();
        void Add();
        void Update();
        void Delete();
    }
}
