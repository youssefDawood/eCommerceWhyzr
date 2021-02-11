using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceWhyzr.Domain.Attributes
{
    public class AttributeManager : DomainService, IAttributeManager
    {
        private readonly IRepository<Attribute> _AttributeRepository;
      
        public AttributeManager(
            IRepository<Attribute> caseRepository)
            {
            _AttributeRepository = caseRepository;
        
           }

        public async Task CheckAttributeIsFound(int id) 
        {
            var Attribute = await _AttributeRepository.GetAsync(id);
            if (Attribute ==null) 
            {
                throw new UserFriendlyException(L("CaseIsNotFound"));
            }
        }
        public async Task<Attribute> GetAttributeAsyng(int id)
        {
            var Attribute = await _AttributeRepository.GetAsync(id);
            if (Attribute == null)
            {
                throw new UserFriendlyException(L("CaseIsNotFound"));
            }
            return Attribute;
        }

        //public async Task GetAllAttrbuitesToAttribute(int id)
        //{
        //    var Attribute = await _AttributeRepository.GetAsync(id);
        //    if (Attribute == null)
        //    {
        //        throw new UserFriendlyException(L("CaseIsNotFound"));
        //    }
        //}
    }
}
