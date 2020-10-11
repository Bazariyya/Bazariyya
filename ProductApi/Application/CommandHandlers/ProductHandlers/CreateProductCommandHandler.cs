using MediatR;
using Product.API.Application.Commands.ProductCommands;
using Product.API.Application.IntegrationEvents;
using Product.API.Application.IntegrationEvents.Events;
using Product.API.Application.Models;
using Product.Domain.AggregatesModel.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Product.API.Application.CommandHandlers.ProductHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        IProductRepository _productRepository;
        IProductIntegrationEventService _productIntegrationEventService;
        public CreateProductCommandHandler(IProductRepository productRepository,
            IProductIntegrationEventService productIntegrationEventService)
        {
            _productRepository = productRepository ?? throw new Exception();
            _productIntegrationEventService = productIntegrationEventService;
        }
        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Domain.AggregatesModel.ProductAggregate.Product product =
                _productRepository.Add(new Domain.AggregatesModel.ProductAggregate.Product
                {
                    Code = request.Code,
                    Name = request.ProductName,
                    Description = request.Description,
                    PictureFileName = request.PictureFileName,
                    PictureUrl = request.PictureUrl,
                    BrandId = request.BrandId,
                    CategoryId = request.CatalogId,
                    Units = request.Units,
                    Price = request.Price
                });

            AddPictures(request, product);
            AddCategoryes(request, product);

            await _productIntegrationEventService.PublishEventsThroughEventBusAsync(
                    new ProductAddedIntegrationEvent
                    {
                        productId = product.Id
                    }
                );
            return await _productRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
        private void AddPictures(CreateProductCommand request, Domain.AggregatesModel.ProductAggregate.Product product)
        {
            if (request.ProductPictureDtos != null && request.ProductPictureDtos.Count > 0)
            {
                request.ProductPictureDtos.ForEach((ProductPictureDto dto) =>
                {
                    product.AddPicture(dto.recordStatu, dto.FileName, dto.IsDefault, dto.Statu, dto.ThumbFileName);
                });
            }
        }
        
        private void AddCategoryes(CreateProductCommand request, Domain.AggregatesModel.ProductAggregate.Product product)
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
