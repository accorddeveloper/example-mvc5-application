namespace ExampleApplication.BL.Directors
{
    using System.Collections.Generic;

    using ExampleApplication.BL.DataTransfer;

    /// <summary>
    /// Provides all the countries.
    /// </summary>
    public interface IGetCountries
    {
        /// <summary>
        /// Gets all the countries.
        /// </summary>
        /// <returns>The <see cref="Country"/>.</returns>
        IEnumerable<Country> GetCountries();
    }
}