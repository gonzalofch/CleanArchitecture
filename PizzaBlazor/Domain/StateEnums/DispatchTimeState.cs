using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.StateEnums
{
    public class DispatchTimeState
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public enum DispatchTimesId
        {
            Preparing = 1,
            Delivered = 2,
            OutForDelivery = 3,
        }

        private DispatchTimeState(int id,string message)
        {
            Id = id;
            Message = message;
        }

        public static readonly DispatchTimeState Preparing = new((int)DispatchTimesId.Preparing, "Preparing");
        public static readonly DispatchTimeState Delivered = new((int)DispatchTimesId.Delivered, "Delivered");
        public static readonly DispatchTimeState OutForDelivery = new((int)DispatchTimesId.OutForDelivery, "Out for delivery");

        public static readonly IReadOnlyCollection<DispatchTimeState> All = new List<DispatchTimeState>
        {
            Preparing,
            Delivered,
            OutForDelivery,
        }
        .AsReadOnly();

        public static DispatchTimeState GetById(int id) => All.FirstOrDefault(_ => _.Id == id);
    }
}
