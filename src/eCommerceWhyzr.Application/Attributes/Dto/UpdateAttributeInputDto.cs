using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCommerceWhyzr.Attributes.Dto
{
    [AutoMapTo(typeof(Attribute))]
  public  class UpdateAttributeInputDto : CreateAttributeInputDto, IEntityDto
    {

        public int  Id { get; set; }
    }
}
