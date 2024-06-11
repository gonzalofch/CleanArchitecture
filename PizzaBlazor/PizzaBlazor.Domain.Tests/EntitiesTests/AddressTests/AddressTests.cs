using Domain.Entities;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
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

        [Theory ]
        [ClassData(typeof(AddressFieldsTests))]
        //falta para la linea2, pero en la entidad no tengo validacion aparte de que tenga menos de 100 caracteres
        public void Validate_Should_Fail_With_Error_Message_If_Any_Property_Is_Invalid(Address addressInstance, string errorMessage)
        {
            var errorMessages = () => addressInstance.Validate();

            errorMessages.Should().Throw<ValidationException>().
                And.Message
                .Should().Be(errorMessage);
        }
    }
}
