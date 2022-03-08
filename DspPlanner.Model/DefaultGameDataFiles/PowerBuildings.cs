using System.Collections.Immutable;

namespace DspPlanner.Model.DefaultGameDataFiles;

internal class PowerBuildings : DefaultGameDataBase
{
    public ImmutableList<Recipe> Recipes { get; } =
        ImmutableList.Create(
            new Recipe("Wind Turbine", ReplicatorOrAssemblerType, new Duration(4),
                Item.List(
                    new Item("Gear").Volume(1),
                    new Item("Iron Ingot").Volume(6),
                    new Item("Magnetic Coil").Volume(3)),
                Item.List(new Item("Wind Turbine").Volume(1))),
            new Recipe("Solar Panel", ReplicatorOrAssemblerType, new Duration(5),
                Item.List(
                    new Item("Circuit Board").Volume(4),
                    new Item("Copper Ingot").Volume(6),
                    new Item("High-purity Silicon").Volume(6)),
                Item.List(new Item("Solar Panel").Volume(1))),
            new Recipe("Thermal Power Plant", ReplicatorOrAssemblerType, new Duration(5),
                Item.List(
                    new Item("Gear").Volume(4),
                    new Item("Iron Ingot").Volume(10),
                    new Item("Magnetic Coil").Volume(4),
                    new Item("Stone Brick").Volume(4)),
                Item.List(new Item("Thermal Power Plant").Volume(1))),
            new Recipe("Mini Fusion Power Plant", ReplicatorOrAssemblerType, new Duration(5),
                Item.List(
                    new Item("Super-magnetic Ring").Volume(10),
                    new Item("Carbon Nanotube").Volume(8),
                    new Item("Processor").Volume(4),
                    new Item("Titanium Alloy").Volume(12)),
                Item.List(new Item("Mini Fusion Power Plant").Volume(1))),
            new Recipe("Artificial Star", ReplicatorOrAssemblerType, new Duration(30),
                Item.List(
                    new Item("Frame Material").Volume(20),
                    new Item("Annihilation Constraint Sphere").Volume(10),
                    new Item("Quantum Chip").Volume(10),
                    new Item("Titanium Alloy").Volume(20)),
                Item.List(new Item("Artificial Star").Volume(1))),

            new Recipe("Accumulator", ReplicatorOrAssemblerType, new Duration(5),
                Item.List(
                    new Item("Super-magnetic Ring").Volume(6),
                    new Item("Iron Ingot").Volume(6),
                    new Item("Crystal Silicon").Volume(4)),
                Item.List(new Item("Accumulator").Volume(1))),
            new Recipe("Accumulator (Full)", EnergyExchangerType, new Duration(2),
                Item.List(
                    new Item("Accumulator").Volume(1)),
                Item.List(new Item("Accumulator (Full)").Volume(1))),

            new Recipe("Tesla Tower", ReplicatorOrAssemblerType, new Duration(1),
                Item.List(
                    new Item("Iron Ingot").Volume(2),
                    new Item("Magnetic Coil").Volume(1)),
                Item.List(new Item("Tesla Tower").Volume(1))),
            new Recipe("Wireless Power Tower", ReplicatorOrAssemblerType, new Duration(3),
                Item.List(
                    new Item("Tesla Tower").Volume(1),
                    new Item("Plasma Exciter").Volume(3)),
                Item.List(new Item("Wireless Power Tower").Volume(1))),
            new Recipe("Satellite Substation", ReplicatorOrAssemblerType, new Duration(5),
                Item.List(
                    new Item("Wireless Power Tower").Volume(1),
                    new Item("Frame Material").Volume(2),
                    new Item("Super-magnetic Ring").Volume(10)),
                Item.List(new Item("Satellite Substation").Volume(1))));

    public ImmutableList<Item> BuildingItems { get; } =
        ImmutableList.Create(
            new Item("Wind Turbine"),
            new Item("Solar Panel"),
            new Item("Thermal Power Plant"),
            new Item("Mini Fusion Power Plant"),
            new Item("Artificial Star"),
            new Item("Accumulator"),
            new Item("Accumulator (Full)"),
            new Item("Tesla Tower"),
            new Item("Wireless Power Tower"),
            new Item("Satellite Substation"));
}
