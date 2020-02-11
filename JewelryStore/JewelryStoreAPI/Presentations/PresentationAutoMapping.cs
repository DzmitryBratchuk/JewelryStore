using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Bijouterie;
using JewelryStoreAPI.Infrastructure.DTO.BijouterieType;
using JewelryStoreAPI.Infrastructure.DTO.Brand;
using JewelryStoreAPI.Infrastructure.DTO.Country;
using JewelryStoreAPI.Infrastructure.DTO.Order;
using JewelryStoreAPI.Infrastructure.DTO.PreciousItem;
using JewelryStoreAPI.Infrastructure.DTO.PreciousItemType;
using JewelryStoreAPI.Infrastructure.DTO.ProductBasket;
using JewelryStoreAPI.Infrastructure.DTO.ProductOrder;
using JewelryStoreAPI.Infrastructure.DTO.Report;
using JewelryStoreAPI.Infrastructure.DTO.Role;
using JewelryStoreAPI.Infrastructure.DTO.User;
using JewelryStoreAPI.Infrastructure.DTO.Watch;
using JewelryStoreAPI.Presentations.Bijouterie;
using JewelryStoreAPI.Presentations.BijouterieType;
using JewelryStoreAPI.Presentations.Brand;
using JewelryStoreAPI.Presentations.Country;
using JewelryStoreAPI.Presentations.Order;
using JewelryStoreAPI.Presentations.PreciousItem;
using JewelryStoreAPI.Presentations.PreciousItemType;
using JewelryStoreAPI.Presentations.ProductBasket;
using JewelryStoreAPI.Presentations.ProductOrder;
using JewelryStoreAPI.Presentations.Report;
using JewelryStoreAPI.Presentations.Role;
using JewelryStoreAPI.Presentations.User;
using JewelryStoreAPI.Presentations.Watch;

namespace JewelryStoreAPI.Presentations
{
    public class PresentationAutoMapping : Profile
    {
        public PresentationAutoMapping()
        {
            CreateMap<BijouterieDto, BijouterieModel>();

            CreateMap<CreateBijouterieModel, CreateBijouterieDto>();

            CreateMap<UpdateBijouterieModel, UpdateBijouterieDto>();

            CreateMap<UserDto, UserModel>();

            CreateMap<AuthenticateModel, AuthenticateDto>();

            CreateMap<CreateUserModel, CreateUserDto>();

            CreateMap<UpdateUserModel, UpdateUserDto>();

            CreateMap<ChangeUserPasswordModel, ChangeUserPasswordDto>();

            CreateMap<ChangeUserRoleModel, ChangeUserRoleDto>();

            CreateMap<RoleDto, RoleModel>();

            CreateMap<CreateRoleModel, CreateRoleDto>();

            CreateMap<UpdateRoleModel, UpdateRoleDto>();

            CreateMap<CountryDto, CountryModel>();

            CreateMap<CreateCountryModel, CreateCountryDto>();

            CreateMap<UpdateCountryModel, UpdateCountryDto>();

            CreateMap<BrandDto, BrandModel>();

            CreateMap<CreateBrandModel, CreateBrandDto>();

            CreateMap<UpdateBrandModel, UpdateBrandDto>();

            CreateMap<BijouterieTypeDto, BijouterieTypeModel>();

            CreateMap<CreateBijouterieTypeModel, CreateBijouterieTypeDto>();

            CreateMap<UpdateBijouterieTypeModel, UpdateBijouterieTypeDto>();

            CreateMap<PreciousItemTypeDto, PreciousItemTypeModel>();

            CreateMap<CreatePreciousItemTypeModel, CreatePreciousItemTypeDto>();

            CreateMap<UpdatePreciousItemTypeModel, UpdatePreciousItemTypeDto>();

            CreateMap<PreciousItemDto, PreciousItemModel>();

            CreateMap<CreatePreciousItemModel, CreatePreciousItemDto>();

            CreateMap<UpdatePreciousItemModel, UpdatePreciousItemDto>();

            CreateMap<WatchDto, WatchModel>();

            CreateMap<CreateWatchModel, CreateWatchDto>();

            CreateMap<UpdateWatchModel, UpdateWatchDto>();

            CreateMap<ProductBasketDto, ProductBasketModel>();

            CreateMap<AddProductInBasketModel, AddProductInBasketDto>();

            CreateMap<UpdateProductBasketModel, UpdateProductBasketDto>();

            CreateMap<ProductOrderDto, ProductOrderModel>();

            CreateMap<CreateOrderModel, CreateOrderDto>();

            CreateMap<OrderDto, OrderModel>();

            CreateMap<ReportDto, ReportModel>();

            CreateMap<ReportWatchDto, ReportModel>();

            CreateMap<ReportPreciousItemDto, ReportModel>();

            CreateMap<ReportBijouterieDto, ReportModel>();
        }
    }
}
