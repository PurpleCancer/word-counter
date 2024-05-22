using System.CommandLine;
using WordCounter.Common;
using WordCounter.CSharp;
using WordCounter.FSharp;

namespace WordCounter.ConsoleApp;

/// <summary>
/// This programs is meant to be ran as a command line program, not an interactive application launched in a command line.
/// Build it, navigate to the executable and run <c>.\WordCounter.ConsoleApp.exe -h</c> for usage information.
/// </summary>
class Program
{
    static int Main(string[] args)
    {
        var rootCommand = BuildRootCommand();

        return rootCommand.Invoke(args);
    }

    private static RootCommand BuildRootCommand()
    {
        var fileOption = new Option<FileInfo?>(
            name: "--file",
            description: "The file to read and process. If empty, uses standard input.");
        fileOption.AddAlias("-f");

        var languageOption = new Option<string>(
            name: "--language",
            description: "Select implementation to use.",
            getDefaultValue: () => "csharp")
                .FromAmong("csharp", "fsharp");
        languageOption.AddAlias("-l");

        var rootCommand = new RootCommand("Runs the word counter agains a provided string. Prints results to the standard output.")
        {
            fileOption,
            languageOption
        };

        rootCommand.SetHandler((context) =>
        {
            var file = context.ParseResult.GetValueForOption(fileOption);
            var language = context.ParseResult.GetValueForOption(languageOption);
            var token = context.GetCancellationToken();
            DoRootCommand(file, language);
        });

        return rootCommand;
    }

    private static void DoRootCommand(FileInfo? file, string? language)
    {
        var input = GetInput(file);

        var wordCounter = GetWordCounter(language);

        var output = wordCounter.CountAndSortWords(input);

        foreach (var word in output)
        {
            Console.WriteLine(word);
        }
    }

    private static string GetInput(FileInfo? file)
    {
        if (file is null)
        {
            // read from standard input if file is not provided
            using var writer = new StringWriter();
            string? s;
            while ((s = Console.ReadLine()) != null)
            {
                writer.WriteLine(s);
            }

            return writer.ToString();
        }
        else
        {
            return File.ReadAllText(file.FullName);
        }
    }

    private static IWordCounter GetWordCounter(string? language)
    {
        return language switch
        {
            "csharp" => new CSharpWordCounter(),
            "fsharp" => new FSharpWordCounter(),
            _ => throw new ArgumentException("Unknown language", language),
        };
    }
}


