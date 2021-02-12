using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using eCommerceWhyzr.Products.Dto;
using eCommerceWhyzr.Authorization.Users;
using System.Threading.Tasks;
using eCommerceWhyzr.Domain.Products;

using eCommerceWhyzr.Domain.Attributes;
using Attribute = eCommerceWhyzr.Domain.Attributes.Attribute;
using Abp.Application.Services.Dto;

namespace eCommerceWhyzr.Products
{
    public class ProductAppServec : AsyncCrudAppService<Product, ProductDto, int, PagedProductResultRequestDto, CreateProductInputDto, UpdateProductInputDto>, IProductAppServec
    {
        private readonly UserManager _userManager;

        private readonly IAttributeManager _attributeManager;
        private readonly IProductManager _productManager;

        public ProductAppServec(IRepository<Product, int> repository, UserManager userManager,

              IAttributeManager attributeManager,
              IProductManager productManager
            )
            : base(repository)
        {
            _userManager = userManager;
            _attributeManager = attributeManager;
            _productManager = productManager;
        }

        public override async Task<ProductDto> CreateAsync(CreateProductInputDto input)
        {
            // save val InfoInAnotherLanguage 
            var infoInAnotherLanguagesDto = input.InfoInAnotherLanguages;
           
            
            var attributesDto = input.Attributes;
     
            input.InfoInAnotherLanguages = null;
            input.Attributes = null;
           
            var entity = ObjectMapper.Map<Product>(input);


            // Add iInfoInAnotherLanguage to Prodct
            foreach (var infoInAnotherLanguageDto in infoInAnotherLanguagesDto)
            {
                var infoInAnotherLanguage = new InfoInAnotherLanguage();
                infoInAnotherLanguage.LanguageId = infoInAnotherLanguageDto.LanguageId;
                infoInAnotherLanguage.Title = infoInAnotherLanguageDto.Title;
                infoInAnotherLanguage.Description = infoInAnotherLanguageDto.Description;
                entity.InfoInAnotherLanguages.Add(infoInAnotherLanguage);
            }


            // Add iInfoInAnotherLanguage to Prodct
            foreach (var attributeDto in attributesDto)
            {
                var attribute = new Attribute();
                attribute.Name = attributeDto.Name;
                attribute.Type = attributeDto.Type;
                attribute.StringValu = attributeDto.StringValu;
                attribute.NumberValu = attributeDto.NumberValu;
                attribute.DateValu = attributeDto.DateValu;
                attribute.BooleanValu = attributeDto.BooleanValu;
                entity.Attributes.Add(attribute);
            }
            await Repository.InsertAsync(entity);


            return MapToEntityDto(entity);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var entity = await GetEntityByIdAsync(input.Id);
            await Repository.DeleteAsync(entity);
        }


    }
}
