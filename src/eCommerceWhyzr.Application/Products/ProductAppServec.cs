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
using Abp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using eCommerceWhyzr.Users.Dto;

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
        /// <summary>
        /// Detete product by id
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task DeleteAsync(EntityDto<int> input)
        {
            var entity = await GetEntityByIdAsync(input.Id);
            await Repository.DeleteAsync(entity);
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="input"></param>
        /// <retur
        protected override async Task<Product> GetEntityByIdAsync(int id)
        {
            var product = await Repository.GetAllIncluding(p => p.Attributes, p => p.InfoInAnotherLanguages).FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                throw new EntityNotFoundException(typeof(Product), id);
            }

            return product;
        }

        public override async Task<ProductDto> UpdateAsync(UpdateProductInputDto input)
        {

            var productDb = GetEntityByIdAsync(input.Id);

            // save val InfoInAnotherLanguage 
            var infoInAnotherLanguagesDto = input.InfoInAnotherLanguages;


            var attributesDto = input.Attributes;

            input.InfoInAnotherLanguages = null;
            input.Attributes = null;

         


            // Add or edit  iInfoInAnotherLanguage to Prodct
            foreach (var infoInAnotherLanguageDto in infoInAnotherLanguagesDto)
            {
                if (productDb.Result.InfoInAnotherLanguages.Any(a => a.Id == infoInAnotherLanguageDto.Id))
                {

                    foreach (var infoInAnotherLanguageDb in productDb.Result.InfoInAnotherLanguages)
                    {
                        if (infoInAnotherLanguageDb.Id == infoInAnotherLanguageDto.Id)
                        {
                            infoInAnotherLanguageDb.LanguageId = infoInAnotherLanguageDto.LanguageId;
                            infoInAnotherLanguageDb.Title = infoInAnotherLanguageDto.Title;
                            infoInAnotherLanguageDb.Description = infoInAnotherLanguageDto.Description;

                        }
                    }
                }
                else
                {

                    var infoInAnotherLanguage = new InfoInAnotherLanguage();
                    infoInAnotherLanguage.Id = infoInAnotherLanguageDto.Id;
                    infoInAnotherLanguage.LanguageId = infoInAnotherLanguageDto.LanguageId;
                    infoInAnotherLanguage.Title = infoInAnotherLanguageDto.Title;
                    infoInAnotherLanguage.Description = infoInAnotherLanguageDto.Description;
                    productDb.Result.InfoInAnotherLanguages.Add(infoInAnotherLanguage);
                }

            }



            // Add or edit  attribute to Prodct
            foreach (var attributeDto in attributesDto)
            {
                if (productDb.Result.Attributes.Any(a => a.Id == attributeDto.Id))
                {

                    foreach (var attributeDb in productDb.Result.Attributes)
                    {
                        if (attributeDb.Id == attributeDto.Id)
                        {
                            attributeDb.Name = attributeDto.Name;
                            attributeDb.Type = attributeDto.Type;
                            attributeDb.StringValu = attributeDto.StringValu;
                            attributeDb.NumberValu = attributeDto.NumberValu;
                            attributeDb.DateValu = attributeDto.DateValu;
                            attributeDb.BooleanValu = attributeDto.BooleanValu;
                        }
                    }
                }
                else
                {

                    var attribute = new Attribute();
                    attribute.Name = attributeDto.Name;
                    attribute.Type = attributeDto.Type;
                    attribute.StringValu = attributeDto.StringValu;
                    attribute.NumberValu = attributeDto.NumberValu;
                    attribute.DateValu = attributeDto.DateValu;
                    attribute.BooleanValu = attributeDto.BooleanValu;
                    productDb.Result.Attributes.Add(attribute);
                }

            }
 
            await Repository.InsertOrUpdateAsync(productDb.Result);


            return MapToEntityDto(productDb.Result);
        }
    }
}
