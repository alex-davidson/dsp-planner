using System;
using System.Collections.Immutable;
using System.Linq;
using Rationals;

/// <summary>
/// Conventions:
/// * Durations are always given as a rational number of seconds.
/// * Percentages are always given as a rational number, eg. 50% is 1/2.
/// </summary>
namespace DspPlanner.Model;

public readonly record struct Identifier(string Name)
{
    public static bool TryCreate(string name, out Identifier identifier)
    {
        identifier = new Identifier(name);
        return identifier.IsValid;
    }

    public bool IsValid => !string.IsNullOrWhiteSpace(Name);
    public static implicit operator Identifier(string name) => new Identifier(name);
    public override string ToString() => Name;

    public static ImmutableArray<Identifier> EmptyList => ImmutableArray<Identifier>.Empty;
    public static ImmutableArray<Identifier> List(params Identifier[] identifiers) => ImmutableArray.CreateRange(identifiers);
    public static implicit operator ImmutableArray<Identifier>(Identifier single) => ImmutableArray.Create(single);
}

public record Item(Identifier Identifier)
{
    public static ImmutableArray<Item> List(params Item[] identifiers) => ImmutableArray.CreateRange(identifiers);
    public static ImmutableArray<ItemVolume> List(params ItemVolume[] identifiers) => ImmutableArray.CreateRange(identifiers);
}
public record ItemVolume(Item Item, Rational Volume);
public record ItemStack(Item Item, Rational Volume, Proliferator? Proliferator);
public record Factory(Item BuildingItem, Identifier TypeIdentifier, Rational BaseSpeed, ProliferatorEffect AvailableEffects);
public record Proliferator(Identifier Identifier, int NumberOfSprays, Rational SpeedBoost, Rational OutputBoost, Rational EnergyConsumptionBoost);
public record Recipe(Identifier Name, ImmutableArray<Identifier> MadeByType, Duration BaseDuration, ImmutableArray<ItemVolume> Inputs, ImmutableArray<ItemVolume> Outputs)
{
    public virtual bool Equals(Recipe? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name.Equals(other.Name) &&
               SetEquals(MadeByType, other.MadeByType) &&
               BaseDuration.Equals(other.BaseDuration) &&
               SetEquals(Inputs, other.Inputs) &&
               SetEquals(Outputs, other.Outputs);

        bool SetEquals<T>(ImmutableArray<T> a, ImmutableArray<T> b) => !a.Except(b).Any() && !b.Except(a).Any();
    }

    public override int GetHashCode() => Name.GetHashCode();
}

[Flags]
public enum ProliferatorEffect
{
    None = 0,
    SpeedBoost = 1,
    OutputBoost = 2,
    EnergyBoost = 4,
}

public readonly record struct Percentage(decimal Percent)
{
    public static implicit operator Rational(Percentage percentage) => (Rational)percentage.Percent / 100;
}

public readonly record struct Duration(decimal Seconds)
{
    public static implicit operator Rational(Duration duration) => (Rational)duration.Seconds;
}

public static class Extensions
{
    public static ItemVolume Volume(this Item item, Rational volume) => new ItemVolume(item, volume);
    public static ItemStack Stack(this Item item, Rational volume) => new ItemStack(item, volume, null);
    public static ItemStack SprayWith(this ItemStack stack, Proliferator proliferator) => new ItemStack(stack.Item, stack.Volume, proliferator);
}
