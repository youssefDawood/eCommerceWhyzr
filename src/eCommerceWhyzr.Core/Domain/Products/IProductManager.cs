using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eCommerceWhyzr.Domain.Products;

namespace eCommerceWhyzr.Domain.Products
{
    public interface IProductManager : IDomainService  
    {
        Task<Product> GetProductAsyng(int id);
        Task CheckProductIsFound(int id);
    }
}
