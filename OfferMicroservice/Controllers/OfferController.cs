
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfferMicroservice.Models;
using OfferMicroservice.Service;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OfferMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   

    public class OfferController : ControllerBase
    {

        public static List<Offer> offers = new List<Offer>
            {
                 new Offer { EmployeeId=101,OfferId = 1, Status = "Available", Likes = 10, Category = "Electronics", OpenedDate =new DateTime(2022,02,01), Details="Resale of Mobile",ClosedDate=new DateTime(),EngagedDate=new DateTime()},

                 new Offer { EmployeeId=102,OfferId = 2, Status = "Engaged", Likes = 55, Category = "Electronics", OpenedDate = new DateTime(2022,02,04),ClosedDate=new DateTime() , Details="Resale of washing machine",EngagedDate=new DateTime(2022,02,05)},

                 new Offer { EmployeeId=103,OfferId = 3, Status = "Engaged", Likes = 20, Category = "Vehicle", OpenedDate = new DateTime(2022,02,04),ClosedDate=new DateTime() , Details="Resale of Two wheeler ",EngagedDate=new DateTime(2022,02,09)},

                 new Offer { EmployeeId=103,OfferId = 4, Status = "Available", Likes = 25, Category = "Electronics", OpenedDate = new DateTime(2022,02,09),ClosedDate=new DateTime() , Details="Resale of Laptop",EngagedDate=new DateTime()},

                 new Offer { EmployeeId=103,OfferId = 5, Status = "Available", Likes = 28, Category = "Electronics", OpenedDate = new DateTime(2022,02,09),ClosedDate=new DateTime() , Details="Resale of Laptop",EngagedDate=new DateTime()},

                 new Offer { EmployeeId=103,OfferId = 6 ,Status = "Closed", Likes = 50, Category = "Books", OpenedDate = new DateTime(2022,02,09),EngagedDate=new  DateTime(2022,02,09), ClosedDate=new DateTime(2022,02,10),Details="Wings Of Fire"},

                 new Offer {EmployeeId=104,OfferId = 7, Status = "Available", Likes = 25, Category = "Vehicle", OpenedDate =new DateTime(2022,02,18), Details="Resale of car",ClosedDate=new DateTime(),EngagedDate=new DateTime()},

                 new Offer { EmployeeId=105,OfferId = 8, Status = "Engaged", Likes = 22, Category = "Electronics", OpenedDate = new DateTime(2022,01,04),ClosedDate=new DateTime() , Details="Resale of Mobile",EngagedDate=new DateTime(2022,01,06)},


                 new Offer { EmployeeId=105,OfferId = 9, Status = "Closed", Likes = 18, Category = "Books", OpenedDate = new DateTime(2022,02,01),EngagedDate=new  DateTime(2022,02,03), ClosedDate=new DateTime(2022,02,05),Details="Harry Potter Books"},

            };
        private IOfferRepo<Offer> _repo;


        public OfferController(IOfferRepo<Offer> repo)
        {
            _repo = repo;
        }


        // GET: api/<OfferController>
        [HttpGet]
        [Route("GetOffersList")]
        public IActionResult GetOffersList()
        {
            if (_repo.GetAllOffers() != null)
                return Ok(_repo.GetAllOffers());
            return BadRequest("No Offers");
        }

        // GET: api/<OfferController>/<name>
        [HttpGet]
        [Route("GetOfferById/{id}")]
        public IActionResult GetOfferById(int id)
        {


            var offer = _repo.GetOfferDetails(id);
            if (offer != null)
            {
                return Ok(offer);
            }

            return NotFound("Offer Not Found");



            //catch
            //{
            //    return BadRequest("No offer found");
            //}
        }




        // POST api/<OfferController>
        [HttpPost]
        [Route("PostOffer")]
        public ActionResult<IEnumerable<Offer>> PostOffer(Offer newOffer)
        {
            if (newOffer.OfferId == 0 || newOffer.EmployeeId == 0 || newOffer.Category == null || newOffer.Details == null)

            {
                return BadRequest(new { message = "OfferId, Employee Id, Category, details cannot be empty" });
            }
            else
            {
                var _offer = _repo.AddOffer(newOffer);
                //if (_offer == null)
                //{
                //    return BadRequest(new { message = "Offer Id already exists" });
                //}
                return Ok(new { message = "offer Added Successfully" });
            }


        }


        // PUT api/<OfferController>/5
        [HttpPost]
        [Route("EditOffer")]

        public ActionResult<Offer> EditOffer(Offer updatedOffer)

        {

            Offer offer = offers.FirstOrDefault(c => c.OfferId == updatedOffer.OfferId && c.EmployeeId == updatedOffer.EmployeeId);
            if (offer == null)
            {
                return NotFound("Offer not found");
            }



            offer.ClosedDate = updatedOffer.ClosedDate;

            offer.Status = updatedOffer.Status;

            offer.Details = updatedOffer.Details;

            offer.Category = updatedOffer.Category;

            if (offer.ClosedDate > offer.EngagedDate && offer.Status != "Closed")
            {
                return BadRequest("Please update status to Closed");
            }

            return Ok("Edited Successfully");

            //return offers;

        }



        //// PUT api/<OfferController>/5
        //[HttpPost]
        //[Route("EditOffer")]

        //public IActionResult UpdateOffer(Offer updateOff)

        //{
        //    var _update = _repo.EditOffer(updateOff);

        //    //if(offer.ClosedDate>offer.EngagedDate && offer.Status!="Closed")
        //    //{
        //    //    return BadRequest("Please update status to Closed");
        //    //}

        //    //return Ok("Edited Successfully");
        //    return Ok(_update);

        //    //return offers;

        //}




        [HttpGet]
        [Route("GetOfferByCategory/{category}")]
        public IActionResult GetOfferByCategory(string category)
        {
            var _category = _repo.CatOffer(category);
            if (_category == null)
            {
                return NotFound("No such Category found.");
            }

            return Ok(_category);

        }

        [HttpGet]
        [Route("GetOfferByOpenedDate/{openedDate}")]
        public ActionResult<Offer> GetOfferByOpenedDate(DateTime openedDate)
        {
            var _date = _repo.DateOffer(openedDate);
            if (_date == null)
            {
                return NotFound("No offers found in the given date.");
            }
            return Ok(_date);

        }


        [HttpGet]
        [Route("GetOfferByTopThreeLikes/{category}")]
        public ActionResult<Offer> GetOfferByTopThreeLikes(string category)
        {

            var _like = _repo.ThreeLikes(category);
            if (_like == null)
            {
                return NotFound("No offers found");
            }
            return Ok(_like);
        }

        [HttpPost]
        [Route("EngageOffer")]
        public ActionResult<IEnumerable<Offer>> EngageOffer(Offer offerDetails)
        {
            //Offer o = new Offer();
            //o.OfferId = offerDetails.OfferId;
            //o.EmployeeId = offerDetails.EmployeeId;
            var _engage = _repo.EngaOffer(offerDetails);
            if (_engage == null)
            {
                return NotFound("You are not authorized");
            }
            return Ok(_engage); ;
        }

        [HttpPost]
        [Route("LikeOffer")]
        public ActionResult<Offer> LikeOffer(Offer o)

        {
            var _like = _repo.LikeOffer(o);
            return Ok(_like);




        }


    }
}
