using Application.Services.Dtos;
using Domain.Enum;

namespace Application.Services;

public interface IBanksTotalService
{
    /// <summary>
    /// Получить списов банков
    /// </summary>
    /// <returns></returns>
    Task<List<BanksTotalReadDto>> GetAsync();    
    /// <summary>
    /// Получить информацию по банку
    /// </summary>
    /// <param name="bank">По наименованию банка</param>
    /// <returns></returns>
    Task<BanksTotalDto> GetAsync(Bank bank);
    /// <summary>
    /// Получить информацию по банку
    /// </summary>
    /// <param name="Id">По идентификатору банка</param>
    /// <returns></returns>
    Task<BanksTotalDto> GetAsync(Guid Id);
    /// <summary>
    /// Создать новый банк
    /// </summary>
    /// <param name="inEntityDto"></param>
    /// <returns></returns>
    Task CreateAsync(BanksTotalСreatOrUpdateDto entity);
    /// <summary>
    /// Добавить данные к банку
    /// </summary>
    /// <param name="Id">По идентификатору банка</param>
    /// <param name="entityOld"></param>
    /// <param name="entityNew"></param>
    /// <returns></returns>
    Task CreateAsync(Guid Id, BanksTotalDto entityOld, BanksTotalСreatOrUpdateDto entityNew);
    /// <summary>
    /// Изменить информацию по банку
    /// </summary>
    /// <param name="Id">По идентификатору банка</param>
    /// <param name="inEntityDto"></param>
    /// <returns></returns>
    Task UpdateAsync(Guid Id, BanksTotalСreatOrUpdateDto entity);
    /// <summary>
    /// Удалить банк
    /// </summary>
    /// <param name="id">По идентификатору банка</param>
    /// <returns></returns>
    Task DetailAsync(Guid id);
}
