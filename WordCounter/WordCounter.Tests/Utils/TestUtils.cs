using WordCounter.Common;
using WordCounter.Tests.Cases;

namespace WordCounter.Tests.Utils;

public static class TestUtils
{
    public static (string input, IList<WordCount> output) LoadCase(string inputResourceName, string outputResourceName)
    {
        var input = TestResources.ResourceManager.GetString(inputResourceName);
        var rawOutput = TestResources.ResourceManager.GetString(outputResourceName);

        if (input is null)
            throw new ArgumentException("Given resource couldn't be loaded", inputResourceName);

        if (rawOutput is null)
            throw new ArgumentException("Given resource couldn't be loaded", outputResourceName);

        return (input, ParseOutput(rawOutput));
    }

    private static IList<WordCount> ParseOutput(string rawOutput)
    {
        return rawOutput
                .Split('\n')
                .Where(entry => !string.IsNullOrWhiteSpace(entry))
                .Select(ParseOutputEntry)
                .ToList();
    }

    private static WordCount ParseOutputEntry(string rawEntry)
    {
        var tokens = rawEntry.Split(": ");

        if (tokens.Length != 2)
            throw new ArgumentException("Not a correct entry", rawEntry);

        if (!int.TryParse(tokens[0], out var count))
            throw new ArgumentException("Could not parse word count", rawEntry);

        return new WordCount(tokens[1], count);
    }
}
