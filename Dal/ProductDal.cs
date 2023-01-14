using Dal.Interfaces;
using Entites.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ProductDal : IProductDal
    {
        
        public Product AddProduct(Product product)
        {
            // call db context to add product in database

            return new Product
            {
                ProductId = 1,
                Name = product.Name,
                ProductTypeId = product.ProductTypeId,
                Size = product.Size
            };
        }

        public Product GetProductById(int ProductId)
        {
            return new Product
            {
                ProductId = 1,
                Name = "ProductName",
                ProductTypeId = 1,
                Size = 10
            };
        }

        public IEnumerable<Product> GetProducts(string name, int page, int pageSize)
        {
            return new List<Product>
            {
                { 
                    new Product 
                    { 
                        ProductId = 1,
                        Name = "ProductName 1",
                        ProductTypeId = 1,
                        Size = 10
                    }
                },
                {   new Product 
                    {
                        ProductId = 2,
                        Name = "ProductName 2",
                        ProductTypeId = 1,
                        Size = 20
                    }
                }
            };
        }

        public int GetProductsCount(string name)
        {
            return 5;
        }
    }
}
