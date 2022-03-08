using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace DspPlanner.Model.Mappers;

internal struct GameDataModelMapper
{
    public Dto.GameData MapToDto(IGameData gameData) =>
        new Dto.GameData
        {
            Recipes = gameData.Recipes.Select(default(RecipeMapper).MapToDto).ToArray(),
            Factories = gameData.Factories.Select(default(FactoryMapper).MapToDto).ToArray(),
            Proliferators = gameData.Proliferators.Select(default(ProliferatorMapper).MapToDto).ToArray(),
        };

    public IGameData MapFromDto(Dto.GameData dto)
    {
        var builder = new GameDataBuilder();
        foreach (var recipe in MapListFrom(dto.Recipes?.Select(default(RecipeMapper).MapFromDto)))
        {
            builder.Recipes.Add(recipe);
        }
        foreach (var factory in MapListFrom(dto.Factories?.Select(default(FactoryMapper).MapFromDto)))
        {
            builder.Factories.Add(factory);
        }
        foreach (var proliferator in MapListFrom(dto.Proliferators?.Select(default(ProliferatorMapper).MapFromDto)))
        {
            builder.Proliferators.Add(proliferator);
        }
        return builder.Build();
    }

    private static ImmutableArray<T> MapListFrom<T>(IEnumerable<T>? list)
    {
        if (list == null) return ImmutableArray<T>.Empty;
        return list.ToImmutableArray();
    }

    private struct RecipeMapper
    {
        public Dto.GameData.Recipe MapToDto(Recipe recipe) =>
            new Dto.GameData.Recipe
            {
                Name = recipe.Name.Name,
                MadeByType = recipe.MadeByType.Select(m => m.Name).ToArray(),
                BaseDuration = default(NumberMapper).MapToDecimalDto(recipe.BaseDuration),
                Inputs = recipe.Inputs.Select(default(ItemVolumeMapper).MapToDto).ToArray(),
                Outputs = recipe.Outputs.Select(default(ItemVolumeMapper).MapToDto).ToArray(),
            };

        public Recipe MapFromDto(Dto.GameData.Recipe dto) =>
            new Recipe(
                Name: dto.Name!,
                MadeByType: MapListFrom(dto.MadeByType?.Select(i => new Identifier(i))),
                BaseDuration: default(NumberMapper).MapDurationFromDto(dto.BaseDuration!),
                Inputs: MapListFrom(dto.Inputs?.Select(default(ItemVolumeMapper).MapFromDto)),
                Outputs: MapListFrom(dto.Outputs?.Select(default(ItemVolumeMapper).MapFromDto)));
    }

    private struct FactoryMapper
    {
        public Dto.GameData.Factory MapToDto(Factory factory) =>
            new Dto.GameData.Factory
            {
                BuildingItem = default(ItemMapper).MapToDto(factory.BuildingItem),
                TypeIdentifier = factory.TypeIdentifier.Name,
                BaseSpeed = default(NumberMapper).MapToPercentageDto(factory.BaseSpeed),
                AvailableEffects = default(ProliferatorEffectMapper).MapToDto(factory.AvailableEffects),
            };

        public Factory MapFromDto(Dto.GameData.Factory dto) =>
            new Factory(
                BuildingItem: default(ItemMapper).MapFromDto(dto.BuildingItem!),
                TypeIdentifier: dto.TypeIdentifier!,
                BaseSpeed: default(NumberMapper).MapFromDto(dto.BaseSpeed, 1),
                AvailableEffects: default(ProliferatorEffectMapper).MapFromDto(dto.AvailableEffects));
    }

    private struct ProliferatorMapper
    {
        public Dto.GameData.Proliferator MapToDto(Proliferator proliferator) =>
            new Dto.GameData.Proliferator
            {
                Identifier = proliferator.Identifier.Name,
                NumberOfSprays = default(NumberMapper).MapToDecimalDto(proliferator.NumberOfSprays),
                SpeedBoost = default(NumberMapper).MapToPercentageDto(proliferator.SpeedBoost),
                OutputBoost = default(NumberMapper).MapToPercentageDto(proliferator.OutputBoost),
                EnergyConsumptionBoost = default(NumberMapper).MapToPercentageDto(proliferator.EnergyConsumptionBoost),
            };

        public Proliferator MapFromDto(Dto.GameData.Proliferator dto) =>
            new Proliferator(
                Identifier: dto.Identifier!,
                NumberOfSprays: (int)default(NumberMapper).MapFromDto(dto.NumberOfSprays, 0),
                SpeedBoost: default(NumberMapper).MapFromDto(dto.SpeedBoost, 0),
                OutputBoost: default(NumberMapper).MapFromDto(dto.OutputBoost, 0),
                EnergyConsumptionBoost: default(NumberMapper).MapFromDto(dto.EnergyConsumptionBoost, 0));
    }

    private struct ItemMapper
    {
        public string MapToDto(Item item) => item.Identifier.Name;
        public Item MapFromDto(string dto) => new Item(dto);
    }

    private struct ItemVolumeMapper
    {
        public Dto.GameData.ItemVolume MapToDto(ItemVolume itemVolume) =>
            new Dto.GameData.ItemVolume
            {
                Item = default(ItemMapper).MapToDto(itemVolume.Item),
                Volume = default(NumberMapper).MapToDecimalDto(itemVolume.Volume),
            };

        public ItemVolume MapFromDto(Dto.GameData.ItemVolume dto) =>
            new ItemVolume(
                Item: default(ItemMapper).MapFromDto(dto.Item!),
                Volume: default(NumberMapper).MapFromDto(dto.Volume, 1));
    }

    private struct ProliferatorEffectMapper
    {
        public string[] MapToDto(ProliferatorEffect effect)
        {
            if (effect == ProliferatorEffect.None) return Array.Empty<string>();
            var values = new List<string>();
            foreach (var flag in Enum.GetValues<ProliferatorEffect>())
            {
                if (effect.HasFlag(flag)) values.Add(flag.ToString());
            }
            return values.ToArray();
        }

        public ProliferatorEffect MapFromDto(string[]? dto)
        {
            if (dto == null) return ProliferatorEffect.None;
            if (dto.Length == 0) return ProliferatorEffect.None;

            var value = default(ProliferatorEffect);
            foreach (var flag in Enum.GetValues<ProliferatorEffect>())
            {
                if (dto.Contains(flag.ToString())) value |= flag;
            }
            return value;
        }
    }
}
