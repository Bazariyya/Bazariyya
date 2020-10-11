using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Application.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Units { get; set; }
        public int BrandId { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PictureFileName { get; set; }
        public string PictureUrl { get; set; }
        public ProductPictureDto ProductPictureDto { get; set; }
    }
}
