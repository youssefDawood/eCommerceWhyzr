using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using eCommerceWhyzr.Attributes.Dto;
using eCommerceWhyzr.Authorization.Users;
using Attribute = eCommerceWhyzr.Domain.Attributes.Attribute;

namespace eCommerceWhyzr.Attributes
{ 
  public  class AttributeAppServec : AsyncCrudAppService<Attribute, AttributeDto, int, PagedAttrbuiteResultRequestDto, CreateAttributeInputDto, UpdateAttributeInputDto>, IAttributeAppServec
    {
        private readonly UserManager _userManager;

        public AttributeAppServec(IRepository<Attribute, int> repository, UserManager userManager) 
            : base(repository)
        {
            _userManager = userManager;
        }



    }
}
