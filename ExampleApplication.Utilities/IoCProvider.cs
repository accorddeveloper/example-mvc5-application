namespace ExampleApplication.Utilities
{
    using Autofac;
    using Autofac.Configuration;

    /// <summary>
    /// Providers the IoC resolve method and hosts the container.
    /// </summary>
    public static class IoCProvider
    {
        /// <summary>
        /// The main IoC container.
        /// </summary>
        private static readonly IContainer Container;

        /// <summary>
        /// Initializes static members of the <see cref="IoCProvider"/> class.
        /// </summary>
        static IoCProvider()
        {
            var builder = new ContainerBuilder();
            var reader = new ConfigurationSettingsReader();
            builder.RegisterModule(reader);
            Container = builder.Build();
        }

        /// <summary>
        /// Resolves a bound instance.
        /// </summary>
        /// <typeparam name="T">The type to resolve.</typeparam>
        /// <returns>The <see cref="T"/>.</returns>
        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}