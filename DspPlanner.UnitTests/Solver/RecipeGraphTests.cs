using System.Collections.Generic;
using System.Linq;
using DspPlanner.Model;
using DspPlanner.Solver;
using NUnit.Framework;

namespace DspPlanner.UnitTests.Solver;

[TestFixture]
public class RecipeGraphTests
{
    private static readonly DefaultGameData gameData = new DefaultGameData();
    private readonly RecipeGraph sut = new RecipeGraph(gameData.Build());

    private Recipe FindRecipe(string name) => gameData.Recipes.Single(r => r.Name == name);

    [Test]
    public void CanResolveSimpleProduction()
    {
        var candidates = sut.GetCandidateRecipes(new ProductionRequest
        {
            Requests =
            {
                new ItemVolume(new Item("Magnetic Coil"), 50),
            },
        });

        Assert.That(candidates,
            Is.EqualTo(new [] {
                FindRecipe("Magnetic Coil"),
                FindRecipe("Copper Ingot"),
                FindRecipe("Magnet"),
                FindRecipe("Copper Ore"),
                FindRecipe("Iron Ore"),
            }));
    }

    [Test]
    public void CanResolveMultipleProduction()
    {
        var candidates = sut.GetCandidateRecipes(new ProductionRequest
        {
            Requests =
            {
                new ItemVolume(new Item("Magnetic Coil"), 50),
                new ItemVolume(new Item("Copper Ore"), 50),
            },
        });

        Assert.That(candidates,
            Is.EqualTo(new [] {
                FindRecipe("Magnetic Coil"),
                FindRecipe("Copper Ingot"),
                FindRecipe("Copper Ore"),
                FindRecipe("Magnet"),
                FindRecipe("Iron Ore"),
            }));
    }

    [Test]
    public void CanResolveCyclicProduction()
    {
        var candidates = sut.GetCandidateRecipes(new ProductionRequest
        {
            Requests =
            {
                new ItemVolume(new Item("Refined Oil"), 50),
            },
        });

        Assert.That(candidates,
            Is.EqualTo(new [] {
                FindRecipe("Magnetic Coil"),
                FindRecipe("Copper Ingot"),
                FindRecipe("Copper Ore"),
                FindRecipe("Magnet"),
                FindRecipe("Iron Ore"),
            }));
    }
}
