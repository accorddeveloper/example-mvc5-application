namespace ExampleApplication.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Entities;

    /// <summary>
    /// The countries repository.
    /// </summary>
    public class CountriesRepository : ICountriesRepository
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private readonly IExampleContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountriesRepository"/> class.
        /// </summary>
        /// <param name="context">The Example database context.</param>
        public CountriesRepository(IExampleContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Selects all the Country records from the database.
        /// </summary>
        /// <returns>The <see cref="Country"/>.</returns>
        public IEnumerable<Country> GetAll()
        {
            return this.context.Countries.AsNoTracking().ToArray();
        }
    }
}