namespace ExampleApplication.Radio.Api.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Description;

    using ExampleApplication.Radio.Api.Providers;

    /// <summary>
    /// Helps find swagger.
    /// </summary>
    public class SwaggerRedirectController : ApiController
    {
        private readonly ISettingsProvider settings;

        public SwaggerRedirectController(ISettingsProvider settings)
        {
            this.settings = settings;
        }

        /// <summary>
        /// Redirects to swagger.
        /// </summary>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public HttpResponseMessage Get()
        {
            var response = Request.CreateResponse(HttpStatusCode.Redirect);
            response.Headers.Location = new Uri(GetSwaggerAddress());
            return response;
        }

        private string GetSwaggerAddress()
        {
            return $"{this.settings.Address}/swagger";
        }
    }
}