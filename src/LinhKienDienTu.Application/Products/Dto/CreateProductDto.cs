using LinhKienDienTu.Common;
using LinhKienDienTu.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Abp.Application.Services.Dto;

namespace LinhKienDienTu.Products.Dto
{
    public class CreateProductDto
    {
        [StringLength(254)]
        public string Name { get; set; }
        [DefaultValue(0)]
        public long Price { get; set; }
        [DefaultValue(0)]
        public int Quantity { get; set; }
        public string Descr { get; set; }
        [DefaultValue(0)]
        public int CategoryId { get; set; }
    }
}
