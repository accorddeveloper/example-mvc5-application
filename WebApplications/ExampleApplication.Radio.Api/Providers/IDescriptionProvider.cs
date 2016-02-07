namespace ExampleApplication.Radio.Api.Providers
{
    /// <summary>
    /// Provides the description of the application.
    /// </summary>
    public interface IDescriptionProvider
    {
        /// <summary>
        /// Gets the description.
        /// </summary>
        string Description { get; }
    }
}