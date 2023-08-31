using Application.Extensions;
using Domain.Entities.Abstracts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositoies;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase
{
    private readonly ApplicationDbContext _dbContext;
    protected readonly DbSet<TEntity> DBSet;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        DBSet = this._dbContext.Set<TEntity>();
    }
    /// <summary>
    /// Получения из базы списка банков
    /// </summary>
    /// <param name="disableTracking"></param>
    /// <returns></returns>
    public async Task<List<TEntity>> ToListAsync(bool disableTracking = true)
    {
        _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        IQueryable<TEntity> query = DBSet;
        if (!disableTracking)
            query = query.Where(true).AsNoTracking();
        else
            query = query.Where(true);
        return await query.ToListAsync();
    }
    /// <summary>
    /// Получение из базы информации банка
    /// </summary>
    /// <param name="id">По идентификатору</param>
    /// <param name="disableTracking"></param>
    /// <returns></returns>
    public async Task<TEntity?> GetAsync(Guid id, bool disableTracking = true)
    {
        _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        IQueryable<TEntity> query = DBSet;
        if (!disableTracking)
            query = query.Where(m => m.Id == id).AsNoTracking();
        else
            query = query.Where(m => m.Id == id);
        return await query.FirstOrDefaultAsync();
    }
    /// <summary>
    /// Создание в базе нового банка
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task CreateAsync(TEntity entity)
    {
        try
        {
            _dbContext.ChangeTracker.AutoDetectChangesEnabled = true;
            DBSet.Attach(entity).State = EntityState.Added;
            await DBSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    /// <summary>
    /// Обновления в базе информации по баку
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task UpdateAsync(TEntity entity)
    {
        try
        {
            _dbContext.ChangeTracker.AutoDetectChangesEnabled = true;
            DBSet.Attach(entity).State = EntityState.Modified;
            DBSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    /// <summary>
    /// Удаление из базы банка
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task DeleteAsync(Guid id)
    {
        try
        {
            var entity = await DBSet.FirstOrDefaultAsync(m => m.Id == id);
            if (entity == null)
                return;
            DBSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
