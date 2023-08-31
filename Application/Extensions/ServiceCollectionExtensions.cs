using Application.Mapper;
using Application.Services;
using Application.Stratrgy;
using Application.Stratrgy.Interface;
using AutoMapper;
using Infrastructure.Repositoies;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        #region Mapper
        var mappimgConfig = new MapperConfiguration(mc => mc.AddProfile(new AutoMappingProfile()));
        IMapper mapper = mappimgConfig.CreateMapper();
        services.AddSingleton(mapper);
        #endregion

        services.AddScoped<IBanksTotalService, BanksTotalService>();
        services.AddScoped<IBanksTotalRepository, BanksTotalRepository>();
        services.AddScoped<ITotalContext, TotalContext>();

        return services;
    }
}
