namespace ExampleApplication.Radio.Api.Providers
{
    using System;

    /// <summary>
    /// Used when an AppSetting value is missing
    /// </summary>
    public class MissingAppSettingValueException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MissingAppSettingValueException"/> class.
        /// Requires the AppSettings key name.
        /// </summary>
        /// <param name="key"></param>
        public MissingAppSettingValueException(string key) :
            base($"The {key} app setting is missing.")
        {
        }
    }
}