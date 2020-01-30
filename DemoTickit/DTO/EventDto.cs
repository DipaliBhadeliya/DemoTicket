using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTicket.DTO
{
    public class EventDto
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public int TimeoutInSeconds { get; set; }
    }
}
