using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DspPlanner.Model;

namespace DspPlanner.UnitTests;

internal class GameDataDifferenceDescriber
{
    public string Left { get; set; } = "Left";
    public string Right { get; set; } = "Right";

    public string Describe(IGameData left, IGameData right)
    {
        var writer = new StringWriter();
        Describe(left, right, writer);
        return writer.ToString();
    }

    public void Describe(IGameData left, IGameData right, TextWriter differences)
    {
        foreach (var item in Join(left.AllItems, right.AllItems, x => x.Identifier))
        {
            if (item.Left.SetEquals(item.Right)) continue;
            differences.WriteLine($"Item {item.Key} differs.");
            if (item.Left.Count != item.Right.Count)
            {
                differences.WriteLine($"* {Left} has {item.Left.Count}, {Right} has {item.Right.Count}");
            }
        }

        foreach (var recipe in Join(left.Recipes, right.Recipes, x => x.Name))
        {
            if (recipe.Left.SetEquals(recipe.Right)) continue;
            differences.WriteLine($"Recipe {recipe.Key} differs.");
            if (recipe.Left.Count != recipe.Right.Count)
            {
                differences.WriteLine($"* {Left} has {recipe.Left.Count}, {Right} has {recipe.Right.Count}");
            }
        }

        foreach (var factory in Join(left.Factories, right.Factories, x => x.BuildingItem.Identifier))
        {
            if (factory.Left.SetEquals(factory.Right)) continue;
            differences.WriteLine($"Factory {factory.Key} differs.");
            if (factory.Left.Count != factory.Right.Count)
            {
                differences.WriteLine($"* {Left} has {factory.Left.Count}, {Right} has {factory.Right.Count}");
            }
        }

        foreach (var proliferator in Join(left.Proliferators, right.Proliferators, x => x.Identifier))
        {
            if (proliferator.Left.SetEquals(proliferator.Right)) continue;
            differences.WriteLine($"Proliferator {proliferator.Key} differs.");
            if (proliferator.Left.Count != proliferator.Right.Count)
            {
                differences.WriteLine($"* {Left} has {proliferator.Left.Count}, {Right} has {proliferator.Right.Count}");
            }
        }
    }

    private static IEnumerable<(TProp Key, ISet<T> Left, ISet<T> Right)> Join<T, TProp>(IEnumerable<T> left, IEnumerable<T> right, Func<T, TProp> getKey)
    {
        var leftLookup = left.ToLookup(getKey);
        var rightLookup = right.ToLookup(getKey);

        var allKeys = leftLookup.Concat(rightLookup).Select(l => l.Key).Distinct().ToList();
        foreach (var key in allKeys)
        {
            yield return (key, leftLookup[key].ToHashSet(), rightLookup[key].ToHashSet());
        }
    }
}
