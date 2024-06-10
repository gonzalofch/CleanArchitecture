using Domain.Entities;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaBlazor.Domain.Tests.EntitiesTests.AddressTests
{
    public class AddressTests
    {
        [Fact]
        public void Should_Create_Address_With_Valid_Properties()
        {
            var id = Guid.NewGuid();
            var name = "Gonzalo Miguel Flores Chuchon";
            var line1 = "Casa de Gonzalo1";
            var line2 = "Casa de Gonzalo2";
            var city = "Santander";
            var region = "Cantabria";
            var postalCode = "39008";

            var deliveryAddress = new Address(id, name, line1, line2, city, region, postalCode);

            deliveryAddress.Id.Should().Be(id);
            deliveryAddress.Name.Should().Be(name);
            deliveryAddress.Line1.Should().Be(line1);
            deliveryAddress.Line2.Should().Be(line2);
            deliveryAddress.City.Should().Be(city);
            deliveryAddress.Region.Should().Be(region);
            deliveryAddress.PostalCode.Should().Be(postalCode);
        }

        [Theory]
        [InlineData(null, "123 Main St", "New York", "NYRegion", "10001", "The Name field is required.")]
        [InlineData("John Doe", null, "New York", "NYRegion", "10001", "The Line1 field is required.")]
        [InlineData("John Doe", "123 Main St", null, "NYRegion", "10001", "The City field is required.")]
        [InlineData("John Doe", "123 Main St", "New York", null, "10001", "The Region field is required.")]
        [InlineData("John Doe", "123 Main St", "New York", "NYRegion", null, "The PostalCode field is required.")]
        [InlineData("Jo", "123 Main St", "New York", "NYRegion", "10001", "Please use a Name bigger than 3 letters.")]
        [InlineData("John Doe", "123", "New York", "NYRegion", "10001", "Please use an Address bigger than 5 letters.")]
        [InlineData("John Doe", "123 Main St", "Ne", "NYRegion", "10001", "Please use a City bigger than 3 letters.")]
        [InlineData("John Doe", "123 Main St", "New York", "N", "10001", "Please use a Region bigger than 3 letters.")]
        [InlineData("John Doe", "123 Main St", "New York", "NYRegion", "1000", "Please use a valid Postal Code with five numbers.")]
        [InlineData("John Doe", "123 Main St", "New York", "NYRegion", "100001", "Please use a valid Postal Code with five numbers.")]
        //falta para la linea2, pero en la entidad no tengo validacion aparte de que tenga menos de 100 caracteres
        public void Validate_Should_Fail_With_Error_Message_If_Any_Property_Is_Invalid(
       string name, string line1, string city, string region, string postalCode, string errorMessage)
        {
            var address = new Address
            {
                Id = Guid.NewGuid(),
                Name = name,
                Line1 = line1,
                City = city,
                Region = region,
                PostalCode = postalCode 
            };

            Action act = () => address.Validate();

            act.Should().Throw<ValidationException>().
                And.Message
                .Should().Be(errorMessage);
        }
    }
}
