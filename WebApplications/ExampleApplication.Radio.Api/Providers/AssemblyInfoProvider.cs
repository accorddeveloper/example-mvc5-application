namespace ExampleApplication.Radio.Api.Providers
{
    using System.Reflection;
    using ExampleApplication.Utilities;

    /// <summary>
    /// The assembly info provider.
    /// </summary>
    public abstract class AssemblyInfoProvider
    {
        /// <summary>
        /// Gets the current assembly info.
        /// </summary>
        /// <returns>The <see cref="AssemblyInfo"/>.</returns>
        protected static AssemblyInfo GetAssemblyInfo()
        {
            return new AssemblyInfo(Assembly.GetAssembly(typeof(Program)));
        }
    }
}