using System.Collections.Generic;
using System.Linq;

namespace DspPlanner.Model.Mappers;

internal class GameDataModelValidator
{
    public ICollection<ValidationFailure> Failures { get; set; } = new List<ValidationFailure>();

    public void Validate(Dto.GameData dto)
    {
        if (dto.Recipes != null)
        {
            for (var index = 0; index < dto.Recipes.Length; index++)
            {
                Validate(dto.Recipes[index], index);
            }
        }

        if (dto.Factories != null)
        {
            for (var index = 0; index < dto.Factories.Length; index++)
            {
                Validate(dto.Factories[index], index);
            }
        }

        if (dto.Proliferators != null)
        {
            for (var index = 0; index < dto.Proliferators.Length; index++)
            {
                Validate(dto.Proliferators[index], index);
            }
        }
    }

    private void Validate(Dto.GameData.Recipe recipe, int index)
    {
        var name = string.IsNullOrWhiteSpace(recipe.Name) ? $"at index {index}" : $"'{recipe.Name}'";
        if (string.IsNullOrWhiteSpace(recipe.Name))
        {
            Failures.Add(ValidationFailure.Error($"Recipe {name} does not specify {nameof(recipe.Name)}."));
        }
        if (recipe.MadeByType == null)
        {
            Failures.Add(ValidationFailure.Warning($"Recipe {name} does not specify {nameof(recipe.MadeByType)}."));
        }
        if (string.IsNullOrWhiteSpace(recipe.BaseDuration))
        {
            Failures.Add(ValidationFailure.Error($"Recipe {name} does not specify {nameof(recipe.BaseDuration)}."));
        }
        if (recipe.Inputs?.Any() == true)
        {
            if (recipe.Inputs.Any(i => string.IsNullOrWhiteSpace(i.Item)))
            {
                Failures.Add(ValidationFailure.Error($"Recipe {name}: one or more inputs do not specify {nameof(ItemVolume.Item)}."));
            }
            if (recipe.Inputs.Any(i => string.IsNullOrWhiteSpace(i.Volume)))
            {
                Failures.Add(ValidationFailure.Warning($"Recipe {name}: one or more inputs do not specify {nameof(ItemVolume.Volume)}. '1' will be assumed."));
            }
        }
        else
        {
            Failures.Add(ValidationFailure.Warning($"Recipe {name} does not specify any inputs."));
        }

        if (recipe.Outputs?.Any() == true)
        {
            if (recipe.Outputs.Any(i => string.IsNullOrWhiteSpace(i.Item)))
            {
                Failures.Add(ValidationFailure.Error($"Recipe {name}: one or more outputs do not specify {nameof(ItemVolume.Item)}."));
            }
            if (recipe.Outputs.Any(i => string.IsNullOrWhiteSpace(i.Volume)))
            {
                Failures.Add(ValidationFailure.Warning($"Recipe {name}: one or more outputs do not specify {nameof(ItemVolume.Volume)}. '1' will be assumed."));
            }
        }
        else
        {
            Failures.Add(ValidationFailure.Warning($"Recipe {name} does not specify any outputs."));
        }
    }

    private void Validate(Dto.GameData.Factory factory, int index)
    {
        var name = string.IsNullOrWhiteSpace(factory.BuildingItem) ? $"at index {index}" : $"'{factory.BuildingItem}'";
        if (string.IsNullOrWhiteSpace(factory.BuildingItem))
        {
            Failures.Add(ValidationFailure.Error($"Factory {name} does not specify {nameof(factory.BuildingItem)}."));
        }
        if (string.IsNullOrWhiteSpace(factory.TypeIdentifier))
        {
            Failures.Add(ValidationFailure.Error($"Factory {name} does not specify {nameof(factory.TypeIdentifier)}."));
        }
        if (string.IsNullOrWhiteSpace(factory.BaseSpeed))
        {
            Failures.Add(ValidationFailure.Warning($"Factory {name} does not specify {nameof(factory.BaseSpeed)}. '1' will be assumed."));
        }
    }

    private void Validate(Dto.GameData.Proliferator proliferator, int index)
    {
        var name = string.IsNullOrWhiteSpace(proliferator.Identifier) ? $"at index {index}" : $"'{proliferator.Identifier}'";
        if (string.IsNullOrWhiteSpace(proliferator.Identifier))
        {
            Failures.Add(ValidationFailure.Error($"Proliferator {name} does not specify {nameof(proliferator.Identifier)}."));
        }
        if (string.IsNullOrWhiteSpace(proliferator.NumberOfSprays))
        {
            Failures.Add(ValidationFailure.Warning($"Proliferator {name} does not specify {nameof(proliferator.NumberOfSprays)}. '0' will be assumed."));
        }
        if (string.IsNullOrWhiteSpace(proliferator.SpeedBoost))
        {
            Failures.Add(ValidationFailure.Warning($"Proliferator {name} does not specify {nameof(proliferator.SpeedBoost)}. '0' will be assumed."));
        }
        if (string.IsNullOrWhiteSpace(proliferator.OutputBoost))
        {
            Failures.Add(ValidationFailure.Warning($"Proliferator {name} does not specify {nameof(proliferator.OutputBoost)}. '0' will be assumed."));
        }
        if (string.IsNullOrWhiteSpace(proliferator.EnergyConsumptionBoost))
        {
            Failures.Add(ValidationFailure.Warning($"Proliferator {name} does not specify {nameof(proliferator.EnergyConsumptionBoost)}. '0' will be assumed."));
        }
    }
}
