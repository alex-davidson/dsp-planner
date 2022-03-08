using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DspPlanner
{
    internal class CreateEmptyRequestJob
    {
        public Stream Output { get; set; } = Stream.Null;

        public async Task<int> Run(CancellationToken token)
        {
            return 0;
        }
    }
}
