using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IDataResult<User> Get(User user)
        {
            var result = _userDal.GetAll(p => p.Email == user.Email && p.Password == user.Password);
            //return new SuccessDataResult<List<User>>()
        }
    }
}
