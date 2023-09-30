using LuxeLooks.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace LuxeLooks.DataManagment.Repositories;

public class RoleRepository
{
    public readonly ApplicationDbContext db;

    public RoleRepository(ApplicationDbContext db)
    {
        this.db = db;
    }

    public async Task Create(Role entity)
    {
        await db.Roles.AddAsync(entity);
        await db.SaveChangesAsync();
    }

    public Task<List<Role>> GetAll()
    {
        return db.Roles.ToListAsync();
    }

    public async Task Delete(Role? entity)
    {
        db.Roles.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<Role> Update(Role entity)
    {
        db.Roles.Update(entity);
        await db.SaveChangesAsync();
        return entity;
    }
}