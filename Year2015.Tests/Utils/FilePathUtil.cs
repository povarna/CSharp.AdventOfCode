namespace Year2015.Tests.Utils;

public static class FilePathUtil
{
    public static string ReadInputAsString(int day, string inputFileName)
    {
        if (day is < 0 or > 25)
            throw new ArgumentException(
                $"Illegal day: {day} passed as input param. The number should be between 1 and 25");

        var currentPath = GetCurrentPath();
        var dayNumber = day is > 0 and < 10 ? $"0{day}" : $"{day}";
        var streamReader = new StreamReader($"{currentPath}/Day{dayNumber}/{inputFileName}");
        return streamReader.ReadToEnd();
    }

    private static string GetCurrentPath()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        return Path.Combine(currentDirectory, OperatingSystem.IsMacOS() ? @"../../.." : @"..\..\..");
    }
}