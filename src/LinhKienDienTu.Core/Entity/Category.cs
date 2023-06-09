﻿using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LinhKienDienTu.Common;
using System.ComponentModel;

namespace LinhKienDienTu.Entity
{
    public class Category : Entity<int>, IHasCreationTime, IHasModificationTime, ICreationAudited, IModificationAudited
    {
        [StringLength(100)]
        public string Name { get; set; }
        [DefaultValue(0)]
        public IsDeleted IsDeleted { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public long? LastModifierUserId { get; set; }
    }
}
