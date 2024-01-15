using Domain.Users;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> CreateAsync(string name, string email, string password, string coutry, string city, string street, string fullAddress, string postalCode, CancellationToken cancellationToken = default)
    {
        User user = User.CreateUser(name, email, password, coutry, city, street, fullAddress, postalCode);
        await _context.Users.AddAsync(user, cancellationToken);
        return user;
    }

    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Users.ToListAsync(cancellationToken);
    }
}
