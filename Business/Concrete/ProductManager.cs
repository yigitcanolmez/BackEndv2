using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal productDal;
        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }
        public IResult Add(Product product)
        {
            productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<Product> GetById(int productId)
        {
           return new SuccessDataResult<Product>(productDal.Get(i => i.ProductId == productId));
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(productDal.GetList().ToList());
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(productDal.GetList(i => i.CategoryId == categoryId).ToList());
                }

        public IResult Update(Product product)
        {
            productDal.Update(product);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
