using Application.Services;
using Application.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Produces("application/json")]
[Consumes(MediaTypeNames.Application.Json)]
public class BanksTotalController : ControllerBase
{
    private IBanksTotalService _service { get; set; }

    public BanksTotalController(IBanksTotalService service)
    {
        _service = service;
    }
    /// <summary>
    /// Запрос получения списка банков
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BanksTotalReadDto>))]
    public async Task<JsonResult> ReadAsync()
    {
        return new JsonResult(await _service.GetAsync());
    }
    /// <summary>
    /// Запрос получения подробной информации по банку
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException"></exception>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BanksTotalReadDto>))]
    public async Task<JsonResult> ReadAsync(Guid id)
    {
        var model = await _service.GetAsync(id);
        if (model == null)
            return new JsonResult("Объект не найнен!!!");
        return new JsonResult(model);
    }
    /// <summary>
    /// Запрос на создание нового банка
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="AppException"></exception>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    public async Task<JsonResult> CreateAsync([FromBody] BanksTotalСreatOrUpdateDto value)
    {
        bool success = true;
        try
        {
            if (!ModelState.IsValid)
                return new JsonResult("Не соответствие модели!");
            var model = await _service.GetAsync(value.Bank);
            if (model != null)
                return new JsonResult("Банк уже существует!!!");
            await _service.CreateAsync(value);
        }
        catch (Exception)
        {
            success = false;
        }

        return success ? new JsonResult("Успешно!!!") : new JsonResult("Не успешно!!!");
    }
    /// <summary>
    /// Запрос на добавления активов в банк
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="AppException"></exception>
    /// <exception cref="KeyNotFoundException"></exception>
    [HttpPost("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    public async Task<JsonResult> CreateAsync(Guid id, [FromBody] BanksTotalСreatOrUpdateDto value)
    {
        bool success = false;       
        try
        {
            if (!ModelState.IsValid)
                return new JsonResult("Не соответствие модели!");
            var model = await _service.GetAsync(id);
            if (model == null)
                return new JsonResult("Объект не найнен!!!");
            await _service.CreateAsync(id, model, value);
            success = true;
        }
        catch (Exception)
        {

        }

        return success ? new JsonResult("Успешно!!!") : new JsonResult("Не успешно!!!");
    }
    /// <summary>
    /// Запрос на изменения банка
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="AppException"></exception>
    /// <exception cref="KeyNotFoundException"></exception>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    public async Task<JsonResult> UpdateAsync(Guid id, [FromBody] BanksTotalСreatOrUpdateDto value)
    {
        bool success = false;
        try
        {
            if (!ModelState.IsValid)
                return new JsonResult("Не соответствие модели!");
            var model = await _service.GetAsync(id);
            if (model == null)
                return new JsonResult("Объект не найнен!!!");
            await _service.UpdateAsync(id, value);
            success = true;
        }
        catch (Exception)
        {
        }

        return success ? new JsonResult("Успешно!!!") : new JsonResult("Не успешно!!!");
    }
    /// <summary>
    /// Запрос на удаления банка
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="AppException"></exception>
    /// <exception cref="KeyNotFoundException"></exception>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    public async Task<JsonResult> DeleteAsync(Guid id)
    {
        bool success = false;
        try
        {
            if (!ModelState.IsValid)
                return new JsonResult("Не соответствие модели!");
            var model = await _service.GetAsync(id);
            if (model == null)
                return new JsonResult("Объект не найнен!!!");
            await _service.DetailAsync(id);
            success = true;
        }
        catch (Exception)
        {

        }

        return success ? new JsonResult("Успешно!!!") : new JsonResult("Не успешно!!!");
    }
}
