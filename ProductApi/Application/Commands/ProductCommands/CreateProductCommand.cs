using Product.API.Application.Models;
using Product.Domain.SeedWork;
using System.Collections.Generic;

namespace Product.API.Application.Commands.ProductCommands
{
    public class CreateProductCommand : BaseCommand<bool>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Code { get; set; }
        public int Units { get; set; }
        public int BrandId { get; set; }
        public int CatalogId { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PictureFileName { get; set; }
        public string PictureUrl { get; set; }
        public List<CategoryDto> CategoryDtos { get; set; }
        public List<ProductPictureDto> ProductPictureDtos { get; set; }
    }
}
