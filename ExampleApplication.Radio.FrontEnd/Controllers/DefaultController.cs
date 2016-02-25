namespace ExampleApplication.Radio.FrontEnd.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The default controller.
    /// </summary>
    public class DefaultController : Controller
    {
        /// <summary>
        /// The start page.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}