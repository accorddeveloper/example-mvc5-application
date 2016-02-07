namespace ExampleApplication.Radio.Api.Owin
{
    using ExampleApplication.Radio.Api.Providers;
    using ExampleApplication.Utilities;
    using global::Owin;
    using Swashbuckle.Application;
    using System.Web.Http;

    /// <summary>
    /// The default OWiN start-up class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// This code configures Web API. The Startup class is specified as a type parameter in the
        /// WebApp.Start method.
        /// </summary>
        /// <param name="appBuilder">The OWiN app builder</param>
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config
                .EnableSwagger(c => c.SingleApiVersion("v1", IoCProvider.Resolve<ITitleProvider>().Title))
                .EnableSwaggerUi();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            appBuilder.UseWebApi(config);
        }
    }
}