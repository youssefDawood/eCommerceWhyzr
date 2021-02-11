using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceWhyzr.Domain.Products
{
    public class ProductManager : DomainService, IProductManager
    {
        private readonly IRepository<Product> _ProductRepository;
      
        public ProductManager(
            IRepository<Product> caseRepository)
            {
            _ProductRepository = caseRepository;
        
           }



        public async Task CheckProductIsFound(int id) 
        {
            var Product = await _ProductRepository.GetAsync(id);
            if (Product ==null) 
            {
                throw new UserFriendlyException(L("CaseIsNotFound"));
            }
           
        }

        public async Task<Product> GetProductAsyng(int id)
        {
            var Product = await _ProductRepository.GetAsync(id);
            if (Product == null)
            {
                throw new UserFriendlyException(L("CaseIsNotFound"));
            }
            return Product;
        }

        //public async Task GetAllAttrbuitesToProduct(int id)
        //{
        //    var Product = await _ProductRepository.GetAsync(id);
        //    if (Product == null)
        //    {
        //        throw new UserFriendlyException(L("CaseIsNotFound"));
        //    }
        //}
    }
}
