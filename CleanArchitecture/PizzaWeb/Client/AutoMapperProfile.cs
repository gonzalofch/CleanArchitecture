using AutoMapper;
using PizzaWeb.Shared.Models;

namespace PizzaWeb.Client
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Address, Address>();
        }
    }
}
