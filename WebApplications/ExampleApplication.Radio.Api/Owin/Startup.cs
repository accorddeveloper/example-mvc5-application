namespace ExampleApplication.Radio.Api.Owin
{
    using ExampleApplication.Radio.Api.Providers;
    using ExampleApplication.Utilities;
    using global::Owin;
    using Swashbuckle.Application;
    using System.Linq;
    using System.Web.Http;

    /// <summary>
    /// The default OWIN startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// This code configures Web API. The Startup class is specified as a type parameter in the
        /// WebApp.Start method.
        /// </summary>
        /// <param name="appBuilder">The OWIN app builder</param>
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", IoCProvider.Resolve<ITitleProvider>().Title)
                        .Description(IoCProvider.Resolve<IDescriptionProvider>().Description);
                    c.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}\Api.xml");
                }).EnableSwaggerUi();

            RemoveSupportForXmlResponses(config);

            config.Routes.MapHttpRoute(
                "API",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                "Redirect",
                "",
                new { controller = "SwaggerRedirect" });

            appBuilder.UseWebApi(config);
        }

        /// <summary>
        /// Removes xml responses and defaults to json.
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