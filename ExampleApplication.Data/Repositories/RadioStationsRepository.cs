namespace ExampleApplication.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using ExampleApplication.Data.Entities;

    /// <summary>
    /// The radio stations repository.
    /// </summary>
    public class RadioStationsRepository : IRadioStationsRepository
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private readonly IExampleContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RadioStationsRepository"/> class.
        /// </summary>
        /// <param name="context">The Example database context.</param>
        public RadioStationsRepository(IExampleContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Selects all the Country records from the database.
        /// </summary>
        /// <returns>The <see cref="RadioStation"/>.</returns>
        public IEnumerable<RadioStation> GetAll()
        {
            return this.context.RadioStations.AsNoTracking().ToArray();
        }
    }
}