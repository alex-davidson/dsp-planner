using System.Collections.Immutable;

namespace DspPlanner.Model.DefaultGameDataFiles;

internal class LogisticsBuildings : DefaultGameDataBase
{
    public ImmutableList<Recipe> Recipes { get; } =
        ImmutableList.Create(
            new Recipe("Splitter", ReplicatorOrAssemblerType, new Duration(2),
                Item.List(
                    new Item("Circuit Board").Volume(1),
                    new Item("Gear").Volume(2),
                    new Item("Iron Ingot").Volume(3)),
                Item.List(new Item("Splitter").Volume(1))),

            new Recipe("Conveyor Belt Mk.I", ReplicatorOrAssemblerType, new Duration(1),
                Item.List(
                    new Item("Gear").Volume(1),
                    new Item("Iron Ingot").Volume(2)),
                Item.List(new Item("Conveyor Belt Mk.I").Volume(3))),
            new Recipe("Conveyor Belt Mk.II", ReplicatorOrAssemblerType, new Duration(1),
                Item.List(
                    new Item("Conveyor Belt Mk.I").Volume(3),
                    new Item("Electromagnetic Turbine").Volume(1)),
                Item.List(new Item("Conveyor Belt Mk.II").Volume(3))),
            new Recipe("Conveyor Belt Mk.III", ReplicatorOrAssemblerType, new Duration(1),
                Item.List(
                    new Item("Conveyor Belt Mk.II").Volume(3),
                    new Item("Graphene").Volume(1),
                    new Item("Super-magnetic Ring").Volume(1)),
                Item.List(new Item("Conveyor Belt Mk.III").Volume(3))),

            new Recipe("Sorter Mk.I", ReplicatorOrAssemblerType, new Duration(1),
                Item.List(
                    new Item("Circuit Board").Volume(1),
                    new Item("Iron Ingot").Volume(1)),
                Item.List(new Item("Sorter Mk.I").Volume(1))),
            new Recipe("Sorter Mk.II", ReplicatorOrAssemblerType, new Duration(1),
                Item.List(
                    new Item("Sorter Mk.I").Volume(2),
                    new Item("Electric Motor").Volume(1)),
                Item.List(new Item("Sorter Mk.II").Volume(2))),
            new Recipe("Sorter Mk.III", ReplicatorOrAssemblerType, new Duration(1),
                Item.List(
                    new Item("Sorter Mk.II").Volume(2),
                    new Item("Electromagnetic Turbine").Volume(1)),
                Item.List(new Item("Sorter Mk.III").Volume(2))),

            new Recipe("Storage Mk.I", ReplicatorOrAssemblerType, new Duration(2),
                Item.List(
                    new Item("Iron Ingot").Volume(4),
                    new Item("Stone Brick").Volume(4)),
                Item.List(new Item("Storage Mk.I").Volume(1))),
            new Recipe("Storage Mk.II", ReplicatorOrAssemblerType, new Duration(4),
                Item.List(
                    new Item("Steel").Volume(8),
                    new Item("Stone Brick").Volume(8)),
                Item.List(new Item("Storage Mk.II").Volume(1))),
            new Recipe("Storage Tank", ReplicatorOrAssemblerType, new Duration(2),
                Item.List(
                    new Item("Glass").Volume(4),
                    new Item("Iron Ingot").Volume(8),
                    new Item("Stone Brick").Volume(4)),
                Item.List(new Item("Storage Tank").Volume(1))),

            new Recipe("Planetary Logistics Station", ReplicatorOrAssemblerType, new Duration(20),
                Item.List(
                    new Item("Particle Container").Volume(20),
                    new Item("Processor").Volume(40),
                    new Item("Steel").Volume(40),
                    new Item("Titanium Ingot").Volume(40)),
                Item.List(new Item("Planetary Logistics Station").Volume(1))),
            new Recipe("Interstellar Logistics Station", ReplicatorOrAssemblerType, new Duration(30),
                Item.List(
                    new Item("Planetary Logistics Station").Volume(1),
                    new Item("Particle Container").Volume(20),
                    new Item("Titanium Alloy").Volume(40)),
                Item.List(new Item("Interstellar Logistics Station").Volume(1))),
            new Recipe("Orbital Collector", ReplicatorOrAssemblerType, new Duration(30),
                Item.List(
                    new Item("Interstellar Logistics Station").Volume(1),
                    new Item("Accumulator (Full)").Volume(20),
                    new Item("Super-magnetic Ring").Volume(50),
                    new Item("Reinforced Thruster").Volume(20)),
                Item.List(new Item("Orbital Collector").Volume(1))));

    public ImmutableList<Item> BuildingItems { get; } =
        ImmutableList.Create(
            new Item("Splitter"),
            new Item("Conveyor Belt Mk.I"),
            new Item("Conveyor Belt Mk.II"),
            new Item("Conveyor Belt Mk.III"),
            new Item("Sorter Mk.I"),
            new Item("Sorter Mk.II"),
            new Item("Sorter Mk.III"),
            new Item("Storage Mk.I"),
            new Item("Storage Mk.II"),
            new Item("Storage Tank"),
            new Item("Planetary Logistics Station"),
            new Item("Interstellar Logistics Station"),
            new Item("Orbital Collector")
            );
}
