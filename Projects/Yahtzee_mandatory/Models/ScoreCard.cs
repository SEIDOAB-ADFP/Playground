using System.Collections.Immutable;
using System.Linq;
using Playground.Projects.Yahtzee.Models;

namespace Playground.Projects.Yahtzee.Models;

public record ScoreCard
{
    // immutable dictionary för poäng
    private ImmutableDictionary<string, int> scores;

    public ScoreCard()
    {
        scores = ImmutableDictionary<string, int>.Empty;
    }

    // fyll box för en Yahtzee-kombination
    public ScoreCard FillBox(YahzeeCup combo)
    {
        var name = combo.GetType().Name;

        // om boxen redan är fylld returnera samma ScoreCard
        if (scores.ContainsKey(name))
            return this;

        // lägger till poäng
        var newScores = scores.Add(name, combo.Score);
        return this with { scores = newScores };
    }

    // totalpoäng inklusive Upper Bonus
    public int TotalScore() => scores.Values.Sum() + UpperBonus();

    // summa av Upper Section
    public int UpperSectionTotal() =>
        new[] { "Ones", "Twos", "Threes", "Fours", "Fives", "Sixes" }
            .Where(key => scores.ContainsKey(key))
            .Sum(key => scores[key]);

    // upper Section bonus: 35 poäng om total ≥ 63
    public int UpperBonus() => UpperSectionTotal() >= 63 ? 35 : 0;

    // för debugg
    public override string ToString()
    {
        if (scores.IsEmpty) return "(inget poäng ännu)";
        return string.Join(", ", scores.Select(kv => $"{kv.Key}: {kv.Value}"));
    }
}