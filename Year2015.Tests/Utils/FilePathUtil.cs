namespace Year2015.Tests.Utils;

public static class FilePathUtil
{
    public static List<string> ReadInputAsListOfString(int day, string inputFileName = "input.txt")
    {
        InputValidation(day);

        var currentPath = GetCurrentPath();
        var dayNumber = GetDayNumber(day);

        var strContent = new List<string>();
        using var streamReader = new StreamReader($"{currentPath}/Day{dayNumber}/{inputFileName}");
        while (!streamReader.EndOfStream)
        {
            var currentLine = streamReader.ReadLine();
            if (currentLine != null)
                strContent.Add(currentLine);
        }

        return strContent;
    }

    public static string ReadInputAsString(int day, string inputFileName = "input.txt")
    {
        InputValidation(day);

        var currentPath = GetCurrentPath();
        var dayNumber = day is > 0 and < 10 ? $"0{day}" : $"{day}";

        using var streamReader = new StreamReader($"{currentPath}/Day{dayNumber}/{inputFileName}");
        return streamReader.ReadToEnd();
    }

    private static string GetCurrentPath()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        return Path.Combine(currentDirectory, OperatingSystem.IsMacOS() ? @"../../.." : @"..\..\..");
    }

    private static void InputValidation(int day)
    {
        if (day is < 0 or > 25)
            throw new ArgumentException(
                $"Illegal day: {day} passed as input param. The number should be between 1 and 25");
    }

    private static string GetDayNumber(int day)
    {
        return day is > 0 and < 10 ? $"0{day}" : $"{day}";
    }
}