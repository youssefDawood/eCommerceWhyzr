using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using eCommerceWhyzr.Attributes.Dto;

namespace eCommerceWhyzr.Attributes
{
    public interface IAttributeAppServec : IAsyncCrudAppService< AttributeDto, int, PagedAttrbuiteResultRequestDto, CreateAttributeInputDto, UpdateAttributeInputDto>
    {
    }
}
