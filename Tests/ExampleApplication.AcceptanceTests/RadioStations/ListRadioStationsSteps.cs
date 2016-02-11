namespace ExampleApplication.AcceptanceTests.RadioStations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    using ExampleApplication.BL.DataTransfer;
    using ExampleApplication.Radio.Api.Owin;

    using Microsoft.Owin.Testing;

    using Newtonsoft.Json;

    using NUnit.Framework;

    using TechTalk.SpecFlow;

    /// <summary>
    /// The steps.
    /// </summary>
    [Binding]
    public class ListRadioStationsSteps
    {
        /// <summary>
        /// The string helper.
        /// </summary>
        private readonly StringHelper stringHelper;

        /// <summary>
        /// The local test server.
        /// </summary>
        private TestServer localTestServer;

        /// <summary>
        /// The http response result.
        /// </summary>
        private HttpResponseMessage httpResponseResult;

        /// <summary>
        /// The radio stations retrieved from the endpoint.
        /// </summary>
        private IList<RadioStation> radioStations;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListRadioStationsSteps"/> class.
        /// </summary>
        public ListRadioStationsSteps()
        {
            this.stringHelper = new StringHelper();
        }

        /// <summary>
        /// The Given clause.
        /// </summary>
        [Given(@"the API is up and running")]
        public void GivenTheApiIsUpAndRunning()
        {
            this.localTestServer = TestServer.Create<Startup>();
        }

        /// <summary>
        /// The When clause.
        /// </summary>
        /// <param name="requestMethod">The request method type.</param>
        /// <param name="endpoint">The endpoint path.</param>
        [When(@"I make a (.*) request to the (.*) endpoint")]
        public void WhenIMakeARequestToAnEndpoint(string requestMethod, string endpoint)
        {
            var request = this.localTestServer.CreateRequest(endpoint);
            if (requestMethod.Equals("get", StringComparison.InvariantCultureIgnoreCase))
            {
                httpResponseResult = request.GetAsync().Result;
                var httpContent = this.httpResponseResult.Content.ReadAsStringAsync().Result;
                radioStations = JsonConvert.DeserializeObject<IList<RadioStation>>(httpContent);
            }
            else
            {
                throw new ArgumentException($"Unsupported request method: {requestMethod}");
            }
        }

        /// <summary>
        /// The Then clause.
        /// </summary>
        /// <param name="name">The thing to look for.</param>
        /// <param name="country">The country where the thing occurs.</param>
        [Then(@"the result should contain (.*) in (.*)")]
        public void ThenTheResultWillContainInPlace(string name, string country)
        {
            country = this.stringHelper.RemoveFillers(country, "the");
            Assert.IsTrue(
                this.radioStations.Any(
                    a =>
                    a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)
                    && a.Country.Equals(country, StringComparison.InvariantCultureIgnoreCase)));
        }

        /// <summary>
        /// Shuts down the local server.
        /// </summary>
        [AfterScenario]
        public void TearDown()
        {
            this.localTestServer.Dispose();
        }
    }
}