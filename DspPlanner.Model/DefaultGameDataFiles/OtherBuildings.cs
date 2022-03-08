using System.Collections.Immutable;

namespace DspPlanner.Model.DefaultGameDataFiles;

internal class OtherBuildings : DefaultGameDataBase
{
    public ImmutableList<Recipe> Recipes { get; } =
        ImmutableList.Create(
            new Recipe("EM-Rail Ejector", ReplicatorOrAssemblerType, new Duration(6),
                Item.List(
                    new Item("Gear").Volume(20),
                    new Item("Super-magnetic Ring").Volume(10),
                    new Item("Processor").Volume(5),
                    new Item("Steel").Volume(20)),
                Item.List(new Item("EM-Rail Ejector").Volume(1))),

            new Recipe("Vertical Launching Silo", ReplicatorOrAssemblerType, new Duration(30),
                Item.List(
                    new Item("Frame Material").Volume(30),
                    new Item("Graviton Lens").Volume(20),
                    new Item("Quantum Chip").Volume(10),
                    new Item("Titanium Alloy").Volume(80)),
                Item.List(new Item("Vertical Launching Silo").Volume(1))));

    public ImmutableList<Item> BuildingItems { get; } =
        ImmutableList.Create(
            new Item("EM-Rail Ejector"),
            new Item("Vertical Launching Silo"));
}
