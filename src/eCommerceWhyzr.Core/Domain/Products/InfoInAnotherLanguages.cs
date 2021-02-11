using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using eCommerceWhyzr.Domain;
using eCommerceWhyzr.Domain.Products;
using Abp.Localization;

namespace eCommerceWhyzr.Domain.Products
{
  public  class InfoInAnotherLanguage : BaseEntity
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public int LanguageId { get; set; }

        [ForeignKey(nameof(LanguageId))]
        public ApplicationLanguage Language { get; set; }



    }
}
