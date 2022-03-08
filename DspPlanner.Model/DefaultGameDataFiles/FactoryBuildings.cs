using System.Collections.Immutable;

namespace DspPlanner.Model.DefaultGameDataFiles;

internal class FactoryBuildings : DefaultGameDataBase
{
    public ImmutableList<Recipe> Recipes { get; } =
        ImmutableList.Create(
            new Recipe("Mining Machine", ReplicatorOrAssemblerType, new Duration(3),
                Item.List(
                    new Item("Circuit Board").Volume(2),
                    new Item("Gear").Volume(2),
                    new Item("Iron Ingot").Volume(4),
                    new Item("Magnetic Coil").Volume(2)),
                Item.List(new Item("Mining Machine").Volume(1))),
            new Recipe("Water Pump", ReplicatorOrAssemblerType, new Duration(4),
                Item.List(
                    new Item("Circuit Board").Volume(2),
                    new Item("Electric Motor").Volume(4),
                    new Item("Iron Ingot").Volume(8),
                    new Item("Stone Brick").Volume(4)),
                Item.List(new Item("Water Pump").Volume(1))),
            new Recipe("Oil Extractor", ReplicatorOrAssemblerType, new Duration(8),
                Item.List(
                    new Item("Circuit Board").Volume(6),
                    new Item("Plasma Exciter").Volume(4),
                    new Item("Steel").Volume(12),
                    new Item("Stone Brick").Volume(12)),
                Item.List(new Item("Oil Extractor").Volume(1))),

            new Recipe("Arc Smelter", ReplicatorOrAssemblerType, new Duration(3),
                Item.List(
                    new Item("Circuit Board").Volume(4),
                    new Item("Iron Ingot").Volume(4),
                    new Item("Magnetic Coil").Volume(2),
                    new Item("Stone Brick").Volume(2)),
                Item.List(new Item("Arc Smelter").Volume(1))),
            new Recipe("Plane Smelter", ReplicatorOrAssemblerType, new Duration(5),
                Item.List(
                    new Item("Frame Material").Volume(5),
                    new Item("Unipolar Magnet").Volume(15),
                    new Item("Plane Filter").Volume(4),
                    new Item("Arc Smelter").Volume(1)),
                Item.List(new Item("Plane Smelter").Volume(1))),

            new Recipe("Assembling Machine Mk.I", ReplicatorOrAssemblerType, new Duration(2),
                Item.List(
                    new Item("Circuit Board").Volume(4),
                    new Item("Gear").Volume(8),
                    new Item("Iron Ingot").Volume(4)),
                Item.List(new Item("Assembling Machine Mk.I").Volume(1))),
            new Recipe("Assembling Machine Mk.II", ReplicatorOrAssemblerType, new Duration(3),
                Item.List(
                    new Item("Assembling Machine Mk.I").Volume(1),
                    new Item("Graphene").Volume(8),
                    new Item("Processor").Volume(4)),
                Item.List(new Item("Assembling Machine Mk.II").Volume(1))),
            new Recipe("Assembling Machine Mk.III", ReplicatorOrAssemblerType, new Duration(3),
                Item.List(
                    new Item("Assembling Machine Mk.II").Volume(1),
                    new Item("Particle Broadband").Volume(8),
                    new Item("Quantum Chip").Volume(2)),
                Item.List(new Item("Assembling Machine Mk.III").Volume(1))),

            new Recipe("Matrix Lab", ReplicatorOrAssemblerType, new Duration(3),
                Item.List(
                    new Item("Circuit Board").Volume(4),
                    new Item("Glass").Volume(4),
                    new Item("Iron Ingot").Volume(8),
                    new Item("Magnetic Coil").Volume(4)),
                Item.List(new Item("Matrix Lab").Volume(1))),

            new Recipe("Oil Refinery", ReplicatorOrAssemblerType, new Duration(6),
                Item.List(
                    new Item("Circuit Board").Volume(6),
                    new Item("Plasma Exciter").Volume(6),
                    new Item("Steel").Volume(10),
                    new Item("Stone Brick").Volume(10)),
                Item.List(new Item("Oil Refinery").Volume(1))),
            new Recipe("Chemical Plant", ReplicatorOrAssemblerType, new Duration(5),
                Item.List(
                    new Item("Circuit Board").Volume(2),
                    new Item("Glass").Volume(8),
                    new Item("Steel").Volume(8),
                    new Item("Stone Brick").Volume(8)),
                Item.List(new Item("Chemical Plant").Volume(1))),
            new Recipe("Fractionator", ReplicatorOrAssemblerType, new Duration(5),
                Item.List(
                    new Item("Glass").Volume(4),
                    new Item("Processor").Volume(1),
                    new Item("Steel").Volume(8),
                    new Item("Stone Brick").Volume(4)),
                Item.List(new Item("Fractionator").Volume(1))),

            new Recipe("Ray Receiver", ReplicatorOrAssemblerType, new Duration(8),
                Item.List(
                    new Item("Super-magnetic Ring").Volume(20),
                    new Item("Photon Combiner").Volume(10),
                    new Item("Processor").Volume(5),
                    new Item("High-purity Silicon").Volume(20),
                    new Item("Steel").Volume(20)),
                Item.List(new Item("Ray Receiver").Volume(1))),

            new Recipe("Energy Exchanger", ReplicatorOrAssemblerType, new Duration(15),
                Item.List(
                    new Item("Particle Container").Volume(8),
                    new Item("Processor").Volume(40),
                    new Item("Steel").Volume(40),
                    new Item("Titanium Alloy").Volume(40)),
                Item.List(new Item("Energy Exchanger").Volume(1))),

            new Recipe("Miniature Particle Collider", ReplicatorOrAssemblerType, new Duration(15),
                Item.List(
                    new Item("Frame Material").Volume(20),
                    new Item("Graphene").Volume(10),
                    new Item("Super-magnetic Ring").Volume(50),
                    new Item("Processor").Volume(8),
                    new Item("Titanium Alloy").Volume(20)),
                Item.List(new Item("Miniature Particle Collider").Volume(1))));

