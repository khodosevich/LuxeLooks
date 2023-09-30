using LuxeLooks.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace LuxeLooks.DataManagment.Repositories;

public class UserRepository
{
    public readonly ApplicationDbContext db;

    public UserRepository(ApplicationDbContext db)
    {
        this.db = db;
    }

    public async Task Create(User? entity)
    {
        await db.Users.AddAsync(entity);
        await db.SaveChangesAsync();
    }

    public Task<List<User>> GetAll()
    {
        return db.Users.ToListAsync();
    }

    public async Task Delete(User? entity)
    {
        db.Users.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<User> Update(User entity)
    {
        db.Users.Update(entity);
        await db.SaveChangesAsync();
        return entity;
    }
}