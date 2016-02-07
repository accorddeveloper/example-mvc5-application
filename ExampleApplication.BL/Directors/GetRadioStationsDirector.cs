namespace ExampleApplication.BL.Directors
{
    using System.Collections.Generic;
    using System.Linq;

    using ExampleApplication.BL.Mappers;
    using ExampleApplication.Data.Repositories;

    using Dto = ExampleApplication.BL.DataTransfer;
    using Entities = ExampleApplication.Data.Entities;

    /// <summary>
    /// The director reponsible for getting the list of radio stations.
    /// </summary>
    public class GetRadioStationsDirector : IGetRadioStations
    {
        /// <summary>
        /// The radio stations repository.
        /// </summary>
        private readonly IRadioStationsRepository repository;

        /// <summary>
        /// The entity to DTO mapper.
        /// </summary>
        private readonly IEntityToDtoMapper<Entities.RadioStation, Dto.RadioStation> mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRadioStationsDirector"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository.
        /// </param>
        /// <param name="mapper">
        /// The mapper.
        /// </param>
        public GetRadioStationsDirector(IRadioStationsRepository repository, IEntityToDtoMapper<Entities.RadioStation, Dto.RadioStation> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets all the radio stations.
        /// </summary>
        /// <returns>
        /// The <see cref="Dto.RadioStation"/>.
        /// </returns>
        public IEnumerable<Dto.RadioStation> GetRadioStations()
        {
            return this.repository.GetAll().Select(a => this.mapper.Map(a));
        } 
    }
}