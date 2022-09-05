using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfferMicroservice1.Models;
using OfferMicroservice1.Service;


namespace OfferMicroservice1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(OfferController));
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }


        [HttpGet]
        [Route("GetOffersList")]
        public IActionResult  GetOffersList(Offer offer)
        {
            _log4net.Info("GetOffersList Method Called");
            Offer o=_offerService.GetOffersList(offer);
            return Ok(o); 
        }


        [HttpPost]
        [Route("PostOffer")]
        public IActionResult PostOffer(Offer offer)
        {
            _log4net.Info("CreateConsumerBusiness Method Called");
            var result = _offerService.PostOffer(offer);
            return Ok(result);
        }

        [HttpPut]
        [Route("EditOffer")]
        public IActionResult UpdateOffer(Offer offer)
        {
            _log4net.Info("UpdateOffer Method Called");
            var result = _offerService.UpdateOffer(offer);
            return Ok(result);
        }
    }
}
