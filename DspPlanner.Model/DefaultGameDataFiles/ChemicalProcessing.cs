using System.Collections.Immutable;

namespace DspPlanner.Model.DefaultGameDataFiles;

internal class ChemicalProcessing : DefaultGameDataBase
{
    public ImmutableList<Recipe> Recipes { get; } =
        ImmutableList.Create(
            new Recipe("Refined Oil", OilRefineryType, new Duration(4),
                Item.List(new Item("Crude Oil").Volume(2)),
                Item.List(
                    new Item("Hydrogen").Volume(1),
                    new Item("Refined Oil").Volume(2))),
            new Recipe("X-Ray Cracking", OilRefineryType, new Duration(4),
                Item.List(
                    new Item("Hydrogen").Volume(2),
                    new Item("Refined Oil").Volume(1)),
                Item.List(
                    new Item("Energetic Graphite").Volume(1),
                    new Item("Refined Oil").Volume(2))),

            new Recipe("Sulfuric Acid", ChemicalPlantType, new Duration(6),
                Item.List(
                    new Item("Refined Oil").Volume(6),
                    new Item("Stone").Volume(8),
                    new Item("Water").Volume(4)),
                Item.List(
                    new Item("Sulfuric Acid").Volume(4))),

            new Recipe("Graphene", ChemicalPlantType, new Duration(3),
                Item.List(
                    new Item("Energetic Graphite").Volume(3),
                    new Item("Sulfuric Acid").Volume(1)),
                Item.List(
                    new Item("Graphene").Volume(2))),
            new Recipe("Graphene", ChemicalPlantType, new Duration(2),
                Item.List(new Item("Fire Ice").Volume(2)),
                Item.List(
                    new Item("Graphene").Volume(2),
                    new Item("Hydrogen").Volume(1))),

            new Recipe("Plastic", ChemicalPlantType, new Duration(3),
                Item.List(
                    new Item("Energetic Graphite").Volume(1),
                    new Item("Refined Oil").Volume(2)),
                Item.List(
                    new Item("Plastic").Volume(1))),

            new Recipe("Organic Crystal", ChemicalPlantType, new Duration(6),
                Item.List(
                    new Item("Plastic").Volume(2),
                    new Item("Refined Oil").Volume(1),
                    new Item("Water").Volume(1)),
                Item.List(
                    new Item("Organic Crystal").Volume(1))),
            new Recipe("Organic Crystal", AssemblerType, new Duration(6),
                Item.List(
                    new Item("Plant Fuel").Volume(30),
                    new Item("Log").Volume(20),
                    new Item("Water").Volume(10)),
                Item.List(
                    new Item("Organic Crystal").Volume(1))),

            new Recipe("Carbon Nanotube", ChemicalPlantType, new Duration(4),
                Item.List(
                    new Item("Graphene").Volume(3),
                    new Item("Titanium Ingot").Volume(1)),
                Item.List(
                    new Item("Carbon Nanotube").Volume(2))),
            new Recipe("Carbon Nanotube", ChemicalPlantType, new Duration(4),
                Item.List(
                    new Item("Spiniform stalagmite Crystal").Volume(2)),
                Item.List(
                    new Item("Carbon Nanotube").Volume(2))));

    public ImmutableList<Item> ChemicalItems { get; } =
        ImmutableList.Create(
            new Item("Refined Oil"),
            new Item("Sulfuric Acid"),
            new Item("Graphene"),
            new Item("Plastic"),
            new Item("Organic Crystal"),
            new Item("Carbon Nanotube"));
}
