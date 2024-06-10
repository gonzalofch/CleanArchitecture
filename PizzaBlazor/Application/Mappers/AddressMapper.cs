﻿using Application.UseCases.Create;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class AddressMapper
    {
        public static Address MapToAddressToCreate(this AddressCreateInfo addressInfo)
        {
            return new Address()
            {
                Id = Guid.NewGuid(),
                Name = addressInfo.Name,
                Line1 = addressInfo.Line1,
                Line2 = addressInfo.Line2,
                City = addressInfo.City,
                Region = addressInfo.Region,
                PostalCode = addressInfo.PostalCode,
            };
        }
    }
}
