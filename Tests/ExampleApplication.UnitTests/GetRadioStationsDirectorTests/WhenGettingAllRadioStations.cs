namespace ExampleApplication.UnitTests.GetRadioStationsDirectorTests
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
    /// The when getting all radio stations.
    /// </summary>
    public class WhenGettingAllRadioStations : Scenario
    {
        /// <summary>
        /// The radio stations repository mock.
        /// </summary>
        private readonly Mock<IRadioStationsRepository> repositoryMock = new Mock<IRadioStationsRepository>();

        /// <summary>
        /// The country mapper mock.
        /// </summary>
        private readonly Mock<IEntityToDtoMapper<Data.Entities.RadioStation, RadioStation>> mapperMock = new Mock<IEntityToDtoMapper<Data.Entities.RadioStation, RadioStation>>();

        /// <summary>
        /// The class under test.
        /// </summary>
        private GetRadioStationsDirector classUnderTest;

        /// <summary>
        /// The result.
        /// </summary>
        private IEnumerable<RadioStation> result;

        /// <summary>
        /// The database records.
        /// </summary>
        private Data.Entities.RadioStation[] databaseRecords;

        /// <summary>
        /// Given certain conditions.
        /// </summary>
        protected override void Given()
        {
            this.databaseRecords = new[]
                     {
                         new Data.Entities.RadioStation(),
                         new Data.Entities.RadioStation(),
                         new Data.Entities.RadioStation()
                     };

            this.repositoryMock.Setup(a => a.GetAll()).Returns(databaseRecords);
            this.mapperMock.Setup(a => a.Map(this.databaseRecords[0])).Returns(new RadioStation { Country = "UK", Name = "Radio BBC 1" });
            this.mapperMock.Setup(a => a.Map(this.databaseRecords[1])).Returns(new RadioStation { Country = "Poland", Name = "Radio Plus" });
            this.mapperMock.Setup(a => a.Map(this.databaseRecords[2])).Returns(new RadioStation { Country = "France", Name = "NRJ" });

            classUnderTest = new GetRadioStationsDirector(this.repositoryMock.Object, this.mapperMock.Object);
        }

        /// <summary>
        /// When GetRadioStations has been peformed.
        /// </summary>
        protected override void When()
        {
            result = classUnderTest.GetRadioStations();
        }

        /// <summary>
        /// Then it should contain Radio BBC 1.
        /// </summary>
        [Then]
        public void ThenItShouldGetRadioInUK()
        {
            Assert.That(this.result.First().Name, Is.EqualTo("Radio BBC 1"));
            Assert.That(this.result.First().Country, Is.EqualTo("UK"));
        }

        /// <summary>
        /// Then it should contain Radio Plus.
        /// </summary>
        [Then]
        public void ThenItShouldGetRadioInPoland()
        {
            Assert.That(this.result.Skip(1).First().Name, Is.EqualTo("Radio Plus"));
            Assert.That(this.result.Skip(1).First().Country, Is.EqualTo("Poland"));
        }

        /// <summary>
        /// Then it should contain Radio NRJ.
        /// </summary>
        [Then]
        public void ThenItShouldGetRadioInFrance()
        {
            Assert.That(this.result.Skip(2).First().Name, Is.EqualTo("NRJ"));
            Assert.That(this.result.Skip(2).First().Country, Is.EqualTo("France"));
        }
    }
}