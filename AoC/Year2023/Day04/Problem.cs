using System.Text.RegularExpressions;

namespace AoC.Year2023.Day04;

public class Problem
{
    public int Part1(string input) => (int)(
        from line in input.Split("\n")
        let card = ParseCard(line)
        where card.matches > 0
        select Math.Pow(2, card.matches - 1)
    ).Sum();

    // Quite imperatively, just walk over the cards keeping track of the counts.
    public int Part2(string input) {
        var cards = input.Split("\n").Select(ParseCard).ToArray();
        var counts = cards.Select(_ => 1).ToArray();
        
        foreach (var card in counts)
        {
            Console.WriteLine(card);
        }

        Console.WriteLine(counts.Length);

        for (var i = 0; i < cards.Length; i++) {
            var (card, count) = (cards[i], counts[i]);
            for (var j = 0; j < card.matches; j++) {
                counts[i + j + 1] += count;
            }
        }
        return counts.Sum();
    }

    // Only the match count is relevant for a card
    Card ParseCard(string line) {
        var parts = line.Split(':', '|');
        var l = from m in Regex.Matches(parts[1], @"\d+") select m.Value;
        var r = from m in Regex.Matches(parts[2], @"\d+") select m.Value;
        return new Card(l.Intersect(r).Count());
    }
}

record Card(int matches);
