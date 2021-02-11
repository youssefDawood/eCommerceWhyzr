

using eCommerceWhyzr.Domain.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
 

namespace eCommerceWhyzr.Domain.Products
{
    public class Product : BaseEntity
    {
        public Product()
        {
            InfoInAnotherLanguages = new HashSet<InfoInAnotherLanguage>();
            Attributes = new HashSet<Attribute>();
        }
  
        public string Title { get; set; }
   
        public string Description { get; set; }

        public bool IsBublish { get; set; }

        public ProductStatus Status { get; set; }

        [Required]
        public string Imge { get; set; }

        public double Price { get; set; }

        public float? Quantity { get; set; }

        public virtual ICollection<Attribute> Attributes { get; set; }
        public virtual ICollection<InfoInAnotherLanguage> InfoInAnotherLanguages { get; set; }


        public void AddAttributes(Attribute attributes)
        {

            Attributes.Add(attributes);
        }

        public void AddInfoInAnotherLanguages(InfoInAnotherLanguage infoInAnotherLanguage)
        {

            InfoInAnotherLanguages.Add(infoInAnotherLanguage);
        }

        public enum ProductStatus : byte
        {
            Pending = 1,
            Accepted = 2,
            Draft = 3,
            Rejected = 4
        }

    }
}
