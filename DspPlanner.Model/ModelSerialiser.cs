using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text.Json;
using DspPlanner.Model.Mappers;

namespace DspPlanner.Model
{
    public class ModelSerialiser
    {
        public void Serialise(Stream stream, IGameData data, bool indent = false)
        {
            var dto = default(GameDataModelMapper).MapToDto(data);
            DebugValidate(dto);

            var context = GetWriteContext(indent);
            JsonSerializer.Serialize(stream, dto, context.GameData);
        }

        public bool TryDeserialise(Stream stream, [MaybeNullWhen(returnValue: false)] out IGameData data, ICollection<ValidationFailure>? failures = null)
        {
            var dto = JsonSerializer.Deserialize(stream, readContext.GameData);
            if (dto == null)
            {
                failures?.Add(ValidationFailure.Error("Stream yielded a null model."));
                data = null;
                return false;
            }

            var validator = new GameDataModelValidator();
            if (failures != null) validator.Failures = failures;

            var initialCount = validator.Failures.Count;
            validator.Validate(dto);
            if (validator.Failures.Skip(initialCount).Any(f => f.IsFatal))
            {
                data = null;
                return false;
            }

            data = default(GameDataModelMapper).MapFromDto(dto);
            return true;
        }

        private static ModelJsonContext GetWriteContext(bool indent)
        {
            if (!indent) return ModelJsonContext.Default;
            return new ModelJsonContext(new JsonSerializerOptions { WriteIndented = indent });
        }

        private static readonly ModelJsonContext readContext = new ModelJsonContext(new JsonSerializerOptions { AllowTrailingCommas = true, ReadCommentHandling = JsonCommentHandling.Skip });

        [Conditional("DEBUG")]
        private static void DebugValidate(Dto.GameData dto)
        {
            var validator = new GameDataModelValidator();
            validator.Validate(dto);
            if (validator.Failures.Any()) throw new Exception("DEBUG: generated invalid DTO model from IGameData.");
        }
    }
}
