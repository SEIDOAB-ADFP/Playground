using System.Collections.Immutable;
using Playground.Projects.Yahtzee.Extensions;
using Playground.Projects.Yahtzee.Models;
using PlayGround.Extensions;

namespace Playground.Projects.Yahtzee;

public static class YahzeeGame
{
    public static void RunSimulation()
    {
        Console.WriteLine("Testing the Cup of Dice.");

        var cupOfDice = new CupOfDice(10);
        Console.WriteLine($"Cup with 10 dice: {cupOfDice}\n");

        cupOfDice = new CupOfDice(2);
        Console.WriteLine($"Cup with 2 dice: {cupOfDice}\n");

        var yahzeeCup = new YahzeeCup();
        Console.WriteLine($"Yahzee Cup with 5 dice: {yahzeeCup}\n");

        Enumerable.Range(1, 10)
            .Aggregate(yahzeeCup, (currentCup, i) =>
            {
                var newCup = currentCup.ShakeAndRoll();

                newCup.Tap(cup => Console.WriteLine($"Yahzee Cup with 5 dice: {cup}"))
                    .GetYahtzeeCombination()
                    .Tap(ycombo => Console.WriteLine($"Yahzee Combination: {ycombo.GetType().Name}, Score: {ycombo.Score}\n"));

                return newCup;
            });

        // skapar spelarna
        ImmutableList<Player> players = ImmutableList.Create(
            new Player("Jessica", new YahzeeCup()),
            new Player("Maria", new YahzeeCup()),
            new Player("Anders", new YahzeeCup())
        );

        // skapa scorecards per spelare
        var scoreCards = ImmutableDictionary.CreateBuilder<string, ScoreCard>();
        foreach (var player in players)
            scoreCards[player.Name] = new ScoreCard();

        // spelets state
        var gameState = (Players: players, ScoreCards: scoreCards.ToImmutable());

        Console.WriteLine("\nYahtzee Round Simulation:");

        // spelet körs 13 rundor
        var finalState = Enumerable.Range(1, 13)
            .Aggregate(gameState, (state, round) =>
            {
                Console.WriteLine($"\n--- Round {round} ---");

                var updatedScoreCards = state.Players.Select(player =>
                {
                    // rulla tärningar
                    var rolledCup = player.YahzeeCup.ShakeAndRoll();

                    // hitta bästa kombination
                    var bestCombo = rolledCup.GetYahtzeeCombination();

                    // uppdatera scorecard immutabelt
                    var updatedScoreCard = state.ScoreCards[player.Name].FillBox(bestCombo);

                    //skriver ut resultatet
                    Console.WriteLine($"{player.Name} rolled {rolledCup}, scored {bestCombo.Score} on {bestCombo.GetType().Name}");

                    return (player.Name, updatedScoreCard);
                }).ToImmutableDictionary(kv => kv.Name, kv => kv.updatedScoreCard);

                // namnmatchningen måste vara exakt
                return (Players: state.Players, ScoreCards: updatedScoreCards);
            });

        //slutresultat
        Console.WriteLine("\nFinal Scores:");
        foreach (var kv in finalState.ScoreCards)
        {
            Console.WriteLine($"{kv.Key}: Total Score = {kv.Value.TotalScore()} (Upper Bonus: {kv.Value.UpperBonus()})");
        }

        // Hitta overall vinnare
        var winner = finalState.ScoreCards.OrderByDescending(kv => kv.Value.TotalScore()).First();
        Console.WriteLine($"\nOVERALL WINNER: {winner.Key} with {winner.Value.TotalScore()} points");
    }
}