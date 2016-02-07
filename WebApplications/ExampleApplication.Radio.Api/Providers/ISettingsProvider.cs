namespace ExampleApplication.Radio.Api.Providers
{
    /// <summary>
    /// Global application settings provider
    /// </summary>
    public interface ISettingsProvider
    {
        /// <summary>
        /// Gets the application's web address.
        /// </summary>
        string Address { get; }

        /// <summary>
        /// Gets the application's description.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the application's title.
        /// </summary>
        string Title { get; }
    }
}