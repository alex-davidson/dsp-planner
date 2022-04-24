﻿using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using DspPlanner.Model;
using DspPlanner.Model.Mappers;
using NUnit.Framework;

namespace DspPlanner.UnitTests
{
    [TestFixture]
    public class ExportFormatTests
    {
        [Test]
        public void CanRoundtripDefaultDatabase()
        {
            var gameData = new DefaultGameData().Build();
            var ms = new MemoryStream();
            var serialiser = new ModelSerialiser();
            serialiser.Serialise(ms, gameData);
            ms.Position = 0;

            var failures = new List<ValidationFailure>();
            var result = serialiser.TryDeserialise(ms, out var roundtripped, failures);
            Assert.That(failures, Is.Empty);
            if (!result)
            {
                Assert.Fail("Deserialisation failed.");
                return;
            }

            if (new GameDataEqualityComparer().Equals(roundtripped, gameData)) return;

            var diff = new GameDataDifferenceDescriber
            {
                Left = "Original",
                Right = "Roundtripped",
            };
            var differences = diff.Describe(gameData, roundtripped!);
            Assert.That(differences, Is.Not.Empty, "Instances compare unequal but no differences were found.");
            Assert.Fail(differences);
        }

        [Test]
        public void DeserialisingInvalidRecipeDoesNotThrow() =>
            TestDeserialisingInvalidDoesNotThrow(new Dto.GameData
            {
                Recipes = new []
                {
                    new Dto.GameData.Recipe
                    {
                        Inputs = new [] { new Dto.GameData.ItemVolume() },
                    },
                },
            });

        [Test]
        public void DeserialisingInvalidFactoryDoesNotThrow() =>
            TestDeserialisingInvalidDoesNotThrow(new Dto.GameData
            {
                Factories = new []
                {
                    new Dto.GameData.Factory(),
                },
            });

        [Test]
        public void DeserialisingInvalidProliferatorDoesNotThrow() =>
            TestDeserialisingInvalidDoesNotThrow(new Dto.GameData
            {
                Proliferators = new []
                {
                    new Dto.GameData.Proliferator(),
                },
            });

        private void TestDeserialisingInvalidDoesNotThrow(Dto.GameData invalid)
        {
            var ms = new MemoryStream();
            JsonSerializer.Serialize(ms, invalid, ModelJsonContext.Default.GameData);
            ms.Position = 0;

            var failures = new List<ValidationFailure>();
            var result = new ModelSerialiser().TryDeserialise(ms, out _, failures);
            Assert.That(result, Is.False);
            Assert.That(failures, Is.Not.Empty);
        }

        [Test]
        public void DeserialisingMinimalRecipeDoesNotThrow() =>
            TestDeserialisingMinimalDoesNotThrow(new Dto.GameData
            {
                Recipes = new []
                {
                    new Dto.GameData.Recipe { Name = "Test", MadeByType = new [] { "TestType" }, BaseDuration = "1+1/2" },
                },
            });

        [Test]
        public void DeserialisingMinimalFactoryDoesNotThrow() =>
            TestDeserialisingMinimalDoesNotThrow(new Dto.GameData
            {
                Factories = new []
                {
                    new Dto.GameData.Factory { BuildingItem = "TestFactory", TypeIdentifier = "TestType", },
                },
            });

        [Test]
        public void DeserialisingMinimalProliferatorDoesNotThrow() =>
            TestDeserialisingMinimalDoesNotThrow(new Dto.GameData
            {
                Proliferators = new []
                {
                    new Dto.GameData.Proliferator { Identifier = "Test" },
                },
            });

        private void TestDeserialisingMinimalDoesNotThrow(Dto.GameData invalid)
        {
            var ms = new MemoryStream();
            JsonSerializer.Serialize(ms, invalid, ModelJsonContext.Default.GameData);
            ms.Position = 0;

            var failures = new List<ValidationFailure>();
            var result = new ModelSerialiser().TryDeserialise(ms, out _, failures);
            Assert.That(result, Is.True);
            Assert.That(failures, Is.Not.Empty);
        }
    }
}
