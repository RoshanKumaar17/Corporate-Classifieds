using OfferMicroservice1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMicroservice1
{
    public class OfferData
    {
        public static List<Offer> OfferList = new List<Offer>
            {
                 new Offer()
                 { EmployeeId=101,OfferId = 1, Status = "Available", Likes = 10, Category = "Electronics", OpenedDate =new DateTime(2022,02,01), Details="Resale of Mobile",ClosedDate=new DateTime(),EngagedDate=new DateTime()},

                 new Offer() { EmployeeId=102,OfferId = 2, Status = "Engaged", Likes = 55, Category = "Electronics", OpenedDate = new DateTime(2022,02,04),ClosedDate=new DateTime() , Details="Resale of washing machine",EngagedDate=new DateTime(2022,02,05)},

                 new Offer() { EmployeeId=103,OfferId = 3, Status = "Engaged", Likes = 20, Category = "Vehicle", OpenedDate = new DateTime(2022,02,04),ClosedDate=new DateTime() , Details="Resale of Two wheeler ",EngagedDate=new DateTime(2022,02,09)},

                 new Offer() { EmployeeId=103,OfferId = 4, Status = "Available", Likes = 25, Category = "Electronics", OpenedDate = new DateTime(2022,02,09),ClosedDate=new DateTime() , Details="Resale of Laptop",EngagedDate=new DateTime()},

                 new Offer() { EmployeeId=103,OfferId = 5, Status = "Available", Likes = 28, Category = "Electronics", OpenedDate = new DateTime(2022,02,09),ClosedDate=new DateTime() , Details="Resale of Laptop",EngagedDate=new DateTime()},

                 new Offer() { EmployeeId=103,OfferId = 6 ,Status = "Closed", Likes = 50, Category = "Books", OpenedDate = new DateTime(2022,02,09),EngagedDate=new  DateTime(2022,02,09), ClosedDate=new DateTime(2022,02,10),Details="Wings Of Fire"},

                 new Offer() {EmployeeId=104,OfferId = 7, Status = "Available", Likes = 25, Category = "Vehicle", OpenedDate =new DateTime(2022,02,18), Details="Resale of car",ClosedDate=new DateTime(),EngagedDate=new DateTime()},

                 new Offer() { EmployeeId=105,OfferId = 8, Status = "Engaged", Likes = 22, Category = "Electronics", OpenedDate = new DateTime(2022,01,04),ClosedDate=new DateTime() , Details="Resale of Mobile",EngagedDate=new DateTime(2022,01,06)},


                 new Offer() { EmployeeId=105,OfferId = 9, Status = "Closed", Likes = 18, Category = "Books", OpenedDate = new DateTime(2022,02,01),EngagedDate=new  DateTime(2022,02,03), ClosedDate=new DateTime(2022,02,05),Details="Harry Potter Books"},

            };
    }
}
