namespace ExampleApplication.UnitTests.CountryMapperTests
{
    using BDD;

    using ExampleApplication.BL.Mappers;
    using ExampleApplication.Data.Entities;

    using NUnit.Framework;

    /// <summary>
    /// The when mapping entity to dto.
    /// </summary>
    public class WhenMappingEntityToDto : Scenario
    {
        /// <summary>
        /// The class under test.
        /// </summary>
        private CountryMapper classUnderTest;

        /// <summary>
        /// The entity.
        /// </summary>
        private Country input;

        /// <summary>
        /// The DTO.
        /// </summary>
        private BL.DataTransfer.Country result;

        /// <summary>
        /// Given certain conditions.
        /// </summary>
        protected override void Given()
        {
            input = new Country { Name = "Germany" };
            classUnderTest = new CountryMapper();
        }

        /// <summary>
        /// When Map has been peformed.
        /// </summary>
        protected override void When()
        {
            result = this.classUnderTest.Map(input);
        }

        /// <summary>
        /// Then it should map the name.
        /// </summary>
        [Then]
        public void ThenItShouldMapName()
        {
            Assert.That(this.result.Name, Is.EqualTo("Germany"));
        }
    }
}