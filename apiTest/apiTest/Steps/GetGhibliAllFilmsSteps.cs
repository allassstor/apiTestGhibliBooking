using System;
using System.Net;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace apiTest.Steps
{
    [Binding]
    public class GetGhibliAllFilmsSteps
    {
        private RestClient client;
        private RestRequest request;
        private RestResponse<GhibliFilmsModel> response;
        [When(@"forms a request to get all information about films")]
        public async System.Threading.Tasks.Task WhenFormsARequestToGetAllInformationAboutFilmsAsync()
        {
            client = new RestClient("https://ghibliapi.herokuapp.com/");
            request = new RestRequest("films", Method.Get);
            response = await client.ExecuteGetAsync<GhibliFilmsModel>(request);

        }
        
        [Then(@"checks whether the information is received")]
        public void ThenChecksWhetherTheInformationIsReceived()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
