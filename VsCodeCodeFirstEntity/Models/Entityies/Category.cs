using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  VsCodeCodeFirstEntity.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool IsDeleted { get; set; }
        public List<Book> Books { get; set; }
    }
}