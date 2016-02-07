namespace ExampleApplication.Radio.Api.Controllers
{
    using System.Web.Http;

    /// <summary>
    /// The countries RESTful API controller.
    /// </summary>
    [RoutePrefix("api")]
    public class CountriesController : ApiController
    {
        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [Route("countries")]
        public IHttpActionResult Get()
        {
            return Ok("OK");
        }
    }
}