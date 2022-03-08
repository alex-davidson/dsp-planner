using System.Collections.Immutable;

namespace DspPlanner.Model;

public interface IGameData
{
    /// <summary>
    /// Items which have no producing recipe.
    /// </summary>
    ImmutableHashSet<Item> BaseItems { get; }

    /// <summary>
    /// All known items.
    /// </summary>
    ImmutableHashSet<Item> AllItems { get; }

    ImmutableHashSet<Factory> Factories { get; }
    ImmutableHashSet<Recipe> Recipes { get; }
    ImmutableHashSet<Proliferator> Proliferators { get; }
}
