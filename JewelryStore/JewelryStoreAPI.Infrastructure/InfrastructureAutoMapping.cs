using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;

namespace JewelryStoreAPI.Infrastructure
{
    public class InfrastructureAutoMapping : Profile
    {
        public InfrastructureAutoMapping()
        {
            CreateMap<Bijouterie, GetBijouterieDto>()
                .ForMember(d => d.BrandName, opt => opt.MapFrom(s => s.Brand != null ? s.Brand.Name : null))
                .ForMember(d => d.CountryName, opt => opt.MapFrom(s => s.Country != null ? s.Country.Name : null))
                .ForMember(d => d.BijouterieTypeName, opt => opt.MapFrom(s => s.BijouterieType != null ? s.BijouterieType.Name : null));

            CreateMap<CreateBijouterieDto, Bijouterie>();
        }
    }
}
