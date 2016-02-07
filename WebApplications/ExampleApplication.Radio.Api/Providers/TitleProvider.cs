namespace ExampleApplication.Radio.Api.Providers
{
    using ExampleApplication.Radio.Api.Owin;
    using ExampleApplication.Utilities;
    using System.Reflection;

    internal class TitleProvider : ITitleProvider
    {
        public string Title => GetAssemblyInfo().ProductTitle;

        /// <summary>
        /// Gets the currently assembly info.
        /// </summary>
        /// <returns>The <see cref="AssemblyInfo"/>.</returns>
        private static AssemblyInfo GetAssemblyInfo()
        {
            return new AssemblyInfo(Assembly.GetAssembly(typeof(Program)));
        }
    }
}