using AutoMapper;
using Application.Services.Dtos;
using Infrastructure.Repositoies;
using Domain.Entity;
using Application.Stratrgy.Interface;
using Domain.Enum;

namespace Application.Services;

public class BanksTotalService : IBanksTotalService
{
    private readonly IBanksTotalRepository _repository;
    private readonly IMapper _mapper;
    private readonly ITotalContext _totalContext;
    public BanksTotalService(
        IBanksTotalRepository repository, 
        IMapper mapper,
        ITotalContext totalContext)
    {
        _repository = repository;
        _mapper = mapper;
        _totalContext = totalContext;
    }
    /// <summary>
    /// Получить списов банков
    /// </summary>
    /// <returns></returns>
    public async Task<List<BanksTotalReadDto>> GetAsync()
    {
        var entity = await _repository.ToListAsync();
        var entityDto = _mapper.Map<List<BanksTotalReadDto>>(entity);
        return entityDto;
    }
    /// <summary>
    /// Получить информацию по банку
    /// </summary>
    /// <param name="Id">По идентификатору банка</param>
    /// <returns></returns>
    public async Task<BanksTotalDto> GetAsync(Guid Id)
    {
        var entity = await _repository.GetAsync(Id, false);
        var outEntityDto = _mapper.Map<BanksTotalDto>(entity);
        return outEntityDto;
    }
    /// <summary>
    /// Получить информацию по банку
    /// </summary>
    /// <param name="bank">По наименованию банка</param>
    /// <returns></returns>
    public async Task<BanksTotalDto> GetAsync(Bank bank)
    {
        var entity = await _repository.GetAsync(bank, false);
        var outEntityDto = _mapper.Map<BanksTotalDto>(entity);
        return outEntityDto;
    }
    /// <summary>
    /// Создать новый банк
    /// </summary>
    /// <param name="inEntityDto"></param>
    /// <returns></returns>
    public async Task CreateAsync(BanksTotalСreatOrUpdateDto inEntityDto)
    {
        var entity = _mapper.Map<BanksTotal>(inEntityDto);
        entity.Id = Guid.NewGuid();
        await _repository.CreateAsync(entity);
    }
    /// <summary>
    /// Добавить данные к банку
    /// </summary>
    /// <param name="Id">По идентификатору банка</param>
    /// <param name="entityOld"></param>
    /// <param name="entityNew"></param>
    /// <returns></returns>
    public async Task CreateAsync(Guid Id, BanksTotalDto entityOld, BanksTotalСreatOrUpdateDto entityNew)
    {
        var entity = _mapper.Map<BanksTotal>(entityNew);
        entity.Id = Id;
        _totalContext.SetStrategy((int)entity.Bank);
        entity.Total = entityOld.Total + _totalContext.ExecuteStrategy(entity.Total);
        await _repository.UpdateAsync(entity);
    }
    /// <summary>
    /// Изменить информацию по банку
    /// </summary>
    /// <param name="Id">По идентификатору банка</param>
    /// <param name="inEntityDto"></param>
    /// <returns></returns>
    public async Task UpdateAsync(Guid Id, BanksTotalСreatOrUpdateDto inEntityDto)
    {
        var entity = _mapper.Map<BanksTotal>(inEntityDto);
        entity.Id = Id;
        await _repository.UpdateAsync(entity);
    }
    /// <summary>
    /// Удалить банк
    /// </summary>
    /// <param name="id">По идентификатору банка</param>
    /// <returns></returns>
    public async Task DetailAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
