using System.Collections.Immutable;
using Rationals;

namespace DspPlanner.Model.DefaultGameDataFiles;

internal class AdvancedManufacturing : DefaultGameDataBase
{
    public ImmutableList<Recipe> Recipes { get; } =
        ImmutableList.Create(
            new Recipe("Thruster", ReplicatorOrAssemblerType, new Duration(4),
                Item.List(
                    new Item("Copper Ingot").Volume(3),
                    new Item("Steel").Volume(2)),
                Item.List(new Item("Thruster").Volume(1))),
            new Recipe("Logistics Drone", ReplicatorOrAssemblerType, new Duration(4),
                Item.List(
                    new Item("Thruster").Volume(2),
                    new Item("Iron Ingot").Volume(5),
                    new Item("Processor").Volume(2)),
                Item.List(new Item("Logistics Drone").Volume(1))),

            new Recipe("Reinforced Thruster", ReplicatorOrAssemblerType, new Duration(6),
                Item.List(
                    new Item("Electromagnetic Turbine").Volume(5),
                    new Item("Titanium Alloy").Volume(5)),
                Item.List(new Item("Reinforced Thruster").Volume(1))),
            new Recipe("Logistics Vessel", ReplicatorOrAssemblerType, new Duration(6),
                Item.List(
                    new Item("Reinforced Thruster").Volume(2),
                    new Item("Processor").Volume(10),
                    new Item("Titanium Alloy").Volume(10)),
                Item.List(new Item("Logistics Vessel").Volume(1))),

            new Recipe("Particle Broadband", ReplicatorOrAssemblerType, new Duration(8),
                Item.List(
                    new Item("Carbon Nanotube").Volume(2),
                    new Item("Plastic").Volume(1),
                    new Item("Crystal Silicon").Volume(2)),
                Item.List(new Item("Particle Broadband").Volume(1))),

            new Recipe("Casimir Crystal", ReplicatorOrAssemblerType, new Duration(4),
                Item.List(
                    new Item("Graphene").Volume(2),
                    new Item("Hydrogen").Volume(12),
                    new Item("Titanium Crystal").Volume(1)),
                Item.List(new Item("Casimir Crystal").Volume(1))),
            new Recipe("Casimir Crystal", AssemblerType, new Duration(4),
                Item.List(
                    new Item("Graphene").Volume(2),
                    new Item("Hydrogen").Volume(12),
                    new Item("Optical Grating Crystal").Volume(6)),
                Item.List(new Item("Casimir Crystal").Volume(1))),
            new Recipe("Plane Filter", ReplicatorOrAssemblerType, new Duration(12),
                Item.List(
                    new Item("Casimir Crystal").Volume(1),
                    new Item("Titanium Glass").Volume(2)),
                Item.List(new Item("Plane Filter").Volume(1))),
            new Recipe("Quantum Chip", ReplicatorOrAssemblerType, new Duration(8),
                Item.List(
                    new Item("Plane Filter").Volume(2),
                    new Item("Processor").Volume(2)),
                Item.List(new Item("Quantum Chip").Volume(1))),

            new Recipe("Deuterium", FractionatorType, new Duration(4),  // Conservative estimate.
                Item.List(new Item("Hydrogen").Volume(1)),
                Item.List(new Item("Deuterium").Volume(1))),
            new Recipe("Deuterium", ParticleColliderType, new Duration(5),
                Item.List(new Item("Hydrogen").Volume(10)),
                Item.List(new Item("Deuterium").Volume(5))),
            new Recipe("Deuteron Fuel Rod", ReplicatorOrAssemblerType, new Duration(6),
                Item.List(
                    new Item("Hydrogen").Volume(10),
                    new Item("Super-magnetic Ring").Volume(1),
                    new Item("Titanium Alloy").Volume(1)),
                Item.List(new Item("Deuteron Fuel Rod").Volume(2))),

            new Recipe("Strange Matter", ParticleColliderType, new Duration(8),
                Item.List(
                    new Item("Deuterium").Volume(10),
                    new Item("Iron Ingot").Volume(2),
                    new Item("Particle Container").Volume(2)),
                Item.List(new Item("Strange Matter").Volume(1))),
            new Recipe("Graviton Lens", ReplicatorOrAssemblerType, new Duration(6),
                Item.List(
                    new Item("Diamond").Volume(4),
                    new Item("Strange Matter").Volume(1)),
                Item.List(new Item("Graviton Lens").Volume(1))),

            new Recipe("Solar Sail", ReplicatorOrAssemblerType, new Duration(4),
                Item.List(
                    new Item("Graphene").Volume(1),
                    new Item("Photon Combiner").Volume(1)),
                Item.List(new Item("Solar Sail").Volume(2))),
            new Recipe("Frame Material", ReplicatorOrAssemblerType, new Duration(6),
                Item.List(
                    new Item("Carbon Nanotube").Volume(4),
                    new Item("High-purity Silicon").Volume(1),
                    new Item("Titanium Alloy").Volume(1)),
                Item.List(new Item("Frame Material").Volume(1))),
            new Recipe("Dyson Sphere Component", ReplicatorOrAssemblerType, new Duration(8),
                Item.List(
                    new Item("Frame Material").Volume(3),
                    new Item("Processor").Volume(3),
                    new Item("Solar Sail").Volume(3)),
                Item.List(new Item("Dyson Sphere Component").Volume(1))),
            new Recipe("Small Carrier Rocket", ReplicatorOrAssemblerType, new Duration(8),
                Item.List(
                    new Item("Deuteron Fuel Rod").Volume(2),
                    new Item("Dyson Sphere Component").Volume(2),
                    new Item("Quantum Chip").Volume(2)),
                Item.List(new Item("Small Carrier Rocket").Volume(1))),

            new Recipe("Annihilation Constraint Sphere", ReplicatorOrAssemblerType, new Duration(20),
                Item.List(
                    new Item("Particle Container").Volume(1),
                    new Item("Processor").Volume(1)),
                Item.List(new Item("Annihilation Constraint Sphere").Volume(1))),

            new Recipe("Antimatter", ParticleColliderType, new Duration(2),
                Item.List(
                    new Item("Critical Photon").Volume(2)),
                Item.List(
                    new Item("Hydrogen").Volume(2),
                    new Item("Antimatter").Volume(2))),
            new Recipe("Antimatter Fuel Rod", ReplicatorOrAssemblerType, new Duration(6),
                Item.List(
                    new Item("Antimatter").Volume(6),
                    new Item("Annihilation Constraint Sphere").Volume(1),
                    new Item("Hydrogen").Volume(6),
                    new Item("Super-magnetic Ring").Volume(1),
                    new Item("Titanium Alloy").Volume(1)),
                Item.List(new Item("Antimatter Fuel Rod").Volume(1))),

            new Recipe("Space Warper", ReplicatorOrAssemblerType, new Duration(10),
                Item.List(new Item("Graviton Lens").Volume(1)),
                Item.List(new Item("Space Warper").Volume(1))),
            new Recipe("Space Warper", ReplicatorOrAssemblerType, new Duration(10),
                Item.List(new Item("Gravity Matrix").Volume(1)),
                Item.List(new Item("Space Warper").Volume(8))));

    public ImmutableList<Item> ManufacturedItems { get; } =
        ImmutableList.Create(
            new Item("Particle Broadband"),
            new Item("Casimir Crystal"),
            new Item("Plane Filter"),
            new Item("Strange Matter"),
            new Item("Deuteron Fuel Rod"),
            new Item("Antimatter"),
            new Item("Antimatter Fuel Rod"),
            new Item("Frame Material"),
            new Item("Graviton Lens"),
            new Item("Solar Sail"),
            new Item("Dyson Sphere Component"),
            new Item("Small Carrier Rocket"),
            new Item("Quantum Chip"),
            new Item("Annihilation Constraint Sphere"),
            new Item("Thruster"),
            new Item("Logistics Drone"),
            new Item("Reinforced Thruster"),
            new Item("Logistics Vessel"),
            new Item("Space Warper"));
}
