using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.CommandsDTO;
using JewelryStoreAPI.Infrastructure.QueriesDTO;

namespace JewelryStoreAPI.Infrastructure
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Bijouterie, BijouterieQueryDTO>()
                .ForMember(d => d.BrandName, opt => opt.MapFrom(s => s.Brand != null ? s.Brand.Name : string.Empty))
                .ForMember(d => d.CountryName, opt => opt.MapFrom(s => s.Country != null ? s.Country.Name : string.Empty))
                .ForMember(d => d.BijouterieTypeName, opt => opt.MapFrom(s => s.BijouterieType != null ? s.BijouterieType.Name : string.Empty));

            CreateMap<BijouterieCommandDTO, Bijouterie>();
        }
    }
}
