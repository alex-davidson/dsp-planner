using System.Collections.Immutable;

namespace DspPlanner.Model.DefaultGameDataFiles;

internal class DefaultGameDataBase
{
    protected static Identifier ReplicatorType => Constants.Replicator;
    protected static Identifier MinerType => "Miner";
    protected static Identifier AssemblerType => "Assembler";
    protected static Identifier SmelterType => "Smelter";
    protected static Identifier RayReceiverType => "Ray Receiver";
    protected static Identifier EnergyExchangerType => "Energy Exchanger";
    protected static Identifier OilExtractorType => "Oil Extractor";
    protected static Identifier OilRefineryType => "Oil Refinery";
    protected static Identifier ChemicalPlantType => "Chemical Plant";
    protected static Identifier FractionatorType => "Fractionator";
    protected static Identifier WaterPumpType => "Water Pump";
    protected static Identifier OrbitalCollectorType => "Orbital Collector";
    protected static Identifier ParticleColliderType => "Particle Collider";
    protected static Identifier ResearchLabType => "Research Lab";

    protected static ImmutableArray<Identifier> ReplicatorOrMinerType =>
        Identifier.List(ReplicatorType, MinerType);
    protected static ImmutableArray<Identifier> ReplicatorOrSmelterType =>
        Identifier.List(ReplicatorType, SmelterType);
    protected static ImmutableArray<Identifier> ReplicatorOrAssemblerType =>
        Identifier.List(ReplicatorType, AssemblerType);
    protected static ImmutableArray<Identifier> ReplicatorOrResearchLabType =>
        Identifier.List(ReplicatorType, ResearchLabType);
}
