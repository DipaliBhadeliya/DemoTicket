using DemoTicket.DTO;
using DemoTicket.Interface;
using DemoTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTicket.Repository
{
    public class BuyerRepository:IBuyerRepository
    {
        private readonly dbInterviewContext context;
        private readonly IEventRepository _EventRepository;
        public BuyerRepository(dbInterviewContext _context, IEventRepository eventRepository) {
            context = _context;
            _EventRepository = eventRepository;
        }
        public BuyerDto GetBuyer() {

            var eventObj = _EventRepository.GetEventDetail();
            var objBuyer = new BuyerDto();
            objBuyer.Event = eventObj;
            return objBuyer;
        }
        public void SaveBuyer(BuyerDto obj)
        {
            Buyer b = new Buyer();
            b.TesterKey = "dipalibhadeliya";
            b.EventId = obj.EventId;
            b.BuyerName = obj.BuyerName;
            context.Buyer.Add(b);
            context.SaveChanges();
            
        }
        public BuyerDto CheckIsTickitAvailable(int eventId)
        {
            var obj = context.Buyer.Where(x => x.EventId == eventId && x.TesterKey == "dipalibhadeliya").Select(x=> new BuyerDto() { 
            BuyerId = x.BuyerId,
            BuyerName = x.BuyerName,
            EventId = x.EventId,
            TesterKey = x.TesterKey,
            
            }).FirstOrDefault();
            return obj;
        }
    }
}
