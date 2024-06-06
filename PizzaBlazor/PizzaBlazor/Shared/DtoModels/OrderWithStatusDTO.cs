using Domain.Entities;
using PizzaBlazor.Shared.DtoModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBlazor.Shared.DtoModels
{
    public class OrderWithStatusDTO
    {
        public OrderWithStatusDTO() { }

        public OrderWithStatusDTO(OrderDTO order, string statusText)
        {
            Order = order;
            StatusText = statusText;
        }

        public readonly static TimeSpan PreparationDuration = TimeSpan.FromSeconds(10);
        public readonly static TimeSpan DeliveryDuration = TimeSpan.FromMinutes(1); // Unrealistic, but more interesting to watch

        public virtual OrderDTO Order { get; set; }

        public string StatusText { get; set; }

        public bool IsDelivered => StatusText == "Delivered";

        public static OrderWithStatusDTO FromOrder(OrderDTO order)
        {
            // To simulate a real backend process, we fake status updates based on the amount
            // of time since the order was placed
            string statusText;
            DateTime date = DateTime.Now;
            var dispatchTime = date.Add(PreparationDuration);

            if (DateTime.Now < dispatchTime)
            {
                statusText = "Preparing";
            }
            else if (DateTime.Now < dispatchTime + DeliveryDuration)
            {
                statusText = "Out for delivery";
            }
            else
            {
                statusText = "Delivered";
            }

            return new OrderWithStatusDTO
            {
                Order = order,
                StatusText = statusText
            };
        }
    }
}
