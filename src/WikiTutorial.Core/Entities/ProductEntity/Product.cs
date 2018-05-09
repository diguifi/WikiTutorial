using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiTutorial.Entities.ProductEntity
{
    public class Product : FullAuditedEntity<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
    }
}
