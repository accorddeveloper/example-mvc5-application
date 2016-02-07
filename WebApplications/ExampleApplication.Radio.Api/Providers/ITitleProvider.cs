namespace ExampleApplication.Radio.Api.Providers
{
    /// <summary>
    /// Provides the title of the application.
    /// </summary>
    public interface ITitleProvider
    {
        /// <summary>
        /// Gets the title.
        /// </summary>
        string Title { get; }
    }
}