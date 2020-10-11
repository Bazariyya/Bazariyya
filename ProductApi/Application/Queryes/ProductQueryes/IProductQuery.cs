using Product.API.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Application.Queryes.ProductQueryes
{
    public interface IProductQuery
    {
        public List<ProductDto> GetAllProductsAsync();
    }
}
