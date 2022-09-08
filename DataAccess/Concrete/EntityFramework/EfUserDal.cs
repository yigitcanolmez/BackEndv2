

using Core.DataAccess.EntityFramework;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from operationClaim in context.OperationClaim
                             join userOperationClaims in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaims.Id
                             where userOperationClaims.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();


              
            }

        }
    }
}
