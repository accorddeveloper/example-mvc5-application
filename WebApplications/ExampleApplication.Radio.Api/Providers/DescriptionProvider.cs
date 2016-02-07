namespace ExampleApplication.Radio.Api.Providers
{
    /// <summary>
    /// Provides the description of the application based on the assembly settings.
    /// </summary>
    public class DescriptionProvider : AssemblyInfoProvider, IDescriptionProvider
    {
        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description => GetAssemblyInfo().Description;
    }
}