    public ImmutableList<Item> BuildingItems { get; } =
        ImmutableList.Create(
            new Item("Mining Machine"),
            new Item("Water Pump"),
            new Item("Oil Extractor"),
            new Item("Arc Smelter"),
            new Item("Plane Smelter"),
            new Item("Assembling Machine Mk.I"),
            new Item("Assembling Machine Mk.II"),
            new Item("Assembling Machine Mk.III"),
            new Item("Matrix Lab"),
            new Item("Oil Refinery"),
            new Item("Chemical Plant"),
            new Item("Fractionator"),
            new Item("Ray Receiver"),
            new Item("Energy Exchanger"),
            new Item("Miniature Particle Collider")
            );

    public ImmutableList<Factory> Factories { get; } =
        ImmutableList.Create(
            new Factory(new Item(Constants.Replicator), ReplicatorType, 1, ProliferatorEffect.None),
            new Factory(new Item("Mining Machine"), MinerType, 1, ProliferatorEffect.None),
            new Factory(new Item("Water Pump"), WaterPumpType, 1, ProliferatorEffect.None),
            new Factory(new Item("Oil Extractor"), OilExtractorType, 1, ProliferatorEffect.None),
            new Factory(new Item("Orbital Collector"), OrbitalCollectorType, 1, ProliferatorEffect.None),

            new Factory(new Item("Arc Smelter"), SmelterType, 1, ProliferatorEffect.None),
            new Factory(new Item("Plane Smelter"), SmelterType, 2, ProliferatorEffect.SpeedBoost | ProliferatorEffect.OutputBoost),

            new Factory(new Item("Assembling Machine Mk.I"), AssemblerType, new Percentage(75), ProliferatorEffect.SpeedBoost | ProliferatorEffect.OutputBoost),
            new Factory(new Item("Assembling Machine Mk.II"), AssemblerType, new Percentage(100), ProliferatorEffect.SpeedBoost | ProliferatorEffect.OutputBoost),
            new Factory(new Item("Assembling Machine Mk.III"), AssemblerType, new Percentage(150), ProliferatorEffect.SpeedBoost | ProliferatorEffect.OutputBoost),

            new Factory(new Item("Matrix Lab"), ResearchLabType, 1, ProliferatorEffect.SpeedBoost | ProliferatorEffect.OutputBoost),

            new Factory(new Item("Oil Refinery"), OilRefineryType, 1, ProliferatorEffect.SpeedBoost | ProliferatorEffect.OutputBoost),
            new Factory(new Item("Chemical Plant"), ChemicalPlantType, 1, ProliferatorEffect.SpeedBoost | ProliferatorEffect.OutputBoost),
            new Factory(new Item("Fractionator"), FractionatorType, 1, ProliferatorEffect.SpeedBoost | ProliferatorEffect.OutputBoost),

            new Factory(new Item("Ray Receiver"), RayReceiverType, 1, ProliferatorEffect.None),
            new Factory(new Item("Energy Exchanger"), EnergyExchangerType, 1, ProliferatorEffect.None),
            new Factory(new Item("Miniature Particle Collider"), ParticleColliderType, 1, ProliferatorEffect.None)
            );
}
