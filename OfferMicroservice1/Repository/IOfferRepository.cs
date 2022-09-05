using OfferMicroservice1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace OfferMicroservice1.Repository
{
    public interface IOfferRepository
    {
        public bool PostOffer(Offer offer);
        public bool UpdateOffer(Offer offer);
    }
}
