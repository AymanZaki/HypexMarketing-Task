using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Entites
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int ProductTypeId { get; set; }

        [ForeignKey("ProductTypeId")]
        public ProductType ProductType { get; set; }
    }
}
