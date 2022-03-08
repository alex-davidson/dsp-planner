using System.Collections.Generic;
using System.Linq;
using DspPlanner.Model;
using NUnit.Framework;

namespace DspPlanner.UnitTests.Model;

[TestFixture]
public class DefaultGameDataTests
{
    private static readonly DefaultGameData sut = new DefaultGameData();

    public static IEnumerable<Item> Items => sut.Items;
    public static IEnumerable<Item> ResourceNodes => sut.ResourceNodes;
    public static IEnumerable<Factory> Factories => sut.Factories;
    public static IEnumerable<Recipe> Recipes => sut.Recipes;
    public static IEnumerable<Proliferator> Proliferators => sut.Proliferators;

    [TestCaseSource(nameof(Factories))]
    public void FactoryIsValid(Factory factory)
    {
        Assert.That(Items, Has.Member(factory.BuildingItem),
            "Item is not declared for factory {0}", factory.BuildingItem.Identifier);
        if (factory.TypeIdentifier == Constants.Replicator) return;
        Assert.That(Recipes.SelectMany(i => i.Outputs).Select(o => o.Item), Has.Member(factory.BuildingItem),
            "No recipe exists for factory {0}", factory.BuildingItem.Identifier);
    }

    [TestCaseSource(nameof(Recipes))]
    public void RecipeIsValid(Recipe recipe)
    {
        Assert.That(Items, Is.SupersetOf(recipe.Inputs.Select(i => i.Item)
                .Except(ResourceNodes)
                .Except(sut.NaturalResourceItemsReplicatorOnly)),
            "One or more input items are not declared for recipe {0}", recipe.Name);
        Assert.That(Items, Is.SupersetOf(recipe.Outputs.Select(o => o.Item)),
            "One or more output items are not declared for recipe {0}", recipe.Name);

        Assert.That(recipe.MadeByType, Is.SubsetOf(Factories.Select(f => f.TypeIdentifier)),
            "One or more declared factory types are not available for {0}", recipe.Name);
    }

    [TestCaseSource(nameof(ResourceNodes))]
    public void ResourceNodeCanBeHarvested(Item resourceNode)
    {
        var extractionRecipes = Recipes.Where(r => r.Inputs.Any(i => i.Item == resourceNode)).ToArray();
        Assert.That(extractionRecipes, Is.Not.Empty,
            "Resource type {0} has no harvesting recipe.", resourceNode.Identifier);

        var buildingExtractionRecipes = extractionRecipes.Where(r => r.MadeByType.Any(i => i != Constants.Replicator));
        Assert.That(buildingExtractionRecipes, Is.Not.Empty,
            "Resource type {0} has no harvesting building.", resourceNode.Identifier);
    }

    [TestCaseSource(nameof(Proliferators))]
    public void ProliferatorIsValid(Proliferator proliferator)
    {
        Assert.That(Items.Select(i => i.Identifier), Has.Member(proliferator.Identifier),
            "Item is not declared for {0}", proliferator.Identifier);
        Assert.That(Recipes.SelectMany(i => i.Outputs).Select(o => o.Item.Identifier), Has.Member(proliferator.Identifier),
            "No recipe exists for {0}", proliferator.Identifier);
    }
}
