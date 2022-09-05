using OfferMicroservice1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMicroservice1.Repository
{
    public class OfferRepository:IOfferRepository
    {
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(OfferRepository));


        public bool PostOffer(Offer offer)
        {
            Offer addOffer = new Offer()
            {
                OfferId = offer.OfferId,
                EmployeeId = offer.EmployeeId,
                Status = offer.Status,
                Likes = offer.Likes,
                Category = offer.Category,
                Details = offer.Details,
                ClosedDate = offer.ClosedDate,
                EngagedDate=offer.EngagedDate,
                OpenedDate = offer.OpenedDate,
            };

            OfferData.OfferList.Add(addOffer);
            return true;
        }
        public bool UpdateOffer(Offer offer)
        {
            Offer updateOffer = new Offer()
            {

                OfferId = offer.OfferId,
                EmployeeId = offer.EmployeeId,
                Status = offer.Status,
                Likes = offer.Likes,
                Category = offer.Category,
                Details = offer.Details,
                ClosedDate = offer.ClosedDate,
                OpenedDate =offer.OpenedDate,
        
            };

            Offer deleteOffer = OfferData.OfferList.FirstOrDefault(p => p.OfferId.Equals(offer.OfferId));

            OfferData.OfferList.Remove(deleteOffer);
            OfferData.OfferList.Add(updateOffer);
            return true;

        }

   

        
    }
}
