using Abp.Application.Services.Dto;

namespace LinhKienDienTu.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

