using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinhKienDienTu.Common;
using System.ComponentModel;

namespace LinhKienDienTu.Entity
{
    public class Image : Entity<int>, IHasCreationTime, IHasModificationTime, ICreationAudited, IModificationAudited
    {
        public string Url { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [DefaultValue(0)]
        public IsDeleted IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? LastModifierUserId { get; set; }

    }
}
