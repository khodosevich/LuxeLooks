using LuxeLooks.DataManagment.Repositories.Interfaces;
using LuxeLooks.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace LuxeLooks.DataManagment.Repositories;

public class CategoryRepository:IBaseRepository<Category>
{
    public readonly ApplicationDbContext db;

    public CategoryRepository(ApplicationDbContext db)
    {
        this.db = db;
    }

    public async Task Create(Category? entity)
    {
        await db.Categories.AddAsync(entity);
        await db.SaveChangesAsync();
    }

    public Task<List<Category>> GetAll()
    {
        return db.Categories.ToListAsync();
    }

    public async Task Delete(Category? entity)
    {
        db.Categories.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<Category> Update(Category entity)
    {
        db.Categories.Update(entity);
        await db.SaveChangesAsync();
        return entity;
    }
}