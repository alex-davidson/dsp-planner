using System.Collections.Generic;
using System.Linq;
using DspPlanner.Model;
using QuickGraph;
using QuickGraph.Algorithms.TopologicalSort;

namespace DspPlanner.Solver;

public class RecipeGraph
{
    private readonly ILookup<Item, Recipe> recipesByOutput;

    public RecipeGraph(IGameData gameData)
    {
        recipesByOutput = gameData.Recipes
            .SelectMany(r => r.Outputs.Select(o => (r, o.Item)))
            .ToLookup(x => x.Item, x => x.r);
    }

    public IReadOnlyList<Recipe> GetCandidateRecipes(ProductionRequest request)
    {
        var graph = new BidirectionalGraph<IVertex, IEdge<IVertex>>();
        var itemsNeedingProduction = request.Requests.Select(r => r.Item).ToList();
        do
        {
            var currentItems = itemsNeedingProduction.ToArray();
            itemsNeedingProduction.Clear();
            foreach (var output in currentItems)
            {
                foreach (var recipe in recipesByOutput[output])
                {
                    if (!graph.AddVertex(new RecipeVertex(recipe))) continue;
                    foreach (var input in recipe.Inputs.Select(i => i.Item))
                    {
                        if (graph.AddVertex(new ItemVertex(input)))
                        {
                            itemsNeedingProduction.Add(input);
                        }
                        graph.AddEdge(new InputEdge(input, recipe));
                    }
                    graph.AddVerticesAndEdgeRange(recipe.Outputs.Select(o => new OutputEdge(recipe, o.Item)));
                }
            }
        }
        while (itemsNeedingProduction.Any());

        var sort = new TopologicalSortAlgorithm<IVertex, IEdge<IVertex>>(graph);
        sort.Compute();
        return sort.SortedVertices.OfType<RecipeVertex>().Select(r => r.Recipe).Reverse().ToList();
    }

    private interface IVertex { }

    private record ItemVertex(Item Item) : IVertex;
    private record RecipeVertex(Recipe Recipe) : IVertex;
    private record InputEdge(Item Input, Recipe Consumer) : IEdge<IVertex>
    {
        IVertex IEdge<IVertex>.Source => new ItemVertex(Input);
        IVertex IEdge<IVertex>.Target => new RecipeVertex(Consumer);
    }
    private record OutputEdge(Recipe Producer, Item Output) : IEdge<IVertex>
    {
        IVertex IEdge<IVertex>.Source => new RecipeVertex(Producer);
        IVertex IEdge<IVertex>.Target => new ItemVertex(Output);
    }
}
