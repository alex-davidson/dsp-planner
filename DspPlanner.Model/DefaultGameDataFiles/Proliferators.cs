using System.Collections.Immutable;

namespace DspPlanner.Model.DefaultGameDataFiles;

internal class Proliferation : DefaultGameDataBase
{
    public ImmutableList<Item> ProliferatorItems { get; } =
        ImmutableList.Create(
            new Item("Proliferator Mk.I"),
            new Item("Proliferator Mk.II"),
            new Item("Proliferator Mk.III"));

    public ImmutableList<Recipe> Recipes { get; } =
        ImmutableList.Create(
            new Recipe("Proliferator Mk.I", ReplicatorOrAssemblerType, new Duration(0.5m),
                Item.List(new Item("Coal").Volume(1)),
                Item.List(new Item("Proliferator Mk.I").Volume(1))),
            new Recipe("Proliferator Mk.II", ReplicatorOrAssemblerType, new Duration(1),
                Item.List(new Item("Diamond").Volume(1), new Item("Proliferator Mk.I").Volume(2)),
                Item.List(new Item("Proliferator Mk.II").Volume(1))),
            new Recipe("Proliferator Mk.III", ReplicatorOrAssemblerType, new Duration(2),
                Item.List(new Item("Carbon Nanotube").Volume(1), new Item("Proliferator Mk.II").Volume(2)),
                Item.List(new Item("Proliferator Mk.III").Volume(1))));

    public ImmutableList<Proliferator> Proliferators { get; } =
        ImmutableList.Create(
            new Proliferator("Proliferator Mk.I", 12, new Percentage(25), new Percentage(12.5m), new Percentage(30)),
            new Proliferator("Proliferator Mk.II", 24, new Percentage(50), new Percentage(20), new Percentage(70)),
            new Proliferator("Proliferator Mk.III", 60, new Percentage(100), new Percentage(25), new Percentage(150)));
}
