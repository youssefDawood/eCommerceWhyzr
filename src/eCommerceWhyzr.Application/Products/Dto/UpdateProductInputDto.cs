using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using eCommerceWhyzr.Domain.Products;
using static eCommerceWhyzr.Domain.Products.Product;
using eCommerceWhyzr.Attributes.Dto;

namespace eCommerceWhyzr.Products.Dto
{
    [AutoMapTo(typeof(Product))]
  public  class UpdateProductInputDto :  IEntityDto
    {

        public int  Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsBublish { get; set; }

        public ProductStatus Status { get; set; }

        [Required]
        public string Imge { get; set; }

        public double Price { get; set; }

        public float? Quantity { get; set; }
        public List<UpdateInfoInAnotherLanguageDto> InfoInAnotherLanguages { get; set; }
        public List<UpdateAttributeInputDto> Attributes { get; set; }

        // public IFormFile Imge { get; set; }
    }
}
