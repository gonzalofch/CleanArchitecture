﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBlazor.Shared.DtoModels
{
    public class AddressDTO
    {
        public AddressDTO(Guid id, string name, string line1, string line2, string city, string region, string postalCode)
        {
            Id = id;
            Name = name;
            Line1 = line1;
            Line2 = line2;
            City = city;
            Region = region;
            PostalCode = postalCode;
        }

        public Guid Id { get; set; }

        [Required, MinLength(3, ErrorMessage = "Please use a Name bigger than 3 letters."), MaxLength(100, ErrorMessage = "Please use a Name less than 100 letters.")]
        public string Name { get; set; }

        [Required, MinLength(5, ErrorMessage = "Please use an Address bigger than 5 letters."), MaxLength(100, ErrorMessage = "Please use an Address less than 100 letters.")]
        public string Line1 { get; set; }

        [MaxLength(100)]
        public string Line2 { get; set; }

        [Required, MinLength(3, ErrorMessage = "Please use a City bigger than 3 letters."), MaxLength(50, ErrorMessage = "Please use a City less than 50 letters.")]
        public string City { get; set; }

        [Required, MinLength(3, ErrorMessage = "Please use a Region bigger than 3 letters."), MaxLength(20, ErrorMessage = "Please use a Region less than 20 letters.")]
        public string Region { get; set; }

        [Required, RegularExpression(@"^([0-9]{5})$", ErrorMessage = "Please use a valid Postal Code with five numbers.")]
        public string PostalCode { get; set; }
    }
}
