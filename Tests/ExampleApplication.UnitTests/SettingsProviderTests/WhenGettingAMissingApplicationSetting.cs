namespace ExampleApplication.UnitTests.SettingsProviderTests
{
    using BDD;

    using Moq;

    using NUnit.Framework;

    using Radio.Api.Providers;

    /// <summary>
    /// When getting application settings.
    /// </summary>
    public class WhenGettingAMissingApplicationSetting : Scenario
    {
        /// <summary>
        /// The title provider.
        /// </summary>
        private readonly Mock<ITitleProvider> titleProvider = new Mock<ITitleProvider>();

        /// <summary>
        /// The description provider.
        /// </summary>
        private readonly Mock<IDescriptionProvider> descriptionProvider = new Mock<IDescriptionProvider>();

        /// <summary>
        /// The class under test.
        /// </summary>
        private SettingsProvider classUnderTest;

        /// <summary>
        /// The address.
        /// </summary>
        private string address;

        /// <summary>
        /// Given certain conditions.
        /// </summary>
        protected override void Given()
        {
            classUnderTest = new SettingsProvider(titleProvider.Object, descriptionProvider.Object);
        }

        /// <summary>
        /// No When necessary
        /// </summary>
        protected override void When()
        {
        }

        /// <summary>
        /// Then it should get the title.
        /// </summary>
        [Then]
        public void ThenItShouldThrowException()
        {
            Assert.Throws<MissingSettingValueException>(
                () =>
                {
                    this.address = this.classUnderTest.Address;
                });
        }
    }
}