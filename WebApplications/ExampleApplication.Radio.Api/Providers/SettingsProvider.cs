namespace ExampleApplication.Radio.Api.Providers
{
    using ExampleApplication.Utilities;

    /// <summary>
    /// Provides settings for the application.
    /// </summary>
    public class SettingsProvider : ISettingsProvider
    {
        /// <summary>
        /// The title provider instance.
        /// </summary>
        private readonly ITitleProvider titleProvider;

        /// <summary>
        /// The description provider instance.
        /// </summary>
        private readonly IDescriptionProvider descriptionProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsProvider"/> class. Requires title
        /// and description provider.
        /// </summary>
        /// <param name="titleProvider">The title provider <see cref="ITitleProvider"/></param>
        /// <param name="descriptionProvider">The description provider <see cref="IDescriptionProvider"/></param>
        public SettingsProvider(ITitleProvider titleProvider, IDescriptionProvider descriptionProvider)
        {
            this.titleProvider = titleProvider;
            this.descriptionProvider = descriptionProvider;
        }

        /// <summary>
        /// Gets the application's title.
        /// </summary>
        public string Title => this.titleProvider.Title;

        /// <summary>
        /// Gets the application's description.
        /// </summary>
        public string Description => this.descriptionProvider.Description;

        /// <summary>
        /// Gets the application's web address.
        /// </summary>
        /// <exception cref="MissingAppSettingValueException">
        /// Throws the exception when the AppSetting Address is missing.
        /// </exception>
        public string Address
        {
            get
            {
                var address = AppSettings.ProvideValue<string>("Address");
                if (string.IsNullOrEmpty(address))
                {
                    throw new MissingAppSettingValueException(nameof(Address));
                }
                return address;
            }
        }
    }
}