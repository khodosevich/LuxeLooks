using LuxeLooks.DataManagment.Repositories.Interfaces;
using LuxeLooks.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace LuxeLooks.DataManagment.Repositories;

public class SubcribeRepository:IBaseRepository<Subscribe>
{
    public readonly ApplicationDbContext db;

    public SubcribeRepository(ApplicationDbContext db)
    {
        this.db = db;
    }

    public async Task Create(Subscribe entity)
    {
        await db.Subscribes.AddAsync(entity);
        await db.SaveChangesAsync();
    }

    public Task<List<Subscribe>> GetAll()
    {
        return db.Subscribes.ToListAsync();
    }

    public async Task Delete(Subscribe? entity)
    {
        db.Subscribes.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<Subscribe> Update(Subscribe entity)
    {
        db.Subscribes.Update(entity);
        await db.SaveChangesAsync();
        return entity;
    }
}