namespace ExampleApplication.Data.IoC
{
    using Autofac;

    using Entities;
    using Repositories;

    /// <summary>
    /// The Data assembly IoC module to load the bindings for this assembly.
    /// </summary>
    public class AssemblyModule : Module
    {
        /// <summary>
        /// The setup method.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CountriesRepository>().As<ICountriesRepository>();
            builder.RegisterType<RadioStationsRepository>().As<IRadioStationsRepository>();
            builder.RegisterType<ExampleContext>().As<IExampleContext>().InstancePerDependency();
        }
    }
}