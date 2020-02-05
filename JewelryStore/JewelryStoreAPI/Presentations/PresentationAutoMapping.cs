using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Presentations.Bijouterie;

namespace JewelryStoreAPI.Presentations
{
    public class PresentationAutoMapping : Profile
    {
        public PresentationAutoMapping()
        {
            CreateMap<BijouterieDto, BijouterieModel>();

            CreateMap<CreateBijouterieModel, CreateBijouterieDto>();

            CreateMap<UpdateBijouterieModel, UpdateBijouterieDto>();
        }
    }
}
