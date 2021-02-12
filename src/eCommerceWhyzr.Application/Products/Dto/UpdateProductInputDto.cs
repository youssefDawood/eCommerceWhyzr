using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using eCommerceWhyzr.Domain.Products;

namespace eCommerceWhyzr.Products.Dto
{
    [AutoMapTo(typeof(Product))]
  public  class UpdateProductInputDto : CreateProductInputDto, IEntityDto
    {

        public int  Id { get; set; }
    }
}
