using Domain.Entities.Abstracts;

namespace Infrastructure.Repositoies;

public interface IBaseRepository<TEntity> where TEntity : EntityBase
{
    /// <summary>
    /// Получения из базы списка банков
    /// </summary>
    /// <param name="disableTracking"></param>
    /// <returns></returns>
    Task<List<TEntity>> ToListAsync(bool disableTracking = true);
    /// <summary>
    /// Получение из базы информации банка
    /// </summary>
    /// <param name="id">По идентификатору</param>
    /// <param name="disableTracking"></param>
    /// <returns></returns>
    Task<TEntity?> GetAsync(Guid id, bool disableTracking = true);
    /// <summary>
    /// Создание в базе нового банка
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Task CreateAsync(TEntity entity);
    /// <summary>
    /// Обновления в базе информации по баку
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Task UpdateAsync(TEntity entity);
    /// <summary>
    /// Удаление из базы банка
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    Task DeleteAsync(Guid id);
}
