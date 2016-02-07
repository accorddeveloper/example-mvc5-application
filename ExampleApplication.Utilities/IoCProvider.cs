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
        /// The container instance.
        /// </summary>
        private static IContainer container;

        /// <summary>
        /// Gets the main IoC container.
        /// </summary>
        public static IContainer Container
        {
            get
            {
                if (container != null)
                {
                    return container;
                }

                var builder = new ContainerBuilder();
                var reader = new ConfigurationSettingsReader();
                builder.RegisterModule(reader);
                container = builder.Build();
                return container;
            }
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