using Application.Extensions;
using Application.Services.Dtos;
using AutoMapper;
using Domain.Entity;
using Domain.Enum;

namespace Application.Mapper;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        CreateMap<BanksTotal, BanksTotalDto>().ReverseMap();
        CreateMap<BanksTotal, BanksTotalСreatOrUpdateDto>().ReverseMap();
        CreateMap<BanksTotal, BanksTotalReadDto>()
            .ForMember(dest => dest.Bank, opt => opt.MapFrom(src => src.Bank.GetDescription()))
            .ReverseMap()
            .ForMember(dest => dest.Bank, opt => opt.MapFrom(src => src.Bank.ParseEnum<Bank>()));
    }

}
