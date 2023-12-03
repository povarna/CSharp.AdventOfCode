namespace AoC.Utils;

public static class FilePathUtil
{
    public static string ReadInputAsString(int year, int day, string inputFileName = "input.txt")
    {
        InputDayValidation(day);
        InputYearValidation(year);

        var currentPath = GetCurrentPath();
        var dayNumber = day is > 0 and < 10 ? $"0{day}" : $"{day}";

        using var streamReader = new StreamReader($"{currentPath}/Year{year}/Day{dayNumber}/{inputFileName}");
        return streamReader.ReadToEnd();
    }

    public static string GetDayNumber(int day)
    {
        return day is > 0 and < 10 ? $"0{day}" : $"{day}";
    }

    public static void ValidateParts(List<int> parts)
    {
        if (parts.Count is < 1 or > 2)
            throw new AggregateException("There are two parts on each problem numbered 1 and 2. " +
                                         "Specify which part you need to run");

        if (parts.Any(part => part is not (1 or 2)))
        {
            throw new AggregateException("There are two parts on each problem numbered 1 and 2");
        }
    }

    private static string GetCurrentPath()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        return Path.Combine(currentDirectory, OperatingSystem.IsMacOS() ? @"../../.." : @"..\..\..");
    }

    private static void InputDayValidation(int day)
    {
        if (day is < 0 or > 25)
            throw new ArgumentException(
                $"Illegal day: {day} passed as input param. The number should be between 1 and 25");
    }

    private static void InputYearValidation(int year)
    {
        if (year is < 2015 or > 2023)
            throw new ArgumentException(
                $"Illegal year: {year} passed as input param. The number should be between 2015 and 2023");
    }
}