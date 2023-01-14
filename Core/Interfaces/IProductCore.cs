using Model;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductCore
    {
        ResultModel<ProductDto> AddProduct(ProductDto dto);
        ResultModel<ProductDto> GetById(int productId);
        ResultModel<PageModel<ProductDto>> Search(string keyword, int page, int pageSize);
    }
}
