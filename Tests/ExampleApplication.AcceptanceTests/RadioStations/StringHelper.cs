namespace ExampleApplication.AcceptanceTests.RadioStations
{
    using System.Linq;
    // Import static members of the Regex class.
    using static System.Text.RegularExpressions.Regex;

    /// <summary>
    /// The string helper.
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// Removes filler words.
        /// </summary>
        /// <param name="sentence">The sentence to process.</param>
        /// <param name="words">The words to remove.</param>
        /// <returns>The sentence without the words.</returns>
        public string RemoveFillers(string sentence, params string[] words)
        {
            var removedWords = words.Aggregate(sentence, (current, word) => current.Replace(word, string.Empty));
            //Normalise multiple spaces
            return Replace(removedWords, @"\s+", " ").Trim();
        }
    }
}