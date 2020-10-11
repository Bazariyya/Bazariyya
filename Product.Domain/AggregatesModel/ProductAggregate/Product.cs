using Microsoft.eShopOnContainers.Services.Ordering.Domain.Seedwork;
using Product.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Domain.AggregatesModel.ProductAggregate
{
    [Table("Product")]
    public class Product : Entity, IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string PictureFileName { get; set; }
        public string PictureUrl { get; set; }
        public int Units { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public Brand Brand { get; set; }
        private List<ProductCategory> _productCategories;
        public List<ProductCategory> ProductCategories {
            get { return _productCategories ?? (_productCategories = new List<ProductCategory>()); }
            set { _productCategories = value; }
        }

        public List<ProductPicture> _productPictures;
        public List<ProductPicture> ProductPictures {
            get { return _productPictures ?? (_productPictures = new List<ProductPicture>()); }
            set { _productPictures = value; }
        }


        public Product()
        {

        }

        public void DeletePictureById(int pictureId)
        {
            var existingForFileName = ProductPictures.Where(o => o.ProductId == pictureId)
               .SingleOrDefault();
            if (existingForFileName != null)
            {
                ProductPictures.Remove(existingForFileName);
            }
        }

        public void DeletePictureByName(string fileName)
        {
            var existingForFileName = ProductPictures.Where(o => o.FileName == fileName)
               .SingleOrDefault();
            if (existingForFileName != null)
            {
                ProductPictures.Remove(existingForFileName);
            }
        }

        public void AddPicture(Enums.RecordStatu recordStatu, string fileName, bool isDefault, bool statu, string thumbFileName)
        {
            var existingForFileName = ProductPictures.Where(o => o.FileName == fileName)
               .SingleOrDefault();

            if (existingForFileName != null)
            {
                existingForFileName.FileName = fileName;
                existingForFileName.ThumbFileName = thumbFileName;
                existingForFileName.IsDefault = isDefault;
                existingForFileName.Statu = statu;
            }
            else
            {
                //add validated new order item

                var picture = new ProductPicture(recordStatu, Id, fileName, isDefault, statu, thumbFileName);
                ProductPictures.Add(picture);
            }
        }

        public void AddCategory(int categoryId, string categoryName)
        {
            var existingCategory = ProductCategories.FirstOrDefault(o => o.CategoryId == categoryId);

            if (existingCategory == null)
            {
                ProductCategories.Add(new ProductCategory { 
                    CategoryId = categoryId,
                    ProductId = Id
                });
            }
        }

    }
}
