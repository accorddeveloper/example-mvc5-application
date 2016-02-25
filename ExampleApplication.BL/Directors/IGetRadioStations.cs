namespace ExampleApplication.BL.Directors
{
    using System.Collections.Generic;

    using ExampleApplication.BL.DataTransfer;

    /// <summary>
    /// Provides all the radio stations.
    /// </summary>
    public interface IGetRadioStations
    {
        /// <summary>
        /// Gets all the radio stations.
        /// </summary>
        /// <returns>The <see cref="RadioStation"/>.</returns>
        IEnumerable<RadioStation> GetRadioStations();
    }
}