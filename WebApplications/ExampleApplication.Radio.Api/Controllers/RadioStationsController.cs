namespace ExampleApplication.Radio.Api.Controllers
{
    using System.Web.Http;

    using ExampleApplication.BL.Directors;

    /// <summary>
    /// The radio stations RESTful API controller.
    /// </summary>
    [RoutePrefix("api")]
    public class RadioStationsController : ApiController
    {
        /// <summary>
        /// Gets the radio stations.
        /// </summary>
        private readonly IGetRadioStations getAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="RadioStationsController"/> class.
        /// </summary>
        /// <param name="getAction">The GetAction provider.</param>
        public RadioStationsController(IGetRadioStations getAction)
        {
            this.getAction = getAction;
        }

        /// <summary>
        /// Gets all the radio stations supported by the API
        /// </summary>
        /// <returns>The <see cref="IHttpActionResult"/>.</returns>
        [Route("radiostations")]
        public IHttpActionResult Get()
        {
            return Ok(this.getAction.GetRadioStations());
        }
    }
}