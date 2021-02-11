using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceWhyzr.Domain.Attributes
{
    public interface IAttributeManager : IDomainService  
    {
        Task<Attribute> GetAttributeAsyng(int id);
        Task CheckAttributeIsFound(int id);
    }
}
