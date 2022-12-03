using System;
using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using TechTalk.SpecFlow;

namespace apiTest.Steps
{
    [Binding]
    public class PostBookingSteps
    {
        private RestClient client;
        private RestRequest request;
        private RestResponse<BookingModel> response;
        [When(@"creates new information")]
        public async System.Threading.Tasks.Task WhenCreatesNewInformationAsync()
        {
            client = new RestClient("http://restful-booker.herokuapp.com/");
            request = new RestRequest("booking", Method.Post);
            request.AddHeader("Content-Type", "application/json");

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new BookingModel()
            {
                firstname = "Alastor",
                lastname = "Grum",
                totalprice = 188,
                depositpaid = true,
                bookingdates = new Bookingdates()
                {
                    checkin = "2013-02-23",
                    checkout = "2014-10-23"
                },
                additionalneeds = "Breakfast"
            });
            request.AddHeader("Accept", "application/json");
            response = await client.ExecutePostAsync<BookingModel>(request);
        }
        
        [Then(@"check if the information is added")]
        public void ThenCheckIfTheInformationIsAdded()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK)); 
        }
    }
}
