using AutoMapper;
using EcommerceApp.Application.DTOs.Cart;
using EcommerceApp.Application.DTOs.Category;
using EcommerceApp.Application.DTOs.Identity;
using EcommerceApp.Application.DTOs.Product;
using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.Entities.Cart;
using EcommerceApp.Domain.Entities.Identity;

namespace EcommerceApp.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<CreateCategory, Category>();
            CreateMap<CreateProduct,Product>();

            CreateMap<Category, GetCategory>();
            CreateMap<Product, GetProduct>();

            CreateMap<UpdateProduct, Product>();
            CreateMap<UpdateCategory, Category>();
            CreateMap<CreateUser, AppUser>();
            CreateMap<AppUser, CreateUser>();
            CreateMap<LoginUser, AppUser>();
            CreateMap<AppUser, LoginUser>();
            
            CreateMap<PaymentMethod,GetPaymentMethod>();
            CreateMap<CreateCartItem, CartItem>();

        }
    }
}
