namespace ExampleApplication.Data.Repositories
{
    using System.Collections.Generic;

    using ExampleApplication.Data.Entities;

    /// <summary>
    /// The CountriesRepository interface.
    /// </summary>
    public interface ICountriesRepository
    {
        /// <summary>
        /// Gets all the Country records.
        /// </summary>
        /// <returns>The <see cref="Country"/>.</returns>
        IEnumerable<Country> GetAll();
    }
}