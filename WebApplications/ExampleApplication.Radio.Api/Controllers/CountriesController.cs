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
        /// Gets all the countries supported by the API
        /// </summary>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [Route("countries")]
        public IHttpActionResult Get()
        {
            return Ok(new { Name = "Api" });
        }
    }
}