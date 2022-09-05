using OfferMicroservice1.Models;
using OfferMicroservice1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMicroservice1.Service
{

    public class OfferService:IOfferService
    {
        private IOfferRepository _offerRepository;

        public OfferService(IOfferRepository offrepo)
        {
            _offerRepository = offrepo;
        }


        public bool PostOffer(Offer offer)
        {
            _offerRepository = new OfferRepository();
            return _offerRepository.PostOffer(offer);
        }

        public bool UpdateOffer(Offer offer)
        {
            _offerRepository = new OfferRepository();
            return _offerRepository.UpdateOffer(offer);
        }

        public Offer GetOffersList(Offer offer)
        {
            Offer o = new Offer()
            {
                OfferId = offer.OfferId,
                EmployeeId = offer.EmployeeId,
                Status = offer.Status,
                Likes = offer.Likes,
                Category = offer.Category,
                Details = offer.Details,
                ClosedDate = offer.ClosedDate,
                EngagedDate = offer.EngagedDate,
                OpenedDate = offer.OpenedDate,
            };
            return o;
        }
    }
}
