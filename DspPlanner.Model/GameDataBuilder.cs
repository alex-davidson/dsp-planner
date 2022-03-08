using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace DspPlanner.Model;

public class GameDataBuilder
{
    public static IGameData GetDefaultGameData() => new DefaultGameData().Build();

    public ICollection<Factory> Factories { get; } = new List<Factory>();
    public ICollection<Recipe> Recipes { get; } = new List<Recipe>();
    public ICollection<Proliferator> Proliferators { get; } = new List<Proliferator>();

    public IGameData Build() => new GameData(this);

    private class GameData : IGameData
    {
        internal GameData(GameDataBuilder builder)
        {
            Factories = builder.Factories.ToImmutableHashSet();
            Recipes = builder.Recipes.ToImmutableHashSet();
            Proliferators = builder.Proliferators.ToImmutableHashSet();
            AllItems = Union(
                Factories.Select(f => f.BuildingItem),
                Recipes.SelectMany(r => r.Inputs).Select(r => r.Item),
                Recipes.SelectMany(r => r.Outputs).Select(r => r.Item));
            BaseItems = AllItems
                .Except(Recipes.SelectMany(r => r.Outputs).Select(r => r.Item))
                .ToImmutableHashSet();
        }

        private static ImmutableHashSet<Item> Union(params IEnumerable<Item>[] sources)
        {
            var set = ImmutableHashSet.CreateBuilder<Item>();
            foreach (var source in sources) set.UnionWith(source);
            return set.ToImmutable();
        }

        /// <summary>
        /// Items which have no producing recipe.
        /// </summary>
        public ImmutableHashSet<Item> BaseItems { get; init; }
        /// <summary>
        /// All known items.
        /// </summary>
        public ImmutableHashSet<Item> AllItems { get; init; }

        public ImmutableHashSet<Recipe> Recipes { get; init; }
        public ImmutableHashSet<Factory> Factories { get; init; }
        public ImmutableHashSet<Proliferator> Proliferators { get; init; }
    }
}
