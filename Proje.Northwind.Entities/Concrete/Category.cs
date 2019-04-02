using Proje.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Northwind.Entities.Concrete
{
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
