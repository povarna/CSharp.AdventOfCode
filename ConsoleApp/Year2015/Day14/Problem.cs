using System.Text.RegularExpressions;

namespace ConsoleApp.Year2015.Day14;

public class Problem
{
    private const int NrOfSeconds = 2503;

    public int Part1(string input)
    {
        var reindeerStats = GetReindeerStats(input).ToList();
        var liveStats = Calculate(reindeerStats, NrOfSeconds, false);
        return liveStats.Values.Max();
    }

    public int Part2(string input)
    {
        var reindeerStats = GetReindeerStats(input).ToList();
        var leaderBoard = Calculate(reindeerStats, NrOfSeconds, true);
        return leaderBoard.Values.Max();
    }

    private Dictionary<string, int> Calculate(List<ReindeerStats> reindeerStats, int nrOfSeconds, bool newScoringAlgorithm)
    {
        Dictionary<string, int> liveStats = new();
        Dictionary<string, int> leaderBoard = new();

        for (var i = 0; i < nrOfSeconds; i++)
        {
            foreach (var reindeerStat in reindeerStats)
            {
                if (reindeerStat is { RemainingRestPeriod: 0, RemainingFlyPeriod: 0 })
                {
                    reindeerStat.RemainingFlyPeriod = reindeerStat.FlyPeriod;
                    reindeerStat.RemainingRestPeriod = reindeerStat.RestPeriod;
                }

                if (reindeerStat.RemainingFlyPeriod > 0)
                {
                    if (reindeerStat.Name != null && !liveStats.ContainsKey(reindeerStat.Name))
                    {
                        liveStats.Add(reindeerStat.Name, reindeerStat.Speed);
                    }
                    else
                    {
                        if (reindeerStat.Name != null) liveStats[reindeerStat.Name] += reindeerStat.Speed;
                    }

                    reindeerStat.RemainingFlyPeriod -= 1;
                    continue;
                }

                reindeerStat.RemainingRestPeriod -= 1;
            }

            if (newScoringAlgorithm)
            {
                leaderBoard = UpdateStatsTable(liveStats, leaderBoard);
            }
        }

        return newScoringAlgorithm ? leaderBoard : liveStats;
    }

    private Dictionary<string, int> UpdateStatsTable(Dictionary<string, int> liveStats, Dictionary<string, int> leaderBoard)
    {
        var maxScore = liveStats.Values.Max();
        var leadingReindeer = liveStats
            .Where(kv => kv.Value == maxScore)
            .Select(r => r.Key)
            .ToList();

        foreach (var reindeer in leadingReindeer)
        {
            if (!leaderBoard.ContainsKey(reindeer))
            {
                leaderBoard.Add(reindeer, 1);
            }
            else
            {
                leaderBoard[reindeer] += 1;
            }
        }

        return leaderBoard;
    }

    private static IEnumerable<ReindeerStats> GetReindeerStats(string input)
    {
        return input.Split("\n")
            .Select(CreateReindeerStats);
    }

    private static ReindeerStats CreateReindeerStats(string line)
    {
        var m = Regex.Match(line, @"(.*) can fly (.*) km/s for (.*) seconds, but then must rest for (.*) seconds.");
        var name = m.Groups[1].Value;
        var speed = int.Parse(m.Groups[2].Value);
        var flyPeriod = int.Parse(m.Groups[3].Value);
        var restPeriod = int.Parse(m.Groups[4].Value);

        return new ReindeerStats
        {
            Name = name, Speed = speed, FlyPeriod = flyPeriod, RemainingFlyPeriod = flyPeriod, RestPeriod = restPeriod,
            RemainingRestPeriod = restPeriod
        };
    }

    /**
    *  name = Reindeer name
    *  speed = km/s
    *  flyPeriod = time to fly until it has to rest
    *  restPeriod = time the reindeer has to rest until it can fly again
    */
    private class ReindeerStats
    {
        public string? Name { get; init; }
        public int Speed { get; init; }

        public int FlyPeriod { get; init; }

        public int RemainingFlyPeriod { get; set; }
        public int RestPeriod { get; init; }

        public int RemainingRestPeriod { get; set; }

        public override string ToString()
        {
            return
                @$"ReindeerStats(Name={Name}, Speed = {Speed}, FlyPeriod={FlyPeriod}, RemainingFlyPeriod={RemainingFlyPeriod}, RestPeriod={RestPeriod}, RemainingRestPeriod={RemainingRestPeriod})";
        }
    }
}