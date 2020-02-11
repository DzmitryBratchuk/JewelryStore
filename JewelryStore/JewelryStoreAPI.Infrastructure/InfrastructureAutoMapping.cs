using AutoMapper;
using JewelryStoreAPI.Domain.Entities;
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
using System.Collections.Generic;
using System.Linq;

namespace JewelryStoreAPI.Infrastructure
{
    public class InfrastructureAutoMapping : Profile
    {
        public InfrastructureAutoMapping()
        {
            CreateMap<Bijouterie, BijouterieDto>()
                .ForMember(d => d.BrandName, opt => opt.MapFrom(s => s.Brand != null ? s.Brand.Name : null))
                .ForMember(d => d.CountryName, opt => opt.MapFrom(s => s.Country != null ? s.Country.Name : null))
                .ForMember(d => d.BijouterieTypeName, opt => opt.MapFrom(s => s.BijouterieType != null ? s.BijouterieType.Name : null));

            CreateMap<CreateBijouterieDto, Bijouterie>();

            CreateMap<UpdateBijouterieDto, Bijouterie>();

            CreateMap<User, UserDto>()
                .ForMember(d => d.RoleName, opt => opt.MapFrom(s => s.Role != null ? s.Role.Name : null));

            CreateMap<CreateUserDto, User>();

            CreateMap<Role, RoleDto>();

            CreateMap<CreateRoleDto, Role>();

            CreateMap<Country, CountryDto>();

            CreateMap<CreateCountryDto, Country>();

            CreateMap<Brand, BrandDto>();

            CreateMap<CreateBrandDto, Brand>();

            CreateMap<BijouterieType, BijouterieTypeDto>();

            CreateMap<CreateBijouterieTypeDto, BijouterieType>();

            CreateMap<PreciousItemType, PreciousItemTypeDto>();

            CreateMap<CreatePreciousItemTypeDto, PreciousItemType>();

            CreateMap<PreciousItem, PreciousItemDto>()
                .ForMember(d => d.BrandName, opt => opt.MapFrom(s => s.Brand != null ? s.Brand.Name : null))
                .ForMember(d => d.CountryName, opt => opt.MapFrom(s => s.Country != null ? s.Country.Name : null))
                .ForMember(d => d.PreciousItemTypeName, opt => opt.MapFrom(s => s.PreciousItemType != null ? s.PreciousItemType.Name : null))
                .ForMember(d => d.MetalType, opt => opt.MapFrom(s => s.PreciousItemType != null ? s.PreciousItemType.MetalType : default));

            CreateMap<CreatePreciousItemDto, PreciousItem>();

            CreateMap<UpdatePreciousItemDto, PreciousItem>();

            CreateMap<Watch, WatchDto>()
                .ForMember(d => d.BrandName, opt => opt.MapFrom(s => s.Brand != null ? s.Brand.Name : null))
                .ForMember(d => d.CountryName, opt => opt.MapFrom(s => s.Country != null ? s.Country.Name : null))
                .ForMember(d => d.DiameterInMillimeters, opt => opt.MapFrom(s => s.DiameterMM))
                .ForMember(d => d.CaseColor, opt => opt.MapFrom(s => s.CaseColorId))
                .ForMember(d => d.DialColor, opt => opt.MapFrom(s => s.DialColorId))
                .ForMember(d => d.StrapColor, opt => opt.MapFrom(s => s.StrapColorId));

            CreateMap<CreateWatchDto, Watch>()
                .ForMember(d => d.DiameterMM, opt => opt.MapFrom(s => s.DiameterInMillimeters))
                .ForMember(d => d.CaseColorId, opt => opt.MapFrom(s => s.CaseColor))
                .ForMember(d => d.DialColorId, opt => opt.MapFrom(s => s.DialColor))
                .ForMember(d => d.StrapColorId, opt => opt.MapFrom(s => s.StrapColor));

            CreateMap<UpdateWatchDto, Watch>()
                .ForMember(d => d.DiameterMM, opt => opt.MapFrom(s => s.DiameterInMillimeters))
                .ForMember(d => d.CaseColorId, opt => opt.MapFrom(s => s.CaseColor))
                .ForMember(d => d.DialColorId, opt => opt.MapFrom(s => s.DialColor))
                .ForMember(d => d.StrapColorId, opt => opt.MapFrom(s => s.StrapColor));

            CreateMap<ProductBasket, ProductBasketDto>()
                .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.ProductId))
                .ForMember(d => d.ProductName, opt => opt.MapFrom(s => s.Product != null ? s.Product.Name : null))
                .ForMember(d => d.ProductCost, opt => opt.MapFrom(s => s.Product != null ? s.Product.Cost : default))
                .ForMember(d => d.ProductCountInBasket, opt => opt.MapFrom(s => s.ProductCount))
                .ForMember(d => d.ProductCountInStore, opt => opt.MapFrom(s => s.Product != null ? s.Product.Amount : default));

