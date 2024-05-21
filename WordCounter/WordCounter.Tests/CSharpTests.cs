using WordCounter.Common;
using WordCounter.CSharp;

namespace WordCounter.Tests;

public class CSharpTests
{
    private IWordCounter _wordCounter;

    [SetUp]
    public void Setup()
    {
        // TODO use IC container instead of new
        _wordCounter = new CSharpWordCounter();
    }

    [Test]
    public void Test1()
    {
        var input = "Go do that thing that you do so well";

        var result = _wordCounter.CountAndSortWords(input);

        Assert.That(result[0].Count, Is.EqualTo(2));
        Assert.That(result[0].Word, Is.EqualTo("do"));
    }
}