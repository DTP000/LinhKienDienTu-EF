using Abp.Application.Services;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using LinhKienDienTu.Categories.Dto;
using LinhKienDienTu.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Abp.UI;
using System;
using LinhKienDienTu.Common;
using Abp.Application.Services.Dto;

namespace LinhKienDienTu.Categories
{
    [AbpAuthorize]
    public class CategoryAppService : AsyncCrudAppService<Category, CategoryDto, int, PagedCategoryResultRequestDto, CreateCategoryDto, EditCategoryDto>, ICategoryAppService
    {
        public CategoryAppService(IRepository<Category> Repository) : base(Repository)
        {
        }

        public override Task<CategoryDto> CreateAsync(CreateCategoryDto input)
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

        public override Task<CategoryDto> UpdateAsync(EditCategoryDto input)
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

        public override Task<CategoryDto> GetAsync(EntityDto<int> input)
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

        protected override IQueryable<Category> CreateFilteredQuery(PagedCategoryResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.Name.Contains(input.Keyword) && x.IsDeleted == IsDeleted.CHUA_XOA);
        }
        public async Task<List<SelectListItem>> GetSelectListCategoryAsync()
        {
            try
            {
                var result = Repository.GetAll()
                  .Where(x => x.IsDeleted == IsDeleted.CHUA_XOA)
                  .Select(x => new SelectListItem()
                  {
                      Value = x.Id.ToString(),
                      Text = x.Name,
                  })
                  .ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException("Lấy danh mục lỗi");
            }
        }
    }
}

