namespace ExampleApplication.Utilities
{
    using System.Configuration;

    /// <summary>
    /// Provides application settings.
    /// </summary>
    public static class AppSettings
    {
        /// <summary>
        /// Provides the value of an application setting and changes it to a specific type.
        /// </summary>
        /// <param name="key">The key which is preset in AppSettings</param>
        /// <typeparam name="T">Value type.</typeparam>
        /// <returns>The <see cref="T"/> The application setting value.</returns>
        public static T ProvideValue<T>(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            return (T)System.Convert.ChangeType(value, typeof(T));
        }

        /// <summary>
        /// Provides the value of the connection string by its name.
        /// </summary>
        /// <param name="name">The name in the config file.</param>
        /// <returns>The value <see cref="string"/>.</returns>
        public static string ProvideConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}