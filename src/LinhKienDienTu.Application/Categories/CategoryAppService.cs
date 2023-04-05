using Abp.Application.Services;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using LinhKienDienTu.Categories.Dto;
using LinhKienDienTu.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LinhKienDienTu.Categories
{
    [AbpAuthorize]
    public class CategoryAppService : AsyncCrudAppService<Category, CategoryDto, int, PagedCategoryResultRequestDto, CreateCategoryDto, EditCategoryDto>, ICategoryAppService
    {
        public CategoryAppService(IRepository<Category> Repository) : base(Repository)
        {
        }
        protected override IQueryable<Category> CreateFilteredQuery(PagedCategoryResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword));
        }
    }
}

