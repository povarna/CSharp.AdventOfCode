namespace AoC.Year2015.Day21;

public class Problem
{
    public int Part1(string input)
    {
        var boss = ParseInput(input);
        var minGold = int.MaxValue;

        foreach (var c in Buy())
        {
            if (DefeatBoss((c.damage, c.armor, 100), boss))
            {
                minGold = Math.Min(c.gold, minGold);
            }
        }

        return minGold;
    }

    public object Part2(string input)
    {
        var boss = ParseInput(input);
        var maxGold = 0;
        foreach (var c in Buy())
        {
            if (!DefeatBoss((c.damage, c.armor, 100), boss))
            {
                maxGold = Math.Max(c.gold, maxGold);
            }
        }

        return maxGold;
    }

    private static (int damage, int armor, int hp) ParseInput(string input)
    {
        var properties = input.Split("\n");
        if (properties.Length != 3)
            throw new ArgumentException("Invalid input!");

        return
            (int.Parse(properties[1].Split(": ")[1]),
                int.Parse(properties[2].Split(": ")[1]),
                int.Parse(properties[0].Split(": ")[1]));
    }

    private static bool DefeatBoss((int damage, int armor, int hp) player, (int damage, int armor, int hp) boss)
    {
        while (true)
        {
            boss.hp -= Math.Max(player.damage - boss.armor, 1);
            if (boss.hp <= 0)
                return true;

            player.hp -= Math.Max(boss.damage - player.armor, 1);
            if (player.hp <= 0)
                return false;
        }
    }

    private static IEnumerable<(int gold, int damage, int armor)> Buy()
    {
        return
            from weapon in Buy(1, 1, new[] { (8, 4, 0), (10, 5, 0), (25, 6, 0), (40, 7, 0), (74, 8, 0) })
            from armor in Buy(0, 1, new[] { (13, 0, 1), (31, 0, 2), (53, 0, 3), (75, 0, 4), (102, 0, 5) })
            from ring in Buy(1, 2, new[] { (25, 1, 0), (50, 2, 0), (100, 3, 0), (20, 0, 1), (40, 0, 2), (80, 0, 3) })
            select Sum(weapon, armor, ring);
    }

    private static IEnumerable<(int gold, int damage, int armour)> Buy(int min, int max,
        IReadOnlyList<(int gold, int damage, int armor)> items)
    {
        if (min == 0)
            yield return (0, 0, 0);

        foreach (var item in items)
            yield return item;

        if (max != 2) yield break;

        for (var i = 0; i < items.Count; i++)
        for (var j = i + 1; j < items.Count; j++)
            yield return Sum(items[i], items[j]);
    }

    private static (int gold, int damage, int armour) Sum(params (int gold, int damage, int armor)[] items)
    {
        var gold = items.Select(item => item.gold).Sum();
        var damage = items.Select(item => item.damage).Sum();
        var armour = items.Select(item => item.armor).Sum();
        return (gold, damage, armour);
    }
}