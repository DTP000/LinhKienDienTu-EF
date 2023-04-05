using Abp.Application.Services.Dto;

namespace LinhKienDienTu.Orders.Dto
{
    public class PagedOrderResultRequestDto : PagedResultRequestDto
    {
        public string? Keyword { get; set; }
    }
}

