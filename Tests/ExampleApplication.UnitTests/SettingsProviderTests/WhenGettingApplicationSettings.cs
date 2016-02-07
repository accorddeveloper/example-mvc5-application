namespace ExampleApplication.UnitTests.SettingsProviderTests
{
    using BDD;

    using Moq;

    using NUnit.Framework;

    using Radio.Api.Providers;

    /// <summary>
    /// When getting application settings.
    /// </summary>
    public class WhenGettingApplicationSettings : Scenario
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
        /// Given certain conditions.
        /// </summary>
        protected override void Given()
        {
            titleProvider.Setup(a => a.Title).Returns("Test");
            descriptionProvider.Setup(a => a.Description).Returns("Description");

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
        public void ThenItShouldGetTitle()
        {
            Assert.That(this.classUnderTest.Title, Is.EqualTo("Test"));
        }

        /// <summary>
        /// Then it should get the description.
        /// </summary>
        [Then]
        public void ThenItShouldGetDescription()
        {
            Assert.That(this.classUnderTest.Description, Is.EqualTo("Description"));
        }
    }
}