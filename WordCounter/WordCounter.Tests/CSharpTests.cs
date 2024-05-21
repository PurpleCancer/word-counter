using WordCounter.Common;
using WordCounter.CSharp;
using WordCounter.Tests.Utils;

namespace WordCounter.Tests;

public class CSharpTests
{
    private IWordCounter _wordCounter;

    [SetUp]
    public void Setup()
    {
        _wordCounter = new CSharpWordCounter();
    }

    [TestCase("Input1", "Output1")]
    [TestCase("Input2", "Output2")]
    [TestCase("Input3", "Output3")]
    [TestCase("Input4", "Output4")]
    [TestCase("Input5", "Output5")]
    [TestCase("Input6", "Output6")]
    [TestCase("Input7", "Output7")]
    [TestCase("Input8", "Output8")]
    [TestCase("Input9", "Output9")]
    [TestCase("Input10", "Output10")]
    public void Test(string inputName, string outputName)
    {
        var (input, expectedOutput) = TestUtils.LoadCase(inputName, outputName);

        var actual = _wordCounter.CountAndSortWords(input);

        Assert.That(actual, Is.EqualTo(expectedOutput));
    }
}