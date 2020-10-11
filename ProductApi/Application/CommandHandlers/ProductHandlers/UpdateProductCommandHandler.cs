using MediatR;
using Product.API.Application.Commands.ProductCommands;
using Product.API.Application.IntegrationEvents;
using Product.API.Application.Models;
using Product.Domain.AggregatesModel.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Product.API.Application.CommandHandlers.ProductHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        IProductRepository _productRepository;
        IProductIntegrationEventService _productIntegrationEventService;
        public UpdateProductCommandHandler(IProductRepository productRepository,
            IProductIntegrationEventService productIntegrationEventService)
        {
            _productRepository = productRepository ?? throw new Exception();
            _productIntegrationEventService = productIntegrationEventService;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Domain.AggregatesModel.ProductAggregate.Product product =
                new Domain.AggregatesModel.ProductAggregate.Product
                {
                    Id = request.ProductId,
                    Name = request.ProductName,
                    Code = request.Code,
                    Description = request.Description,
                    PictureFileName = request.PictureFileName,
                    PictureUrl = request.PictureUrl,
                    BrandId = request.BrandId,
                    CategoryId = request.CatalogId,
                    Units = request.Units,
                    Price = request.Price
                };

            AddPictures(request, product);
            AddCategoryes(request, product);

            _productRepository.Update(product);
            return await _productRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

        private void AddPictures(UpdateProductCommand request, Domain.AggregatesModel.ProductAggregate.Product product)
        {
            if (request.ProductPictureDtos != null && request.ProductPictureDtos.Count > 0)
            {
                request.ProductPictureDtos.ForEach((ProductPictureDto dto) =>
                {
                    product.AddPicture(dto.recordStatu, dto.FileName, dto.IsDefault, dto.Statu, dto.ThumbFileName);
                });
            }
        }

        private void AddCategoryes(UpdateProductCommand request, Domain.AggregatesModel.ProductAggregate.Product product)
        {
            if (request.CategoryDtos != null && request.CategoryDtos.Count > 0)
            {
                request.CategoryDtos.ForEach((CategoryDto dto) =>
                {
                    product.AddCategory(dto.Id, dto.Name);
                });
            }
        }
    }
}
