using System.Text.Json.Serialization;

namespace DspPlanner.Model;

[JsonSerializable(typeof(Dto.GameData))]
internal partial class ModelJsonContext : JsonSerializerContext
{
}
