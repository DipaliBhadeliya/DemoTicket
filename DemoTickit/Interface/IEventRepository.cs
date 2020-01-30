using DemoTicket.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTicket.Interface
{
    public interface IEventRepository
    {
        public EventDto GetEventDetail();
    }
}
