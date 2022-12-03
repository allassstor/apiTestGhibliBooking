using System;
using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using TechTalk.SpecFlow;

namespace apiTest.Steps
{
    [Binding]
    public class PutBookingSteps
    {
        private RestClient client;
        RestRequest request;
        private RestResponse<BookingModel> response;
        [When(@"updating data by id")]
        public async System.Threading.Tasks.Task WhenUpdatingDataByIdAsync()
        {
            client = new RestClient("http://restful-booker.herokuapp.com/");
            request = new RestRequest("booking/23382", Method.Put);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new BookingModel()
            {
                firstname = "Med",
                lastname = "Grum",
                totalprice = 222,
                depositpaid = false,
                bookingdates = new Bookingdates()
                {
                    checkin = "2013-02-23",
                    checkout = "2014-10-23"
                },
                additionalneeds = "Breakfast"

            });
            request.AddHeader("Accept", "application/json");
            client.Authenticator = new HttpBasicAuthenticator("admin", "password123");
            response = await client.ExecuteAsync<BookingModel>(request);

        }
        
        [Then(@"checking if the updates are saved")]
        public void ThenCheckingIfTheUpdatesAreSaved()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
