using Abp.Application.Services.Dto;
using LinhKienDienTu.Common;
using LinhKienDienTu.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhKienDienTu.Orders.Dto
{
    public class OrderDetailDto : EntityDto<int>
    {
        [DefaultValue(1)]
        public int Quantity { get; set; }
        [DefaultValue(0)]
        public long Price { get; set; }
        public string Note { get; set; }
        [DefaultValue(0)]
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
