using LuxeLooks.DataManagment.Repositories.Interfaces;
using LuxeLooks.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace LuxeLooks.DataManagment.Repositories.Implementations;

public class ReviewRepository:IBaseRepository<Review>
{
    private readonly ApplicationDbContext _db;

    public ReviewRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task Create(Review? entity)
    {
        await _db.Reviews.AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public Task<List<Review>> GetAll()
    {
        return _db.Reviews.ToListAsync();
    }

    public async Task Delete(Review? entity)
    {
        _db.Reviews.Remove(entity);
        await _db.SaveChangesAsync();
    }

    public async Task<Review> Update(Review entity)
    {
        _db.Reviews.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}