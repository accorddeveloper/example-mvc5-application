namespace ExampleApplication.Radio.Api.Providers
{
    using System;

    /// <summary>
    /// Used when an AppSetting value is missing
    /// </summary>
    public class MissingSettingValueException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MissingSettingValueException"/> class.
        /// Requires the AppSettings key name.
        /// </summary>
        /// <param name="key"></param>
        public MissingSettingValueException(string key) :
            base($"Missing the value for the {key} app setting.")
        {
        }
    }
}