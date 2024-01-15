using MediatR;

namespace Application.UseCase.Categories.CreateCategory;

public sealed record CreateCategoryCommand(
    string Name) : IRequest;
