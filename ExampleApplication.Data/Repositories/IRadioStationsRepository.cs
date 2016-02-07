namespace ExampleApplication.Data.Repositories
{
    using ExampleApplication.Data.Entities;
    using System.Collections.Generic;

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