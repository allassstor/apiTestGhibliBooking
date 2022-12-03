using System;
using System.Net;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace apiTest.Steps
{
    [Binding]
    public class GetBooking_2Steps
    {
        private RestClient client;
        private RestRequest request;
        private RestResponse<BookingModel> response;

        [When(@"forms a request to get all id")]
        public async System.Threading.Tasks.Task WhenFormsARequestToGetAllIdAsync()
        {
            client = new RestClient("https://restful-booker.herokuapp.com/");
            request = new RestRequest("booking", Method.Get);
            response = await client.ExecuteGetAsync<BookingModel>(request);
        }
        
        [Then(@"check whether the information is received")]
        public void ThenCheckWhetherTheInformationIsReceived()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