            CreateMap<AddProductInBasketDto, ProductBasket>()
                .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.ProductId))
                .ForMember(d => d.ProductCount, opt => opt.MapFrom(s => s.ProductCount));

            CreateMap<Order, OrderDto>()
                .ForMember(d => d.OrderId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.OrderTime, opt => opt.MapFrom(s => s.OrderTime))
                .ForMember(d => d.ProductCount, opt => opt.MapFrom(s => s.ProductOrders != null ? s.ProductOrders.Sum(x => x.ProductCount) : default))
                .ForMember(d => d.TotalCost, opt => opt.MapFrom(s => s.ProductOrders != null ? s.ProductOrders.Sum(x => x.Product.Cost * x.ProductCount) : default));

            CreateMap<ProductOrder, ProductOrderDto>()
                .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.ProductId))
                .ForMember(d => d.ProductName, opt => opt.MapFrom(s => s.Product != null ? s.Product.Name : default))
                .ForMember(d => d.ProductCountry, opt => opt.MapFrom(s => s.Product != null && s.Product.Country != null ? s.Product.Country.Name : default))
                .ForMember(d => d.ProductBrand, opt => opt.MapFrom(s => s.Product != null && s.Product.Brand != null ? s.Product.Brand.Name : default))
                .ForMember(d => d.ProductCount, opt => opt.MapFrom(s => s.ProductCount))
                .ForMember(d => d.ProductCost, opt => opt.MapFrom(s => s.Product != null ? s.Product.Cost : default));

            CreateMap<IList<Order>, ReportDto>()
                .ForMember(d => d.TotalCost, opt => opt.MapFrom(s => s.Sum(x => x.ProductOrders != null ? x.ProductOrders.Sum(p => p.Product.Cost * p.ProductCount) : default)))
                .ForMember(d => d.TotalProductCount, opt => opt.MapFrom(s => s.Sum(x => x.ProductOrders != null ? x.ProductOrders.Sum(p => p.ProductCount) : default)));

            CreateMap<IList<Order>, ReportWatchDto>()
                .ForMember(d => d.TotalCost, opt => opt.MapFrom(s => s.Sum(x => x.ProductOrders != null ? x.ProductOrders.Where(w => w.Product is Watch).Sum(p => p.Product.Cost * p.ProductCount) : default)))
                .ForMember(d => d.TotalProductCount, opt => opt.MapFrom(s => s.Sum(x => x.ProductOrders != null ? x.ProductOrders.Where(w => w.Product is Watch).Sum(p => p.ProductCount) : default)));

            CreateMap<IList<Order>, ReportPreciousItemDto>()
                .ForMember(d => d.TotalCost, opt => opt.MapFrom(s => s.Sum(x => x.ProductOrders != null ? x.ProductOrders.Where(w => w.Product is PreciousItem).Sum(p => p.Product.Cost * p.ProductCount) : default)))
                .ForMember(d => d.TotalProductCount, opt => opt.MapFrom(s => s.Sum(x => x.ProductOrders != null ? x.ProductOrders.Where(w => w.Product is PreciousItem).Sum(p => p.ProductCount) : default)));

            CreateMap<IList<Order>, ReportBijouterieDto>()
                .ForMember(d => d.TotalCost, opt => opt.MapFrom(s => s.Sum(x => x.ProductOrders != null ? x.ProductOrders.Where(w => w.Product is Bijouterie).Sum(p => p.Product.Cost * p.ProductCount) : default)))
                .ForMember(d => d.TotalProductCount, opt => opt.MapFrom(s => s.Sum(x => x.ProductOrders != null ? x.ProductOrders.Where(w => w.Product is Bijouterie).Sum(p => p.ProductCount) : default)));
        }
    }
}
