using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.AggregatesModel.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Data
{
    public class ProductDbContext //: DbContext
    {
        //public ProductDbContext(DbContextOptions options): base(options)
        //{

        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CatalogType>(ConfigureCatalogType);
        //    modelBuilder.Entity<CatalogBrand>(ConfigureCatalogBrand);
        //    modelBuilder.Entity<Product.Domain.AggregatesModel.ProductAggregate.Product>(ConfigureProduct);

        //}

        //private void ConfigureProduct(EntityTypeBuilder<Product.Domain.AggregatesModel.ProductAggregate.Product> builder)
        //{
        //    builder.Property(c => c.Id).IsRequired(true).IsUnicode(true);
        //    builder.HasOne(c => c.CatalogBrand)
        //        .WithMany()
        //        .HasForeignKey(c => c.CatalogBrandId);
        //    builder.HasOne(c => c.CatalogType)
        //        .WithMany()
        //        .HasForeignKey(c => c.CatalogTypeId);
            
        //}

        //private void ConfigureCatalogBrand(EntityTypeBuilder<CatalogBrand> builder)
        //{
        //    builder.Property(c => c.Id).IsRequired(true).IsUnicode(true);
        //}

        //private void ConfigureCatalogType(EntityTypeBuilder<CatalogType> builder)
        //{
        //    builder.Property(c => c.Id).IsRequired(true).IsUnicode(true);
        //}

    }
}
