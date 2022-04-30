using Business.Abstract;
using Core.Utilities.Results;
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

        public IResult Add(User user)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetByFirstName(string firstname)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.FirstName == firstname));
        }

        public IResult Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
