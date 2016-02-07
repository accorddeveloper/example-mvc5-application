using System.Collections.Generic;
using ExampleApplication.BL.DataTransfer;

namespace ExampleApplication.BL.Directors
{
    public interface IGetCountries
    {
        IEnumerable<Country> GetCountries();
    }
}