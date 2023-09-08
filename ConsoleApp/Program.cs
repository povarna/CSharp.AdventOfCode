// See https://aka.ms/new-console-template for more information

using System.CommandLine;
using ConsoleApp.Utils;

namespace ConsoleApp;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var yearOption = new Option<int>(
            name: "--year",
            description: "Advent of code year problems"
        );
        yearOption.AddAlias("-y");

        var dayOption = new Option<int>(
            name: "--day",
            description: "Advent of code year day problem"
        );
        dayOption.AddAlias("-d");

        var partOption = new Option<IEnumerable<int>>(
            name: "--part",
            description: "Advent of code day problem part"
        );
        partOption.AddAlias("-p");

        var aocCommand = new RootCommand("Advent of code problems command line");
        var dayCommand = new Command("solve-day-problem", "Solve Advent Of Code Problem")
        {
            yearOption,
            dayOption,
            partOption
        };
        var yearCommand = new Command("solve-year-problems", "Solve all year problems")
        {
            yearOption
        };
        aocCommand.AddCommand(dayCommand);
        aocCommand.AddCommand(yearCommand);

        dayCommand.SetHandler(RunAoCDayProblem, yearOption, dayOption, partOption);
        yearCommand.SetHandler(RunAoCYearProblems, yearOption);
        
        return await aocCommand.InvokeAsync(args);
    }

    private static void RunAoCYearProblems(int year)
    {
        for (var i = 1; i <= 22; i++)
        {
            RunAoCDayProblem(year, i, new List<int> { 1, 2 });
        }
    }

    private static void RunAoCDayProblem(int year, int day, IEnumerable<int> parts)
    {
        var yearPath = $"Year{year}";
        var dayNumber = FilePathUtil.GetDayNumber(day);
        var dayPath = $"Day{dayNumber}";
        var problem = $"ConsoleApp.{yearPath}.{dayPath}.Problem";
        var input = FilePathUtil.ReadInputAsString(year, day);

        var listParts = parts.ToList();
        FilePathUtil.ValidateParts(listParts);

        foreach (var part in listParts)
        {
            var magicType = Type.GetType(problem);
            var magicConstructor = magicType?.GetConstructor(Type.EmptyTypes);
            var magicClassObject = magicConstructor?.Invoke(Array.Empty<object>());

            var magicMethod = magicType?.GetMethod($"Part{part}");

            var response =
                magicMethod?.Invoke(magicClassObject, new object[] { input });
            Console.WriteLine($"AOC2015, Day{dayNumber}, Part{part} solution result: {response}");
        }
    }
}