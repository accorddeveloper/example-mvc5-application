﻿namespace ExampleApplication.Radio.Api.IoC
{
    using System.Reflection;

    using Autofac;
    using Autofac.Integration.WebApi;

    using Providers;

    using Module = Autofac.Module;

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
            builder.RegisterType<DescriptionProvider>().As<IDescriptionProvider>();
            builder.RegisterType<SettingsProvider>().As<ISettingsProvider>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }
    }
}