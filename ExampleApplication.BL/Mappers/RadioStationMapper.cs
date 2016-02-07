namespace ExampleApplication.BL.Mappers
{
    using Dto = DataTransfer;
    using Entities = Data.Entities;

    /// <summary>
    /// The radio station mapper.
    /// </summary>
    public class RadioStationMapper : IEntityToDtoMapper<Entities.RadioStation, Dto.RadioStation>
    {
        /// <summary>
        /// Maps from a RadioStation entity to a RadioStation DTO
        /// </summary>
        /// <param name="entity">A database entity.</param>
        /// <returns>The <see cref="Dto.RadioStation"/>.</returns>
        public Dto.RadioStation Map(Entities.RadioStation entity)
        {
            return new Dto.RadioStation
            {
                Country = entity.Country.Name,
                Name = entity.Name
            };
        }
    }
}