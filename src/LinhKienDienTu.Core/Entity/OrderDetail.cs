using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using LinhKienDienTu.Common;

namespace LinhKienDienTu.Entity
{
    public class OrderDetail : Entity<int>, IHasCreationTime, IHasModificationTime, ICreationAudited, IModificationAudited
    {
        [DefaultValue(1)]
        public int Quantity { get; set; }
        [DefaultValue(0)]
        public long Price { get; set; }
        public string Note { get; set; }
        [DefaultValue(0)]
        public IsDeleted IsDeleted { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? LastModifierUserId { get; set; }
    }
}
