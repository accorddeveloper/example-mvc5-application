namespace ExampleApplication.Radio.Api.Owin
{
    using ExampleApplication.Radio.Api.Providers;
    using ExampleApplication.Utilities;
    using global::Owin;
    using Swashbuckle.Application;
    using System.Linq;
    using System.Web.Http;

    /// <summary>
    /// The OWIN startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// This code configures the Web API. The Startup class is specified as a type parameter in
        /// the WebApp.Start method.
        /// </summary>
        /// <param name="appBuilder">The OWIN app builder</param>
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            AddSwaggerSupport(config);
            RemoveSupportForXmlResponses(config);
            MapRoutes(config);
            appBuilder.UseWebApi(config);
        }

        /// <summary>
        /// Adds the Swagger UI to the RESTful application.
        /// </summary>
        /// <param name="config">The OWIN config.</param>
        private static void AddSwaggerSupport(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", IoCProvider.Resolve<ISettingsProvider>().Title)
                    .Description(IoCProvider.Resolve<ISettingsProvider>().Description);
                c.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}\Api.xml");
            }).EnableSwaggerUi();
        }

        /// <summary>
        /// Maps all the URIs in the application.
        /// </summary>
        /// <param name="config">The OWIN config.</param>
        private static void MapRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                "API",
                "api/{controller}/{id}",
                 new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                "Redirect",
                "",
                new { controller = "SwaggerRedirect" });
        }

        /// <summary>
        /// Removes xml responses and thus makes the application default to json.
        /// </summary>
        /// <param name="config">The OWIN config.</param>
        private static void RemoveSupportForXmlResponses(HttpConfiguration config)
        {
            var matches = config.Formatters
                                .Where(f => f.SupportedMediaTypes.Any(m =>
                                m.MediaType.ToString() == "application/xml" ||
                                m.MediaType.ToString() == "text/xml"))
                                .ToList();
            foreach (var match in matches)
            {
                config.Formatters.Remove(match);
            }
        }
    }
}