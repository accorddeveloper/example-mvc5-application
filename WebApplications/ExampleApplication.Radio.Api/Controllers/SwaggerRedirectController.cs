namespace ExampleApplication.Radio.Api.Controllers
{
    using ExampleApplication.Utilities;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Description;

    /// <summary>
    /// Helps find swagger.
    /// </summary>
    public class SwaggerRedirectController : ApiController
    {
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

        private static string GetSwaggerAddress()
        {
            return $"{AppSettings.ProvideValue<string>("Address")}/swagger";
        }
    }
}