using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTicket.DTO
{
    public class BuyerDto
    {
        public int BuyerId { get; set; }
        public int EventId { get; set; }
        public string TesterKey { get; set; }

        public string BuyerName { get; set; }

        public EventDto Event { get; set; }
    }
}
