namespace ExampleApplication.UnitTests.RadioStationMapperTests
{
    using ExampleApplication.BDD;
    using ExampleApplication.BL.Mappers;
    using ExampleApplication.Data.Entities;

    using NUnit.Framework;

    /// <summary>
    /// When mapping entity to dto.
    /// </summary>
    public class WhenMappingEntityToDto : Scenario
    {
        /// <summary>
        /// The class under test.
        /// </summary>
        private RadioStationMapper classUnderTest;

        /// <summary>
        /// The entity.
        /// </summary>
        private RadioStation input;

        /// <summary>
        /// The DTO.
        /// </summary>
        private BL.DataTransfer.RadioStation result;

        /// <summary>
        /// Given certain conditions.
        /// </summary>
        protected override void Given()
        {
            this.classUnderTest = new RadioStationMapper();
            this.input = new RadioStation { Name = "Radio", Country = new Country() { Name = "UK" } };
        }

        /// <summary>
        /// When Map has been peformed.
        /// </summary>
        protected override void When()
        {
            this.result = this.classUnderTest.Map(this.input);
        }

        /// <summary>
        /// Then it should map name.
        /// </summary>
        [Then]
        public void ThenItShouldMapName()
        {
            Assert.That(this.result.Name, Is.EqualTo("Radio"));
        }

        /// <summary>
        /// Then it should map country name.
        /// </summary>
        [Then]
        public void ThenItShouldMapCountry()
        {
            Assert.That(this.result.Country, Is.EqualTo("UK"));
        }
    }
}