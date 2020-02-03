using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;

namespace JewelryStoreAPI.Presentations
{
    public class PresentationAutoMapping : Profile
    {

        public PresentationAutoMapping()
        {
            CreateMap<GetBijouterieDto, BijouterieModel>();
        }
    }
}
