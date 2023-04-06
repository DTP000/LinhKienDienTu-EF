using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using LinhKienDienTu.Products.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LinhKienDienTu.Products
{
    public interface IProductAppService : IAsyncCrudAppService<ProductDto, int, PagedProductResultRequestDto, CreateProductDto, EditProductDto>
    {
        Task<List<SelectListItem>> GetSelectListProductAsync();
    }
}
