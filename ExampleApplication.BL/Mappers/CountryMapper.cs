namespace ExampleApplication.BL.Mappers
{
    using Dto = DataTransfer;
    using Entities = Data.Entities;

    /// <summary>
    /// The country mapper.
    /// </summary>
    public class CountryMapper : IEntityToDtoMapper<Entities.Country, Dto.Country>
    {
        /// <summary>
        /// Maps from a Country entity to a Country DTO
        /// </summary>
        /// <param name="entity">A database entity.</param>
        /// <returns>The <see cref="Dto.Country"/>.</returns>
        public Dto.Country Map(Entities.Country entity)
        {
            return new Dto.Country { Name = entity.Name };
        }
    }
}