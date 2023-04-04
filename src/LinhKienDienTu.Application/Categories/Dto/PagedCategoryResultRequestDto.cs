using Abp.Application.Services.Dto;

namespace LinhKienDienTu.Categories.Dto
{
    public class PagedCategoryResultRequestDto : PagedResultRequestDto
    {
        public string? Keyword { get; set; }
    }
}

