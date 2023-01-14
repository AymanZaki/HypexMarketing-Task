using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Entites
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        public string ProductName { get; set; }
    }
}
