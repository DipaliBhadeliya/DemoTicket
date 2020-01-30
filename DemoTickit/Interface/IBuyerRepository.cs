using DemoTicket.DTO;
using DemoTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTicket.Interface
{
    public interface IBuyerRepository
    {
        public BuyerDto GetBuyer();
        public void SaveBuyer(BuyerDto obj);
        public BuyerDto CheckIsTickitAvailable(int eventId);
    }
}
