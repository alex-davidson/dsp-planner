using System.Collections.Immutable;
using Rationals;

namespace DspPlanner.Model.DefaultGameDataFiles;

internal class BasicManufacturing : DefaultGameDataBase
{
    public ImmutableList<Recipe> Recipes { get; } =
        ImmutableList.Create(
            new Recipe("Gear", ReplicatorOrAssemblerType, new Duration(1),
                Item.List(new Item("Iron Ingot").Volume(1)),
                Item.List(new Item("Gear").Volume(1))),
            new Recipe("Magnetic Coil", ReplicatorOrAssemblerType, new Duration(1),
                Item.List(
                    new Item("Copper Ingot").Volume(1),
                    new Item("Magnet").Volume(2)),
                Item.List(new Item("Magnetic Coil").Volume(2))),
            new Recipe("Electric Motor", ReplicatorOrAssemblerType, new Duration(2),
                Item.List(
                    new Item("Gear").Volume(1),
                    new Item("Iron Ingot").Volume(2),
                    new Item("Magnetic Coil").Volume(1)),
                Item.List(new Item("Electric Motor").Volume(1))),
            new Recipe("Electromagnetic Turbine", ReplicatorOrAssemblerType, new Duration(2),
                Item.List(
                    new Item("Electric Motor").Volume(2),
                    new Item("Magnetic Coil").Volume(2)),
                Item.List(new Item("Electromagnetic Turbine").Volume(1))),
            new Recipe("Super-magnetic Ring", ReplicatorOrAssemblerType, new Duration(3),
                Item.List(
                    new Item("Energetic Graphite").Volume(1),
                    new Item("Electromagnetic Turbine").Volume(2),
                    new Item("Magnet").Volume(3)),
                Item.List(new Item("Super-magnetic Ring").Volume(1))),

            new Recipe("Circuit Board", ReplicatorOrAssemblerType, new Duration(1),
                Item.List(
                    new Item("Copper Ingot").Volume(1),
                    new Item("Iron Ingot").Volume(2)),
                Item.List(new Item("Circuit Board").Volume(2))),
            new Recipe("Microcrystalline Component", ReplicatorOrAssemblerType, new Duration(2),
                Item.List(
                    new Item("Copper Ingot").Volume(1),
                    new Item("High-purity Silicon").Volume(2)),
                Item.List(new Item("Microcrystalline Component").Volume(1))),
            new Recipe("Processor", ReplicatorOrAssemblerType, new Duration(3),
                Item.List(
                    new Item("Circuit Board").Volume(2),
                    new Item("Microcrystalline Component").Volume(2)),
                Item.List(new Item("Processor").Volume(1))),

            new Recipe("Prism", ReplicatorOrAssemblerType, new Duration(2),
                Item.List(new Item("Glass").Volume(3)),
                Item.List(new Item("Prism").Volume(2))),
            new Recipe("Photon Combiner", ReplicatorOrAssemblerType, new Duration(3),
                Item.List(
                    new Item("Circuit Board").Volume(1),
                    new Item("Prism").Volume(2)),
                Item.List(new Item("Photon Combiner").Volume(1))),

            new Recipe("Plasma Exciter", ReplicatorOrAssemblerType, new Duration(2),
                Item.List(
                    new Item("Prism").Volume(2),
                    new Item("Magnetic Coil").Volume(4)),
                Item.List(new Item("Plasma Exciter").Volume(1))),
            new Recipe("Particle Container", ReplicatorOrAssemblerType, new Duration(4),
                Item.List(
                    new Item("Copper Ingot").Volume(2),
                    new Item("Graphene").Volume(2),
                    new Item("Electromagnetic Turbine").Volume(2)),
                Item.List(new Item("Particle Container").Volume(1))),

            new Recipe("Foundation", ReplicatorOrAssemblerType, new Duration(1),
                Item.List(
                    new Item("Steel").Volume(1),
                    new Item("Stone Brick").Volume(3)),
                Item.List(new Item("Foundation").Volume(1))),

            new Recipe("Hydrogen Fuel Rod", ReplicatorOrAssemblerType, new Duration(3),
                Item.List(
                    new Item("Hydrogen").Volume(5),
                    new Item("Titanium Ingot").Volume(1)),
                Item.List(new Item("Hydrogen Fuel Rod").Volume(1))),

            new Recipe("Titanium Crystal", ReplicatorOrAssemblerType, new Duration(4),
                Item.List(
                    new Item("Organic Crystal").Volume(1),
                    new Item("Titanium Ingot").Volume(3)),
                Item.List(new Item("Titanium Crystal").Volume(1))),
            new Recipe("Titanium Glass", ReplicatorOrAssemblerType, new Duration(5),
                Item.List(
                    new Item("Glass").Volume(2),
                    new Item("Titanium Ingot").Volume(2),
                    new Item("Water").Volume(2)),
                Item.List(new Item("Titanium Glass").Volume(2))),

            new Recipe("Crystal Silicon", AssemblerType, new Duration(4),
                Item.List(new Item("Fractal Silicon").Volume(1)),
                Item.List(new Item("Crystal Silicon").Volume(1))),
            new Recipe("Particle Container", AssemblerType, new Duration(4),
                Item.List(
                    new Item("Copper Ingot").Volume(2),
                    new Item("Unipolar Magnet").Volume(10)),
                Item.List(new Item("Particle Container").Volume(1))),
            new Recipe("Photon Combiner", AssemblerType, new Duration(3),
                Item.List(
                    new Item("Circuit Board").Volume(1),
                    new Item("Optical Grating Crystal").Volume(1)),
                Item.List(new Item("Photon Combiner").Volume(1))));

    public ImmutableList<Item> ManufacturedItems { get; } =
        ImmutableList.Create(
            new Item("Gear"),
            new Item("Magnetic Coil"),
            new Item("Electric Motor"),
            new Item("Electromagnetic Turbine"),
            new Item("Super-magnetic Ring"),
            new Item("Circuit Board"),
            new Item("Microcrystalline Component"),
            new Item("Processor"),
            new Item("Prism"),
            new Item("Photon Combiner"),
            new Item("Plasma Exciter"),
            new Item("Particle Container"),
            new Item("Foundation"),
            new Item("Hydrogen Fuel Rod"),
            new Item("Crystal Silicon"),
            new Item("Titanium Crystal"),
            new Item("Titanium Glass"));
}
