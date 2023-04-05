using Abp.Application.Services.Dto;

namespace LinhKienDienTu.Products.Dto
{
    public class PagedProductResultRequestDto : PagedResultRequestDto
    {
        public string? Keyword { get; set; }
    }
}

