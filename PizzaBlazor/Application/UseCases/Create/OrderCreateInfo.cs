﻿namespace Application.UseCases.Create
{
    public class OrderCreateInfo
    {
        public OrderCreateInfo(AddressCreateInfo deliveryAddress, List<PizzaCreateInfo> pizzas)
        {
            DeliveryAddress = deliveryAddress;
            Pizzas = pizzas;
        }

        public OrderCreateInfo() { }

        public AddressCreateInfo DeliveryAddress { get; set; }

        public List<PizzaCreateInfo> Pizzas { get; set; }

    }
}