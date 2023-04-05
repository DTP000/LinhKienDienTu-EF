using Abp.Application.Services;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using LinhKienDienTu.Products.Dto;
using LinhKienDienTu.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.UI;
using System;
using Abp.Application.Services.Dto;

namespace LinhKienDienTu.Products
{
    [AbpAuthorize]
    public class ProductAppService : AsyncCrudAppService<Product, ProductDto, int, PagedProductResultRequestDto, CreateProductDto, EditProductDto>, IProductAppService
    {
        public ProductAppService(IRepository<Product> Repository) : base(Repository)
        {
        }

        public override Task<ProductDto> CreateAsync(CreateProductDto input)
        {
            try
            {
                return base.CreateAsync(input);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Thêm dữ liệu lỗi");
            }
        }

        public override Task<ProductDto> UpdateAsync(EditProductDto input)
        {
            try
            {
                return base.UpdateAsync(input);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Cập nhật dữ liệu lỗi");
            }
        }

        public override Task<ProductDto> GetAsync(EntityDto<int> input)
        {
            try
            {
                return base.GetAsync(input);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Lấy dữ liệu lỗi");
            }
        }

        protected override IQueryable<Product> CreateFilteredQuery(PagedProductResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.Name.Contains(input.Keyword) && x.IsDeleted == Common.IsDeleted.CHUA_XOA);
        }
    }
}

