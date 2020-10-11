using Product.API.Application.Models;
using Product.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Application.Commands.ProductCommands
{
    public class UpdateProductCommand: BaseCommand<bool>
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public int Units { get; set; }
        public int BrandId { get; set; }
        public int CatalogId { get; set; }
        public int List { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PictureFileName { get; set; }
        public string PictureUrl { get; set; }
        public List<CategoryDto> CategoryDtos { get; set; }
        public List<ProductPictureDto> ProductPictureDtos { get; set; }
    }
    
}
