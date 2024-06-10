using Domain.Entities;
using PizzaBlazor.Shared.DtoModels.Address;

namespace PizzaBlazor.Server.Mappers;

public static class AddressMapper
{
    public static AddressDTO MapToDTO(this Address address)
    {
        return new AddressDTO()
        {
            Id = address.Id,
            Name = address.Name,
            Line1 = address.Line1,
            Line2 = address.Line2,
            City = address.City,
            Region = address.Region,
            PostalCode = address.PostalCode
        };
    }
}