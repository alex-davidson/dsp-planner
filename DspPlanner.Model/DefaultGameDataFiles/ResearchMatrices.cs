using System.Collections.Immutable;

namespace DspPlanner.Model.DefaultGameDataFiles;

internal class ResearchMatrices : DefaultGameDataBase
{
    public ImmutableList<Recipe> Recipes { get; } =
        ImmutableList.Create(
            new Recipe("Electromagnetic Matrix", ReplicatorOrResearchLabType, new Duration(3),
                Item.List(
                    new Item("Circuit Board").Volume(1),
                    new Item("Magnetic Coil").Volume(1)),
                Item.List(new Item("Electromagnetic Matrix").Volume(1))),
            new Recipe("Energy Matrix", ReplicatorOrResearchLabType, new Duration(6),
                Item.List(
                    new Item("Energetic Graphite").Volume(2),
                    new Item("Hydrogen").Volume(2)),
                Item.List(new Item("Energy Matrix").Volume(1))),
            new Recipe("Structure Matrix", ReplicatorOrResearchLabType, new Duration(8),
                Item.List(
                    new Item("Diamond").Volume(1),
                    new Item("Titanium Crystal").Volume(1)),
                Item.List(new Item("Structure Matrix").Volume(1))),
            new Recipe("Information Matrix", ReplicatorOrResearchLabType, new Duration(10),
                Item.List(
                    new Item("Particle Broadband").Volume(1),
                    new Item("Processor").Volume(2)),
                Item.List(new Item("Information Matrix").Volume(1))),
            new Recipe("Gravity Matrix", ReplicatorOrResearchLabType, new Duration(24),
                Item.List(
                    new Item("Graviton Lens").Volume(1),
                    new Item("Quantum Chip").Volume(1)),
                Item.List(new Item("Gravity Matrix").Volume(2))),
            new Recipe("Universe Matrix", ReplicatorOrResearchLabType, new Duration(24),
                Item.List(
                    new Item("Electromagnetic Matrix").Volume(1),
                    new Item("Energy Matrix").Volume(1),
                    new Item("Structure Matrix").Volume(1),
                    new Item("Information Matrix").Volume(1),
                    new Item("Gravity Matrix").Volume(1),
                    new Item("Antimatter").Volume(1)),
                Item.List(new Item("Universe Matrix").Volume(1))));

    public ImmutableList<Item> Items { get; } =
        ImmutableList.Create(
            new Item("Electromagnetic Matrix"),
            new Item("Energy Matrix"),
            new Item("Structure Matrix"),
            new Item("Information Matrix"),
            new Item("Gravity Matrix"),
            new Item("Universe Matrix"));
}
