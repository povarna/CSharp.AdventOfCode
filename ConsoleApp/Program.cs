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
        
        var command = new Command("solve", "Solve Advent Of Code Problem");
        command.AddOption(yearOption);
        command.AddOption(dayOption);
        command.AddOption(partOption);

        command.SetHandler(RunAoCDayProblem, yearOption, dayOption, partOption);
        
        return await command.InvokeAsync(args);
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