namespace DspPlanner.Model
{
    public static class Dto
    {
        public class GameData
        {
            public Recipe[]? Recipes { get; set; }
            public Factory[]? Factories { get; set; }
            public Proliferator[]? Proliferators { get; set; }

            public class Factory
            {
                public string? BuildingItem { get; set; }
                public string? TypeIdentifier { get; set; }
                public string? BaseSpeed { get; set; }
                public string[]? AvailableEffects { get; set; }
            }

            public class Proliferator
            {
                public string? Identifier { get; set; }
                public string? NumberOfSprays { get; set; }
                public string? SpeedBoost { get; set; }
                public string? OutputBoost { get; set; }
                public string? EnergyConsumptionBoost { get; set; }
            }

            public record Recipe
            {
                public string? Name { get; set; }
                public string[]? MadeByType { get; set; }
                public string? BaseDuration { get; set; }
                public ItemVolume[]? Inputs { get; set; }
                public ItemVolume[]? Outputs { get; set; }
            }

            public class ItemVolume
            {
                public string? Item { get; set; }
                public string? Volume { get; set; }
            }
        }
    }
}
