using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceWhyzr.Domain
{
    public class BaseEntity : FullAuditedEntity
    {

        public bool IsActive { get; set; }
        public string Notes { get; set; }
    }
}
