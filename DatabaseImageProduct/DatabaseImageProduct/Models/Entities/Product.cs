using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseImageProduct.Models.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ImageFullName { get; set; }
    }
}
