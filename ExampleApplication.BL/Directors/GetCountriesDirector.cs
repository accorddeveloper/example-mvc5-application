namespace ExampleApplication.BL.Directors
{
    using System.Collections.Generic;
    using System.Linq;

    using Data.Repositories;

    using Mappers;

    using Dto = DataTransfer;
    using Entities = Data.Entities;

    /// <summary>
    /// The director reponsible for getting the list of countries.
    /// </summary>
    public class GetCountriesDirector : IGetCountries
    {
        /// <summary>
        /// The countries repository.
        /// </summary>
        private readonly ICountriesRepository countriesRepository;

        /// <summary>
        /// The country mapper.
        /// </summary>
        private readonly IEntityToDtoMapper<Entities.Country, Dto.Country> mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCountriesDirector"/> class.
        /// </summary>
        /// <param name="countriesRepository">
        /// The countries repository.
        /// </param>
        /// <param name="mapper">
        /// The country mapper.
        /// </param>
        public GetCountriesDirector(ICountriesRepository countriesRepository, IEntityToDtoMapper<Entities.Country, Dto.Country> mapper)
        {
            this.countriesRepository = countriesRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets all the countries.
        /// </summary>
        /// <returns>
        /// A collection of <see cref="Dto.Country"/>.
        /// </returns>
        public IEnumerable<Dto.Country> GetCountries() => this.countriesRepository.GetAll().Select(a => this.mapper.Map(a));
    }
}