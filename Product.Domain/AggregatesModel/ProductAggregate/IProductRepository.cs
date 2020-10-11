using Microsoft.eShopOnContainers.Services.Ordering.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.AggregatesModel.ProductAggregate
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Add(Product product);

        Product Update(Product product);

        Task<Product> GetAsync(int productId);

        IQueryable<Product> GetAll();
        Task<List<Product>> GetAllAsync();

    }
}
