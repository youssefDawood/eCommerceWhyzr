using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using eCommerceWhyzr.Domain.Products;

namespace eCommerceWhyzr.Products.Dto
{
    [AutoMapFrom(typeof(InfoInAnotherLanguage))]
    public class InfoInAnotherLanguageDto 
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public int LanguageId { get; set; }

       


    }
}
