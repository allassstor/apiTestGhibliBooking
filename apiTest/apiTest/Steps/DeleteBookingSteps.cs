using System;
using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using TechTalk.SpecFlow;

namespace apiTest.Steps
{
    [Binding]
    public class DeleteBookingSteps
    {
        private RestClient client;
        RestRequest request;
        private RestResponse<BookingModel> response;
        [When(@"delete the record")]
        public async System.Threading.Tasks.Task WhenDeleteTheRecordAsync()
        {
            client = new RestClient("http://restful-booker.herokuapp.com/");
            request = new RestRequest("booking/1382", Method.Delete);
            client.Authenticator = new HttpBasicAuthenticator("admin", "password123");
            response = await client.ExecuteAsync<BookingModel>(request);
        }
        
        [Then(@"check whether the record is deleted")]
        public void ThenCheckWhetherTheRecordIsDeleted()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

        }
    }
}
