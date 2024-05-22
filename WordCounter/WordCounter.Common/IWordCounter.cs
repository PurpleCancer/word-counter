namespace WordCounter.Common;

public interface IWordCounter
{
    /// <summary>
    /// Counts words in the input string and returns them in a non-ascending occurence count order first, lexicograhic order second.
    /// </summary>
    /// <remarks>
    /// For simplicity's sake, assumes each sequence of non-whitespace characters between whitespace characters.
    /// </remarks>
    /// <param name="input">Input string.</param>
    /// <returns>Sorted list of words with their counts.</returns>
    public IEnumerable<WordCount> CountAndSortWords(string input);
}
