using Microsoft.eShopOnContainers.Services.Ordering.Domain.Seedwork;
using Product.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Product.Domain.AggregatesModel.ProductAggregate
{
    [Table("ProductPicture")]
    public class ProductPicture : Entity, IAggregateRoot
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string FileName { get; set; }
        public bool IsDefault { get; set; }
        public bool Statu { get; set; }
        public string ThumbFileName { get; set; }
        public Product Product { get; set; }

        public ProductPicture() { }

        public ProductPicture(Enums.RecordStatu recordStatu, int productId, string fileName, bool isDefault, bool statu, string thumbFileName)
        {
            this.recordStatu = recordStatu;
            ProductId = productId;
            FileName = fileName;
            ThumbFileName = thumbFileName;
            IsDefault = isDefault;
            Statu = statu;
        }
        
    }
}
