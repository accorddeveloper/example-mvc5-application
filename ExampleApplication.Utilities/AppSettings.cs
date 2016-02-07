namespace ExampleApplication.Utilities
{
    using System.Configuration;

    /// <summary>
    /// The providers application settings.
    /// </summary>
    public static class AppSettings
    {
        /// <summary>
        /// Provides the value of an application setting and changes it to a specific type.
        /// </summary>
        /// <param name="key">The key which is preset in AppSettings</param>
        /// <typeparam name="T">Value type.</typeparam>
        /// <returns>The <see cref="T"/>.</returns>
        public static T ProvideValue<T>(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            return (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}