using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoTicket.Models;
using DemoTicket.DTO;
using Microsoft.AspNetCore.Http;
using DemoTicket.Interface;

namespace DemoTicket.Controllers
{
    public class TicketController : Controller
    {
        private readonly ILogger<TicketController> _logger;
        dbInterviewContext context = new dbInterviewContext();
        private readonly IBuyerRepository _BuyerRepository;
        public TicketController(ILogger<TicketController> logger, IBuyerRepository buyerRepository)
        {
            _logger = logger;
            _BuyerRepository = buyerRepository;
        }

        public IActionResult Index()
        {    
            var objBuyer = _BuyerRepository.GetBuyer();
            return View(objBuyer);
        }
        public JsonResult SaveBuyTckit(BuyerDto obj) {
            try
            {
                if (ModelState.IsValid)
                {
                    _BuyerRepository.SaveBuyer(obj);
                    return Json(new { success = true });

                }
                else { 
                return Json(new { success=false});

                }
            }
            catch (Exception e)
            {
                return Json(new { success= false ,data=e.Message});
            }
        }
   
        public JsonResult CheckTickitAvailability(int eventId) {
            try
            {
               var  check = _BuyerRepository.CheckIsTickitAvailable(eventId);
                if (check != null)
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
           
            
        }
    }
}
