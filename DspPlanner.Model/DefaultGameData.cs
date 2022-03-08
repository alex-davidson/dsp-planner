using System.Collections.Immutable;
using System.Linq;
using DspPlanner.Model.DefaultGameDataFiles;

namespace DspPlanner.Model;

internal class DefaultGameData : DefaultGameDataBase
{
    private static readonly NaturalResourcesAndHarvesting naturalResourcesAndHarvesting = new NaturalResourcesAndHarvesting();
    private static readonly Smelting smelting = new Smelting();
    private static readonly ChemicalProcessing chemicalProcessing = new ChemicalProcessing();
    private static readonly BasicManufacturing basicManufacturing = new BasicManufacturing();
    private static readonly AdvancedManufacturing advancedManufacturing = new AdvancedManufacturing();
    private static readonly ResearchMatrices researchMatrices = new ResearchMatrices();
    private static readonly PowerBuildings powerBuildings = new PowerBuildings();
    private static readonly LogisticsBuildings logisticsBuildings = new LogisticsBuildings();
    private static readonly FactoryBuildings factoryBuildings = new FactoryBuildings();
    private static readonly OtherBuildings otherBuildings = new OtherBuildings();
    private static readonly Proliferation proliferation = new Proliferation();

    public ImmutableList<Item> NaturalResourceItemsReplicatorOnly => naturalResourcesAndHarvesting.NaturalResourceItemsReplicatorOnly;

    public ImmutableList<Item> ResourceNodes => naturalResourcesAndHarvesting.ResourceNodes;

    public ImmutableList<Item> Items { get; } =
        ImmutableList.Create(new Item(Constants.Replicator))
            .Concat(naturalResourcesAndHarvesting.ResourceNodes)
            .Concat(naturalResourcesAndHarvesting.NaturalResourceItems)
            .Concat(smelting.SmeltedItems)
            .Concat(basicManufacturing.ManufacturedItems)
            .Concat(advancedManufacturing.ManufacturedItems)
            .Concat(chemicalProcessing.ChemicalItems)
            .Concat(researchMatrices.Items)
            .Concat(powerBuildings.BuildingItems)
            .Concat(logisticsBuildings.BuildingItems)
            .Concat(factoryBuildings.BuildingItems)
            .Concat(otherBuildings.BuildingItems)
            .Concat(proliferation.ProliferatorItems)
            .ToImmutableList();

    public ImmutableList<Factory> Factories { get; } =
        ImmutableList.Create<Factory>()
            .Concat(factoryBuildings.Factories)
            .ToImmutableList();

    public ImmutableList<Recipe> Recipes { get; } =
        ImmutableList.Create<Recipe>()
            .Concat(naturalResourcesAndHarvesting.Recipes)
            .Concat(smelting.Recipes)
            .Concat(basicManufacturing.Recipes)
            .Concat(advancedManufacturing.Recipes)
            .Concat(chemicalProcessing.Recipes)
            .Concat(researchMatrices.Recipes)
            .Concat(powerBuildings.Recipes)
            .Concat(logisticsBuildings.Recipes)
            .Concat(factoryBuildings.Recipes)
            .Concat(otherBuildings.Recipes)
            .Concat(proliferation.Recipes)
            .ToImmutableList();

    public ImmutableList<Proliferator> Proliferators { get; } = proliferation.Proliferators;

    public IGameData Build()
    {
        var builder = new GameDataBuilder();
        foreach (var recipe in Recipes) builder.Recipes.Add(recipe);
        foreach (var factory in Factories) builder.Factories.Add(factory);
        foreach (var proliferator in Proliferators) builder.Proliferators.Add(proliferator);
        return builder.Build();
    }
}
