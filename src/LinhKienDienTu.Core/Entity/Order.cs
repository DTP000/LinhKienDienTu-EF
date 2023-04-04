using Castle.MicroKernel.SubSystems.Conversion;
using LinhKienDienTu.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using LinhKienDienTu.Common;

namespace LinhKienDienTu.Entity
{
    public class Order : Entity<int>, IHasCreationTime, IHasModificationTime, ICreationAudited, IModificationAudited
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
        [DefaultValue(0)]
        public IsDeleted IsDeleted { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? LastModifierUserId { get; set; }
    }
}
