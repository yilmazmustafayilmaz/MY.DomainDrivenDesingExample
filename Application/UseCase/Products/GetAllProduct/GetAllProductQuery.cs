using Domain.Products;
using MediatR;

namespace Application.UseCase.Products.GetAllProduct;

public sealed record GetAllProductQuery() : IRequest<List<Product>>;
