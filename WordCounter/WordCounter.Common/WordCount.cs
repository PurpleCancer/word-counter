namespace WordCounter.Common;

public readonly struct WordCount(string word, int count)
{
    public readonly string Word { get; } = word;

    public readonly int Count { get; } = count;

    public override string ToString()
    {
        return $"{Count}: {Word}";
    }
}
