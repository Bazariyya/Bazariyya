using Product.API.Application.Models;
using Product.Domain.AggregatesModel.ProductAggregate;
using System;
using System.Collections.Generic;
using Product.Domain.AggregatesModel;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Application.Queryes.ProductQueryes
{
    public class ProductQuery : IProductQuery
    {
        IProductRepository _productRepository;
        public ProductQuery(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new Exception();
        }

        public List<ProductDto> GetAllProductsAsync()
        {
            return MapProductTo(_productRepository.GetAllAsync().Result);
        }

        private List<ProductDto> MapProductTo(List<Domain.AggregatesModel.ProductAggregate.Product> products)
        {
            List<ProductDto> productDtos = new List<ProductDto>();
            if (products == null) return productDtos;

            foreach (Domain.AggregatesModel.ProductAggregate.Product product in products)
            {
                productDtos.Add(new ProductDto {
                    ProductId = product.Id,
                    ProductCode = "",
                    ProductName = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    PictureUrl = product.ProductPictures.Where(x => x.IsDefault).Count() > 0 ? product.ProductPictures.Where(x => x.IsDefault).First().FileName : ""
                });
            }
            return productDtos;
        }
    }
}
