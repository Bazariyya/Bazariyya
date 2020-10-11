using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.eShopOnContainers.Services.Ordering.Domain.Seedwork;
using Product.Domain.AggregatesModel.ProductAggregate;
using Product.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Infrastructure
{
    public class ProductContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;
        public ProductContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public DbSet<Domain.AggregatesModel.ProductAggregate.Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(ConfigureCatalogType);
            modelBuilder.Entity<Brand>(ConfigureCatalogBrand);
            modelBuilder.Entity<ProductPicture>(ConfigureProductPictures);
            modelBuilder.Entity<Domain.AggregatesModel.ProductAggregate.Product>(ConfigureProduct);

            modelBuilder.Entity<ProductCategory>()
                .HasKey(cs => new { cs.ProductId, cs.CategoryId});

        }

        private void ConfigureProduct(EntityTypeBuilder<Domain.AggregatesModel.ProductAggregate.Product> builder)
        {
            builder.Property(c => c.Id).IsRequired(true).IsUnicode(true);
            builder.HasOne(c => c.Brand)
                .WithMany()
                .HasForeignKey(c => c.BrandId);
           
            builder.Property(c => c.Price).HasColumnType("decimal(18,2)");

        }

        private void ConfigureCatalogBrand(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(c => c.Id).IsRequired(true).IsUnicode(true);
        }

        private void ConfigureCatalogType(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Id).IsRequired(true).IsUnicode(true);
            
        }

        private void ConfigureProductPictures(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.Property(c => c.Id).IsRequired(true).IsUnicode(true);
            builder.HasOne(c => c.Product)
               .WithMany(p => p.ProductPictures)
               .HasForeignKey(x => x.ProductId);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
