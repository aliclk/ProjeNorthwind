using Proje.Core.DataAccess.EntityFramework;
using Proje.Northwind.DataAccess.Abstract;
using Proje.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal:EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
    {

    }
}
