namespace ExampleApplication.Radio.Api.IoC
{
    using Autofac;

    using Providers;

    /// <summary>
    /// The Radio API IoC module to load the bindings for this assembly.
    /// </summary>
    public class AssemblyModule : Module
    {
        /// <summary>
        /// The setup method.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TitleProvider>().As<ITitleProvider>();
        }
    }
}