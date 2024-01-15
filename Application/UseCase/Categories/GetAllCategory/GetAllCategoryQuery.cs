
using MediatR;

namespace Application.UseCase.Categories.GetAllCategory;
using Domain.Categories;
public sealed record GetAllCategoryQuery() : IRequest<List<Category>>;
