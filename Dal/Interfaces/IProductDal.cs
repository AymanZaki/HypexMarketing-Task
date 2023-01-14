using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interfaces
{
    public interface IProductDal 
    {
        Product AddProduct(Product product);
        Product GetProductById(int ProductId);
        IEnumerable<Product> GetProducts(string name, int page, int pageSize);
        int GetProductsCount(string name);
    }
}
