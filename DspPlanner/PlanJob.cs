using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DspPlanner
{
    internal class PlanJob
    {
        public string? DatabaseFilePath { get; set; }
        public string? RulesFilePath { get; set; }
        public ICollection<string> RequestFilePaths { get; } = new List<string>();

        public async Task<int> Run(CancellationToken token)
        {
            return 0;
        }
    }
}
