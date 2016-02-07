namespace ExampleApplication.UnitTests.GetCountriesDirectorTests
{
    using System.Collections.Generic;
    using System.Linq;

    using BDD;

    using BL.DataTransfer;
    using BL.Directors;
    using BL.Mappers;

    using Data.Repositories;

    using Moq;

    using NUnit.Framework;

    /// <summary>
    /// The when getting all countries.
    /// </summary>
    public class WhenGettingAllCountries : Scenario
    {
        /// <summary>
        /// The countries repository mock.
        /// </summary>
        private readonly Mock<ICountriesRepository> repositoryMock = new Mock<ICountriesRepository>();

        /// <summary>
        /// The country mapper mock.
        /// </summary>
        private readonly Mock<IEntityToDtoMapper<Data.Entities.Country, Country>> mapperMock = new Mock<IEntityToDtoMapper<Data.Entities.Country, Country>>();

        /// <summary>
        /// The database records.
        /// </summary>
        private Data.Entities.Country[] databaseRecords;

        /// <summary>
        /// The class under test.
        /// </summary>
        private GetCountriesDirector classUnderTest;

        /// <summary>
        /// The result.
        /// </summary>
        private IEnumerable<Country> result;

        /// <summary>
        /// Given certain conditions.
        /// </summary>
        protected override void Given()
        {
            this.databaseRecords = new[]
                     {
                         new Data.Entities.Country(),
                         new Data.Entities.Country(),
                         new Data.Entities.Country()
                     };

            this.repositoryMock.Setup(a => a.GetAll()).Returns(databaseRecords);
            this.mapperMock.Setup(a => a.Map(this.databaseRecords[0])).Returns(new Country { Name = "UK" });
            this.mapperMock.Setup(a => a.Map(this.databaseRecords[1])).Returns(new Country { Name = "France" });
            this.mapperMock.Setup(a => a.Map(this.databaseRecords[2])).Returns(new Country { Name = "Poland" });

            this.classUnderTest = new GetCountriesDirector(this.repositoryMock.Object, this.mapperMock.Object);
        }

        /// <summary>
        /// When GetCountries has been peformed.
        /// </summary>
        protected override void When()
        {
            result = classUnderTest.GetCountries();
        }

        /// <summary>
        /// Then it should get contain UK in the countries.
        /// </summary>
        [Then]
        public void ThenItShouldGetUK()
        {
            Assert.That(this.result.First().Name, Is.EqualTo("UK"));
        }

        /// <summary>
        /// Then it should get contain France in the countries.
        /// </summary>
        [Then]
        public void ThenItShouldGetFrance()
        {
            Assert.That(this.result.Skip(1).First().Name, Is.EqualTo("France"));
        }

        /// <summary>
        /// Then it should get contain Poland in the countries.
        /// </summary>
        [Then]
        public void ThenItShouldGetPoland()
        {
            Assert.That(this.result.Skip(2).First().Name, Is.EqualTo("Poland"));
        }
    }
}