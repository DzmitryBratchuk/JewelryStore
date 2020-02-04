using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Presentations.Bijouterie;

namespace JewelryStoreAPI.Presentations
{
    public class PresentationAutoMapping : Profile
    {
        public PresentationAutoMapping()
        {
            CreateMap<GetBijouterieDto, GetBijouterieModel>();

            CreateMap<CreateBijouterieDto, GetBijouterieModel>();

            CreateMap<CreateBijouterieModel, CreateBijouterieDto>();

            CreateMap<UpdateBijouterieModel, UpdateBijouterieDto>();
        }
    }
}
