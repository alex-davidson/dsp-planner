using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DspPlanner.Model;

namespace DspPlanner;

internal class ExportDatabaseJob
{
    public Stream Output { get; set; } = Stream.Null;

    public async Task<int> Run(CancellationToken token)
    {
        var gameData = GameDataBuilder.GetDefaultGameData();
        new ModelSerialiser().Serialise(Output, gameData, true);
        return 0;
    }
}
