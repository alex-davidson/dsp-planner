using System.Collections.Immutable;

namespace DspPlanner.Model.DefaultGameDataFiles;

internal class NaturalResourcesAndHarvesting : DefaultGameDataBase
{
    public ImmutableList<Item> NaturalResourceItemsReplicatorOnly { get; } =
        ImmutableList.Create(
            new Item("Plant Fuel"),
            new Item("Log"));

    public ImmutableList<Item> ResourceNodes { get; } =
        ImmutableList.Create(
            new Item("Copper Vein"),
            new Item("Iron Vein"),
            new Item("Stone Vein"),
            new Item("Silicon Vein"),
            new Item("Fractal Silicon Vein"),
            new Item("Unipolar Magnet Vein"),
            new Item("Star"),
            new Item("Crude Oil Vein"),
            new Item("Ice Giant"),
            new Item("Fire Ice Vein"),
            new Item("Coal Vein"),
            new Item("Gas Giant"),
            new Item("Optical Grating Rock Vein"),
            new Item("Titanium Vein"),
            new Item("Sulfur Sea"),
            new Item("Water Sea"),
            new Item("Organic Crystal Vein"),
            new Item("Kimberlite Vein"),
            new Item("Spiniform Stalagmite Crystal Vein")
        );

    private static Recipe SimpleMiningRecipe(string node, string output, decimal seconds = 1) =>
        new Recipe(output, ReplicatorOrMinerType, new Duration(seconds),
            Item.List(new Item(node).Volume(1)),
            Item.List(new Item(output).Volume(1)));

    public ImmutableList<Recipe> Recipes { get; } =
        ImmutableList.Create(
            SimpleMiningRecipe("Copper Vein", "Copper Ore"),
            SimpleMiningRecipe("Iron Vein", "Iron Ore"),
            SimpleMiningRecipe("Stone Vein", "Stone"),
            SimpleMiningRecipe("Silicon Vein", "Silicon Ore"),
            SimpleMiningRecipe("Fractal Silicon Vein", "Fractal Silicon"),
            SimpleMiningRecipe("Unipolar Magnet Vein", "Unipolar Magnet", 2),
            SimpleMiningRecipe("Fire Ice Vein", "Fire Ice"),
            SimpleMiningRecipe("Coal Vein", "Coal"),
            SimpleMiningRecipe("Optical Grating Rock Vein", "Optical Grating Crystal"),
            SimpleMiningRecipe("Titanium Vein", "Titanium Ore"),
            SimpleMiningRecipe("Organic Crystal Vein", "Organic Crystal"),
            SimpleMiningRecipe("Kimberlite Vein", "Kimberlite Ore"),
            SimpleMiningRecipe("Spiniform Stalagmite Crystal Vein", "Spiniform stalagmite Crystal"),

            new Recipe("Critical Photon", RayReceiverType, new Duration(12),
                Item.List(new Item("Star").Volume(0)),
                Item.List(new Item("Critical Photon").Volume(1))),
            new Recipe("Critical Photon", RayReceiverType, new Duration(6),
                Item.List(
                    new Item("Star").Volume(0),
                    new Item("Graviton Lens").Volume(0)),
                Item.List(new Item("Critical Photon").Volume(1))),

            new Recipe("Crude Oil", OilExtractorType, new Duration(1),
                Item.List(new Item("Crude Oil Vein").Volume(0)),
                Item.List(new Item("Crude Oil").Volume(1))),

            new Recipe("Hydrogen", OrbitalCollectorType, new Duration(1),
                Item.List(new Item("Ice Giant").Volume(0)),
                Item.List(new Item("Hydrogen").Volume(1))),
            new Recipe("Hydrogen", OrbitalCollectorType, new Duration(1),
                Item.List(new Item("Gas Giant").Volume(0)),
                Item.List(new Item("Hydrogen").Volume(1))),
            new Recipe("Fire Ice", OrbitalCollectorType, new Duration(1),
                Item.List(new Item("Ice Giant").Volume(0)),
                Item.List(new Item("Fire Ice").Volume(1))),
            new Recipe("Deuterium", OrbitalCollectorType, new Duration(1),
                Item.List(new Item("Gas Giant").Volume(0)),
                Item.List(new Item("Deuterium").Volume(1))),

            new Recipe("Sulfuric Acid", WaterPumpType, new Duration(0.83m),
                Item.List(new Item("Sulfur Sea").Volume(0)),
                Item.List(new Item("Sulfuric Acid").Volume(1))),
            new Recipe("Water", WaterPumpType, new Duration(0.83m),
                Item.List(new Item("Water Sea").Volume(0)),
                Item.List(new Item("Water").Volume(1))));

    public ImmutableList<Item> NaturalResourceItems { get; } =
        ImmutableList.Create(
            new Item("Iron Ore"),
            new Item("Copper Ore"),
            new Item("Stone"),
            new Item("Silicon Ore"),
            new Item("Fractal Silicon"),
            new Item("Unipolar Magnet"),
            new Item("Crude Oil"),
            new Item("Critical Photon"),
            new Item("Fire Ice"),
            new Item("Coal"),
            new Item("Optical Grating Crystal"),
            new Item("Titanium Ore"),
            new Item("Hydrogen"),
            new Item("Deuterium"),
            new Item("Sulfuric Acid"),
            new Item("Water"),
            new Item("Deuterium"),
            new Item("Organic Crystal"),
            new Item("Kimberlite Ore"),
            new Item("Spiniform stalagmite Crystal"));
}
