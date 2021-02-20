using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IResult CheckUser(User user)
        {
            try
            {
                var result = _userDal.Get(p => p.Email == user.Email && p.Password == user.Password);
                return new SuccessResult(Messages.SuccessLogin);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.LoginInvalid);
            }
        }
    }
}
