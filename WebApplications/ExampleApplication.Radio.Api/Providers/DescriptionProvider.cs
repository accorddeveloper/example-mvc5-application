namespace ExampleApplication.Radio.Api.Providers
{
    using ExampleApplication.Radio.Api.Owin;
    using ExampleApplication.Utilities;
    using System.Reflection;

    public class DescriptionProvider : IDescriptionProvider
    {
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