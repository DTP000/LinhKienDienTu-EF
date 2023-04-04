using LinhKienDienTu.Common;
using LinhKienDienTu.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Abp.Application.Services.Dto;

namespace LinhKienDienTu.Categories.Dto
{
    public class CategoryDto : EntityDto<int>
    {
        [StringLength(100)]
        public string Name { get; set; }
    }
}
