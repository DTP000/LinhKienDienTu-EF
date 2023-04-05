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
    public class Product : Entity<int>, IHasCreationTime, IHasModificationTime, ICreationAudited, IModificationAudited
    {
        [StringLength(254)]
        public string Name { get; set; }
        [DefaultValue(0)]
        public long Price { get; set; }
        [DefaultValue(0)]
        public int Quantity { get; set; }

        public string Descr { get; set; }
        [DefaultValue(0)]
        public IsDeleted IsDeleted { get; set; }

        public string UrlImage { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? LastModifierUserId { get; set; }
    }
}
