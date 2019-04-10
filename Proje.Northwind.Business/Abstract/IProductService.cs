using Proje.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetByCategory(int categoryId);
        void Add(Product product);
        void Update(Product product);
        void Delete(int productId);
        Product GetById(int productId);
    }
}
