namespace ExampleApplication.Data.Repositories
{
    using System.Collections.Generic;

    using ExampleApplication.Data.Entities;

    /// <summary>
    /// The RadioStationsRepository interface.
    /// </summary>
    public interface IRadioStationsRepository
    {
        /// <summary>
        /// Gets all the Country records.
        /// </summary>
        /// <returns>The <see cref="RadioStation"/>.</returns>
        IEnumerable<RadioStation> GetAll();
    }
}