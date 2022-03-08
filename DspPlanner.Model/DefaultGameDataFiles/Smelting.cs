using System.Collections.Immutable;
using Rationals;

namespace DspPlanner.Model.DefaultGameDataFiles;

internal class Smelting : DefaultGameDataBase
{
    private static Recipe SimpleMiningRecipe(string input, string output, decimal inputToOutputRatio = 1) =>
        new Recipe(output, ReplicatorOrSmelterType, new Duration(inputToOutputRatio),
            Item.List(new Item(input).Volume((Rational)inputToOutputRatio)),
            Item.List(new Item(output).Volume(1)));

    public ImmutableList<Recipe> Recipes { get; } =
        ImmutableList.Create(
            SimpleMiningRecipe("Copper Ore", "Copper Ingot"),
            SimpleMiningRecipe("Iron Ore", "Iron Ingot"),
            SimpleMiningRecipe("Silicon Ore", "High-purity Silicon"),
            SimpleMiningRecipe("Stone", "Stone Brick"),
            SimpleMiningRecipe("Stone", "Glass", 2),
            SimpleMiningRecipe("Coal", "Energetic Graphite", 2),
            SimpleMiningRecipe("Titanium Ore", "Titanium Ingot", 2),

            new Recipe("Magnet", ReplicatorOrSmelterType, new Duration(1.5m),
                Item.List(new Item("Iron Ore").Volume(1)),
                Item.List(new Item("Magnet").Volume(1))),

            new Recipe("Steel", SmelterType, new Duration(3),
                Item.List(new Item("Iron Ingot").Volume(3)),
                Item.List(new Item("Steel").Volume(1))),
            new Recipe("Silicon Ore", SmelterType, new Duration(10),
                Item.List(new Item("Stone").Volume(10)),
                Item.List(new Item("Silicon Ore").Volume(1))),
            new Recipe("Diamond", SmelterType, new Duration(2),
                Item.List(new Item("Energetic Graphite").Volume(1)),
                Item.List(new Item("Diamond").Volume(1))),
            new Recipe("Kimberlite Ore", SmelterType, new Duration(2),
                Item.List(new Item("Kimberlite Ore").Volume(1)),
                Item.List(new Item("Diamond").Volume(1))),
            new Recipe("Titanium Alloy", SmelterType, new Duration(12),
                Item.List(
                    new Item("Steel").Volume(4),
                    new Item("Sulfuric Acid").Volume(8),
                    new Item("Titanium Ingot").Volume(4)),
                Item.List(new Item("Titanium Alloy").Volume(4))));

    public ImmutableList<Item> SmeltedItems { get; } =
        ImmutableList.Create(
            new Item("Copper Ingot"),
            new Item("Iron Ingot"),
            new Item("Magnet"),
            new Item("Steel"),
            new Item("High-purity Silicon"),
            new Item("Stone Brick"),
            new Item("Glass"),
            new Item("Energetic Graphite"),
            new Item("Titanium Ingot"),
            new Item("Diamond"),
            new Item("Titanium Alloy"));
}
