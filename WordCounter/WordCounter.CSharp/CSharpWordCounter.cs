using WordCounter.Common;

namespace WordCounter.CSharp;

public class CSharpWordCounter : IWordCounter
{
    public IEnumerable<WordCount> CountAndSortWords(string input)
    {
        return input.Split()
            .Where(word => !string.IsNullOrWhiteSpace(word))
            .GroupBy(word => word)
            .Select(group => new WordCount(group.Key, group.Count()))
            .OrderByDescending(wordCount => wordCount.Count)
            .ThenBy(wordCount => wordCount.Word, StringComparer.Ordinal)
            .ToList();
    }
}
