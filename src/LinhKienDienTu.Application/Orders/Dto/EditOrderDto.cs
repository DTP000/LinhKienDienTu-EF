using LinhKienDienTu.Common;
using LinhKienDienTu.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using Abp.Application.Services.Dto;

namespace LinhKienDienTu.Orders.Dto
{
    public class EditOrderDto : EntityDto<int>
    {
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(254)]
        public string Address { get; set; }
        [DefaultValue(0)]
        public decimal TotalPrice { get; set; }
        public string Note { get; set; }

        [DefaultValue(1)]
        public OrderStatus OrderStatus { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
        public long UserId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
