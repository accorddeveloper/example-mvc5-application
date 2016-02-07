namespace ExampleApplication.BL.IoC
{
    using Autofac;

    using Mappers;

    using Dto = DataTransfer;
    using Entities = Data.Entities;

    /// <summary>
    /// The BL IoC module to load the bindings for this assembly.
    /// </summary>
    public class AssemblyModule : Module
    {
        /// <summary>
        /// The setup method.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RadioStationMapper>().As<IEntityToDtoMapper<Entities.RadioStation, Dto.RadioStation>>();
        }
    }
}