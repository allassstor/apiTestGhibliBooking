using System;
using System.Net;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace apiTest.Steps
{
    [Binding]
    public class GetGhibliLocationsIdSteps
    {
        private RestClient client;
        private RestRequest request;
        private RestResponse<ChibliLocationIdModels> response;
        [When(@"forms a request for receiving information by id")]
        public async System.Threading.Tasks.Task WhenFormsARequestForReceivingInformationByIdAsync()
        {
            client = new RestClient("https://ghibliapi.herokuapp.com/");
            request = new RestRequest("locations/11014596-71b0-4b3e-b8c0-1c4b15f28b9a", Method.Get);
            response = await client.ExecuteGetAsync<ChibliLocationIdModels>(request);
        }
        
        [Then(@"check whether the information received")]
        public void ThenCheckWhetherTheInformationReceived()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
