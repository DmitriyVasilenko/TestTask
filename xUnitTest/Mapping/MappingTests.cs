using AutoMapper;
using System.Runtime.Serialization;
using Application.Mapper;
using Application.Services.Dtos;
using Domain.Entity;

namespace xUnitTest.Mapping;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;
    public MappingTests()
    {
        _configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMappingProfile>();
        });
        _mapper = _configuration.CreateMapper();
    }
    [Fact]
    public void ShouldBeValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Theory]
    [InlineData(typeof(BanksTotalDto), typeof(BanksTotal))]
    [InlineData(typeof(BanksTotalReadDto), typeof(BanksTotal))]
    [InlineData(typeof(BanksTotalСreatOrUpdateDto), typeof(BanksTotal))]
    [InlineData(typeof(BanksTotal), typeof(BanksTotalDto))]
    [InlineData(typeof(BanksTotal), typeof(BanksTotalReadDto))]
    [InlineData(typeof(BanksTotal), typeof(BanksTotalСreatOrUpdateDto))]
    public void Map_SourceToDestination_ExistConfiguration(Type origin, Type destination)
    {
        var instance = FormatterServices.GetUninitializedObject(origin);
        _mapper.Map(instance, origin, destination);
    }
}