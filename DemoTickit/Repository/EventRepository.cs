using DemoTicket.DTO;
using DemoTicket.Interface;
using DemoTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTicket.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly dbInterviewContext context;
        public EventRepository(dbInterviewContext _context) {
            context = _context;
        }
        public EventDto GetEventDetail() {
            var eventobj = context.Event.Select(x => new EventDto() { EventId = x.EventId, Name = x.Name, TimeoutInSeconds = x.TimeoutInSeconds }).FirstOrDefault();
            return eventobj;
        }   
       
    }
}
