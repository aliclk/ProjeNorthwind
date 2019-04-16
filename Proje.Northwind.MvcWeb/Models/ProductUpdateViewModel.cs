using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proje.Northwind.Entities.Concrete;

namespace Proje.Northwind.MvcWeb.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; internal set; }
        public List<Category> Categories { get; internal set; }
    }
}
