// See https://aka.ms/new-console-template for more information

using System.CommandLine;
using System.Reflection;

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

        var command = new Command("solve", "Solve Advent Of Code Problem")
        {
            yearOption,
            dayOption,
            partOption
        };


        command.SetHandler(RunAoCProblem,
            yearOption, dayOption, partOption);

        return await command.InvokeAsync(args);
    }

    private static void RunAoCProblem(int year, int day, IEnumerable<int> part)
    {
        var yearPath = $"Year{year}";
        var dayPath = day is > 0 and < 9 ? $"Day0{day}" : $"Day{day}";

        var magicType = Type.GetType($"ConsoleApp.{yearPath}.{dayPath}.Problem");
        var magicConstructor = magicType?.GetConstructor(Type.EmptyTypes);
        var magicClassObject = magicConstructor?.Invoke(Array.Empty<object>());
        var magicMethod = magicType?.GetMethod($"Part{part.First()}", BindingFlags.Static | BindingFlags.Public);
        var magicValue = magicMethod?.Invoke(magicClassObject, new object[] { "Test input " + "part: " + part.First() });
        Console.WriteLine(magicValue);
    }
}