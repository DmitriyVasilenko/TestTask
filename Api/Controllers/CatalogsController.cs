using Application.Extensions;
using Application.Services.Catalog;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Produces("application/json")]
[Consumes(MediaTypeNames.Application.Json)]
public class CatalogsController : ControllerBase
{
    /// <summary>
    /// Запрос получения справочника наименований банков
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BankDto>))]
    public JsonResult GetBank()
    {
        return new JsonResult(EnumExtensions.ToListEnum<Bank>());
    }

}
