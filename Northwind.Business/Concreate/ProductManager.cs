using Northwind.Business.Abstract;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concreate;
using Northwind.DataAccess.Concreate.EntityFramework;
using Northwind.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Northwind.Business.Concreate
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {        
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            ProductValidator productValidator = new ProductValidator();
            var result = productValidator.Validate(product);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
            _productDal.Add(product);         
        }

        public void Delete(Product product)
        {
            ProductValidator productValidator = new ProductValidator();
            var result = productValidator.Validate(product);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
            //Business code       
            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public List<Product> GetProductsByProductName(string ProductName)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(ProductName.ToLower()));
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
