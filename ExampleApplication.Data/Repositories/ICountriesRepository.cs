namespace ExampleApplication.Data.Repositories
{
    using ExampleApplication.Data.Entities;
    using System.Collections.Generic;

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