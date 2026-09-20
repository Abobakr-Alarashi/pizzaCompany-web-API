
using AutoMapper;
using Domain.Entities;
using Application.DTOs;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<ItemTopping, ItemToppingDto>().ReverseMap();
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        CreateMap<Pizza, PizzaDto>().ReverseMap();
        CreateMap<PizzaTopping, PizzaToppingDto>().ReverseMap();
        CreateMap<Topping, ToppingDto>().ReverseMap();



    }
}
