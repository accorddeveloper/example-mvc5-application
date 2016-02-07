namespace ExampleApplication.Radio.Api.Controllers
{
    using System.Web.Http;

    using ExampleApplication.BL.Directors;

    /// <summary>
    /// The countries RESTful API controller.
    /// </summary>
    [RoutePrefix("api")]
    public class CountriesController : ApiController
    {
        /// <summary>
        /// Gets the countries.
        /// </summary>
        private readonly IGetCountries getAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountriesController"/> class.
        /// </summary>
        /// <param name="getAction">The GetAction provider.</param>
        public CountriesController(IGetCountries getAction)
        {
            this.getAction = getAction;
        }

        /// <summary>
        /// Gets all the countries supported by the API
        /// </summary>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [Route("countries")]
        public IHttpActionResult Get()
        {
            return Ok(this.getAction.GetCountries());
        }
    }
}