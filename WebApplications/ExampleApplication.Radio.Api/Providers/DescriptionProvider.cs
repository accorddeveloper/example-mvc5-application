namespace ExampleApplication.Radio.Api.Providers
{
    using ExampleApplication.Radio.Api.Owin;
    using ExampleApplication.Utilities;
    using System.Reflection;

    /// <summary>
    /// Provides the description of the application based on the assembly settings.
    /// </summary>
    public class DescriptionProvider : IDescriptionProvider
    {
        /// <summary>
        /// Gets the description.
        /// </summary>
        public string Description => GetAssemblyInfo().Description;

        /// <summary>
        /// Gets the current assembly info.
        /// </summary>
        /// <returns>The <see cref="AssemblyInfo"/>.</returns>
        private static AssemblyInfo GetAssemblyInfo()
        {
            return new AssemblyInfo(Assembly.GetAssembly(typeof(Program)));
        }
    }
}