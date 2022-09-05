using OfferMicroservice1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMicroservice1.Service
{
    public interface IOfferService
    {
        public bool PostOffer(Offer offer);
        public bool UpdateOffer(Offer offer);

        public Offer GetOffersList(Offer offer);
    }
}
