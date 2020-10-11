using Microsoft.EntityFrameworkCore;
using Microsoft.eShopOnContainers.Services.Ordering.Domain.Seedwork;
using Product.Domain.AggregatesModel.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repositoryes
{
    public class ProductRepository : IProductRepository
    {
        ProductContext _productContext;
        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext ?? throw new Exception();
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _productContext;
            }
        }
        public Domain.AggregatesModel.ProductAggregate.Product Add(Domain.AggregatesModel.ProductAggregate.Product product)
        {
            _productContext.Add(product);
            return product;
        }

        public IQueryable<Domain.AggregatesModel.ProductAggregate.Product> GetAll()
        {
            _productContext.Products.Include(p => p.ProductCategories)
                .Include(p => p.ProductPictures);
            
            return _productContext.Products;
        }

        public async Task<List<Domain.AggregatesModel.ProductAggregate.Product>> GetAllAsync()
        {
            return GetAll().ToList();
        }

        public Task<Domain.AggregatesModel.ProductAggregate.Product> GetAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Domain.AggregatesModel.ProductAggregate.Product Update(Domain.AggregatesModel.ProductAggregate.Product product)
        {
            foreach(var item in product.ProductPictures)
            {
                if(item.recordStatu == Domain.SeedWork.Enums.RecordStatu.Deleted)
                {
                    var pro = _productContext.ProductPictures.FirstOrDefault(x => x.FileName == item.FileName);
                    _productContext.ProductPictures.Remove(pro);
                }
            }
            product.ProductPictures.RemoveAll(x => x.recordStatu == Domain.SeedWork.Enums.RecordStatu.Deleted);

            _productContext.Update(product);
            return product;
        }
    }
}
