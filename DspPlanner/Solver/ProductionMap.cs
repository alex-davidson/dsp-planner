using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DspPlanner.Model;
using QuickGraph;
using Rationals;

namespace DspPlanner.Solver
{
    /// <summary>
    /// </summary>
    /// <remarks>
    /// A vertex is one of:
    /// * an input to the system, with an optional maximum availability.
    /// * the output of the system, with an optional target.
    /// * a single factory type processing a single recipe.
    ///
    /// An edge is a flow of a resource from one vertex to another, with
    /// an optional volume usually resolved later.
    ///
    /// * All volumes are specified as rationals.
    /// * Proliferator is applied to the inputs of vertices, not edges.
    ///   This is typically a simpler approach when constructing factories
    ///   too.
    /// </remarks>

    public interface IVertex { }

    public interface IFullGraphVertex { }

    public record InputVertex(Item Item, Rational? Available) : IFullGraphVertex;
    public record OutputVertex(Item Item, Rational? Target) : IFullGraphVertex;
    public record RecipeVertex(Factory Factory, Recipe Recipe, Proliferator? Proliferator) : IFullGraphVertex;

    internal record Flow(IFullGraphVertex Producer, Item Item, IFullGraphVertex Consumer) : IEdge<IFullGraphVertex>
    {
        IFullGraphVertex IEdge<IFullGraphVertex>.Source => Producer;
        IFullGraphVertex IEdge<IFullGraphVertex>.Target => Consumer;
    }

    public class ProductionRequest
    {
        public ICollection<ItemVolume> Requests { get; } = new List<ItemVolume>();
        public ICollection<ItemVolume> Inputs { get; } = new List<ItemVolume>();
        public ICollection<ProductionRule> Rules { get; } = new List<ProductionRule>();
    }

    public class ProductionRule
    {
    }

    public class ProductionMap
    {
        public ProductionMap(IReadOnlyList<Recipe> recipes, IReadOnlyList<Item> items)
        {
            Recipes = recipes;
            Items = items;
        }

        public IReadOnlyList<Recipe> Recipes { get; set; }
        public IReadOnlyList<Item> Items { get; set; }
    }

    public record ProductionInstance(Recipe Recipe, Factory Factory)
    {
        public Proliferator? Proliferator { get; set; }
        public int Count { get; set; }
    }

    public class ProductionMapBuilder
    {
        private readonly IGameData gameData;
        private readonly ILookup<ItemVolume, Recipe> recipesByOutput;

        public ProductionMapBuilder(IGameData gameData)
        {
            this.gameData = gameData;
            recipesByOutput = gameData.Recipes.SelectMany(r => r.Outputs.Select(o => (r, o))).ToLookup(x => x.o, x => x.r);
        }
    }
}
