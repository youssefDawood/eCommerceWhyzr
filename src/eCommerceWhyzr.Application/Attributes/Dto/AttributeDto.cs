using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using eCommerceWhyzr.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static eCommerceWhyzr.Domain.Attributes.Attribute;
using Attribute = eCommerceWhyzr.Domain.Attributes.Attribute;

namespace eCommerceWhyzr.Attributes.Dto
{
    [AutoMapFrom(typeof(Attribute))]
   public class AttributeDto : EntityDto
    {

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// 1- Date time
        /// 2- Boolen
        /// 3- String
        /// 4- Nmber
        /// </summary>
        public AttributeType Type { get; set; }

        public bool IsRequired { get; set; }
        public string StringValu { get; set; }
        public DateTime? DateValu { get; set; }
        public double? NumberValu { get; set; }
        public bool? BooleanValu { get; set; }

        public int ProductId { get; set; }
        public void CheckData(CustomValidationContext context)
        {
            if (Type == AttributeType.Boolen &&( NumberValu != null || DateValu != null || StringValu != null))
            {
                context.Results.Add(new ValidationResult(" Please check the entered data "));
            }
            if (Type == AttributeType.String &&( NumberValu != null || DateValu != null || BooleanValu != null))
            {
                context.Results.Add(new ValidationResult(" Please check the entered data "));
            }
            if (Type == AttributeType.Number &&( BooleanValu != null || DateValu != null || StringValu != null))
            {
                context.Results.Add(new ValidationResult(" Please check the entered data "));
            }
            if (Type == AttributeType.DateTime &&( NumberValu != null || BooleanValu != null || StringValu != null))
            {
                context.Results.Add(new ValidationResult(" Please check the entered data "));
            }
        }
    }
}
