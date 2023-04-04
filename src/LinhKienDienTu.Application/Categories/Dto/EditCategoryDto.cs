

using LinhKienDienTu.Common;
using LinhKienDienTu.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using Abp.Application.Services.Dto;

namespace LinhKienDienTu.Categories.Dto
{
    public class EditCategoryDto : EntityDto<int>
    {
        [StringLength(100)]
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
