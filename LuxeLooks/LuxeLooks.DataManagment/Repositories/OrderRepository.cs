using LuxeLooks.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace LuxeLooks.DataManagment.Repositories;

public class OrderRepository 
{
    public readonly ApplicationDbContext db;

    public OrderRepository(ApplicationDbContext db)
    {
        this.db = db;
    }

    public async Task Create(Order? entity)
    {
        await db.Orders.AddAsync(entity);
        await db.SaveChangesAsync();
    }

    public Task<List<Order>> GetAll()
    {
        return db.Orders.ToListAsync();
    }
    
    public async Task Delete(Order entity)
    {
        db.Orders.Remove(entity);
        await db.SaveChangesAsync();
    }

    public async Task<Order> Update(Order entity)
    {
        db.Orders.Update(entity);
        await db.SaveChangesAsync();
        return entity;
    }
}