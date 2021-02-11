 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
 
using eCommerceWhyzr.Domain.Products;

namespace eCommerceWhyzr.Domain.Attributes
{
    public class Attribute : BaseEntity
    {
        public Attribute()
        {
            
        }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// 1- Date time
        /// 2- Boolen
        /// 3- String
        /// 4- Number
        /// </summary>
        public int Type { get; set; }

        public bool IsRequired { get; set; }
        public string StringValu { get; set; }
        public System.DateTime? DateValu { get; set; }
        public double? NumberValu { get; set; }
        public bool? BooleanValu { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }


        public enum AttributeType : byte
        {
           
            DateTime = 1,
            Boolen = 2,
            String = 3,
            Number = 4
        }
    }
}
