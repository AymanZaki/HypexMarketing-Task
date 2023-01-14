using Core.Interfaces;
using Dal.Interfaces;
using Entites.Entites;
using Model;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ProductCore : IProductCore
    {
        private readonly IProductDal _productDal;
        public ProductCore(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public ResultModel<ProductDto> AddProduct(ProductDto dto)
        {
            var product = _productDal.AddProduct(MapProductDtoToProduct(dto));
            if (product == null)
            {
                return new ResultModel<ProductDto>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Data = MapProductToProductDto(product),
                    Message = "Failed To Add Product"
                };
            }

            return new ResultModel<ProductDto>
            {
                StatusCode = HttpStatusCode.OK,
                Data = MapProductToProductDto(product),
                Message = "The product is added successfully"
            };
        }

        public ResultModel<ProductDto> GetById(int productId)
        {
            var product = _productDal.GetProductById(productId);
            if (product == null)
            {
                return new ResultModel<ProductDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Data = MapProductToProductDto(product),
                    Message = "The product not found"
                };
            }

            return new ResultModel<ProductDto>
            {
                StatusCode = HttpStatusCode.OK,
                Data = MapProductToProductDto(product),
                Message = "Succeeded"
            };

        }

        public ResultModel<PageModel<ProductDto>> Search(string keyword, int page, int pageSize)
        {
            var productsCount = _productDal.GetProductsCount(keyword);
            var products = _productDal.GetProducts(keyword, page, pageSize).ToList();
            if (products == null || !products.Any())
            {
                return new ResultModel<PageModel<ProductDto>>
                {
                    StatusCode = HttpStatusCode.NoContent,
                    Data = new PageModel<ProductDto>
                    {
                        PageNumber = page,
                        PagesCount = (int)Math.Ceiling(productsCount / (decimal)pageSize),
                        PageSize = pageSize,
                        Results = null,
                        TotalCount = productsCount
                    },
                    Message = "No Content for this keyword"
                };
            }


            return new ResultModel<PageModel<ProductDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Data = new PageModel<ProductDto>
                {
                    PageNumber = page,
                    PagesCount = (int)Math.Ceiling(productsCount / (decimal)pageSize),
                    PageSize = pageSize,
                    Results = products.Select(p => MapProductToProductDto(p)),
                    TotalCount = productsCount
                },
                Message = "Succeeded"
            };
        }


        private ProductDto MapProductToProductDto(Product product)
        {
            if (product == null)
                return null;
            return new ProductDto()
            {
                Name = product.Name,
                ProductId = product.ProductId,
                ProductTypeId = product.ProductTypeId,
                Size = product.Size,
            };
        }

        private Product MapProductDtoToProduct(ProductDto dto)
        {
            if (dto == null)
                return null;
            return new Product()
            {
                Name = dto.Name,
                ProductId = dto.ProductId,
                ProductTypeId = dto.ProductTypeId,
                Size = dto.Size,
            };
        }
    }
}
