using Domain.Abstraction;
using Domain.Products;
using MediatR;

namespace Application.UseCase.Products.CreateProduct;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _productRepository.CreateAsync(request.Name,
                                             request.Quantity,
                                             request.Amount,
                                             request.Currency,
                                             request.CategoryId,
                                             cancellationToken);
        await _unitOfWork.SaveChangesAsync();
    }
}
