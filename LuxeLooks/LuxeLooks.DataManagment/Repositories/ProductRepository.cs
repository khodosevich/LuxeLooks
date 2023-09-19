using LuxeLooks.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace LuxeLooks.DataManagment.Repositories;

public class ProductRepository
{
    public readonly ApplicationDbContext db;

    public ProductRepository(ApplicationDbContext db)
    {
        this.db = db;
    }

    public async Task Create(Product? entity)
    {
        await db.Products.AddAsync(entity);
        await db.SaveChangesAsync();
    }

    public Task<List<Product>> GetAll()
    {
        return db.Products.ToListAsync();
    }

    public async Task Delete(Product? entity)
    {
        db.Products.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<Product> Update(Product entity)
    {
        db.Products.Update(entity);
        await db.SaveChangesAsync();
        return entity;
    }
}