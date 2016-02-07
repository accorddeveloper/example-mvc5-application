namespace ExampleApplication.Radio.Api.Owin
{
    using System.Linq;
    using System.Web.Http;

    using Autofac.Integration.WebApi;

    using ExampleApplication.Utilities;
    using Swashbuckle.Application;

    using global::Owin;
    using ExampleApplication.Radio.Api.Providers;

    /// <summary>
    /// The OWIN startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// This code configures the Web API. The Startup class is specified as a type parameter in
        /// the WebApp.Start method.
        /// </summary>
        /// <param name="app">The OWIN app builder</param>
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            SetUpAutoFac(config);
            AddSwaggerSupport(config);
            RemoveSupportForXmlResponses(config);
            MapRoutes(config);
            app.UseWebApi(config);
        }

        /// <summary>
        /// Adds AutoFac to the Web API application.
        /// </summary>
        /// <param name="config">The OWIN config.</param>
        private static void SetUpAutoFac(HttpConfiguration config)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(IoCProvider.Container);
        }

        /// <summary>
        /// Adds the Swagger UI to the RESTful application.
        /// </summary>
        /// <param name="config">The OWIN config.</param>
        private static void AddSwaggerSupport(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
            {
                var settingsProvider = IoCProvider.Resolve<ISettingsProvider>();
                c.SingleApiVersion("v1", settingsProvider.Title)
                    .Description(settingsProvider.Description);
                c.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}\Api.xml");
            }).EnableSwaggerUi();
        }

        /// <summary>
        /// Maps all the routes in the application.
        /// </summary>
        /// <param name="config">The OWIN config.</param>
        private static void MapRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("Redirect to Swagger", "", new { controller = "SwaggerRedirect" });
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