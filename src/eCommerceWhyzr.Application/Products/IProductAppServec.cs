using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using eCommerceWhyzr.Products.Dto;

namespace eCommerceWhyzr.Products
{
    public interface IProductAppServec : IAsyncCrudAppService< ProductDto, int, PagedProductResultRequestDto, CreateProductInputDto, UpdateProductInputDto>
    {
    }
}
