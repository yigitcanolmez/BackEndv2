
using Business.Abstract;
using Business.Constants;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal userDal;

        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }

        public IResult Add(User user)
        {
            userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return userDal.GetClaims(user);
        }

        public User GetByMail(string email)
        {
         return   userDal.Get(u => u.Email == email);

        }

        public IResult Update(User user)
        {
            userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
