using Domain.Abstraction;
using Domain.Categories;
using MediatR;

namespace Application.UseCase.Categories.CreateCategory;

internal sealed record CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryRepository.CreateAsync(request.Name, cancellationToken);

        await _unitOfWork.SaveChangesAsync();
    }
}
