using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;

namespace DspPlanner
{
    internal class Program
    {
        internal static async Task<int> Main(string[] args)
        {
            var app = new CommandLineApplication();
            app.Name = Assembly.GetExecutingAssembly().GetName().Name;
            app.Description = "Collates results of document content extraction in a variety of ways.";

            app.HelpOption("-?|-h|--help", true);

            app.Command("plan", c =>
            {
                c.Description = "Write to STDOUT a full description of all factories, etc required to meet the specified production requests.";

                var dbOption = c.Option("--db <db.json>", "JSON file containing recipes, etc from the game. The internal file will be used if not specified.", CommandOptionType.SingleValue);
                var rulesOption = c.Option("--rules <rules.json>", "JSON file containing production rules, ie. which recipes to favour.", CommandOptionType.SingleValue);
                var requestOption = c.Argument("<request.json> ...", "One or more JSON files containing production requests.", true);

                c.OnExecuteAsync(async token => {
                    var job = new PlanJob
                    {
                        DatabaseFilePath = dbOption.Value(),
                        RulesFilePath = rulesOption.Value(),
                    };
                    foreach (var path in requestOption.Values)
                    {
                        if (!string.IsNullOrEmpty(path)) job.RequestFilePaths.Add(path);
                    }
                    return await job.Run(token);
                });
            });

            app.Command("export-db", c =>
            {
                c.Description = "Write out the application's internal database of recipes, etc as JSON. This is the default database used by other commands if --db is not specified.";

                var targetOption = c.Argument("<db.json>", "Path of the file which should be written. Use - to specify STDOUT.").IsRequired();

                c.OnExecuteAsync(async token => {
                    using (var writer = OpenOutput(targetOption.Value!, false))
                    {
                        var job = new ExportDatabaseJob
                        {
                            Output = writer,
                        };
                        return await job.Run(token);
                    }
                });
            });
            app.Command("create-empty-rules", c =>
            {
                c.Description = "Write out an empty production rules file as JSON. This may be redirected to a file, edited manually and provided to other commands using --rules.";

                var targetOption = c.Argument("<rules.json>", "Path of the file which should be written. Use - to specify STDOUT.").IsRequired();

                c.OnExecuteAsync(async token => {
                    using (var writer = OpenOutput(targetOption.Value!, false))
                    {
                        var job = new CreateEmptyRulesJob
                        {
                            Output = writer,
                        };
                        return await job.Run(token);
                    }
                });
            });
            app.Command("create-empty-request", c =>
            {
                c.Description = "Write out an empty production request file as JSON.";

                var targetOption = c.Argument("<request.json>", "Path of the file which should be written. Use - to specify STDOUT.").IsRequired();

                c.OnExecuteAsync(async token => {
                    using (var writer = OpenOutput(targetOption.Value!, false))
                    {
                        var job = new CreateEmptyRequestJob
                        {
                            Output = writer,
                        };
                        return await job.Run(token);
                    }
                });
            });

            app.OnExecute(() =>
            {
                app.Error.WriteLine("Specify a command.");
                app.ShowHelp();
                return 1;
            });

            return await app.ExecuteAsync(args);
        }

        private static Stream OpenOutput(string filePath, bool overwrite = false)
        {
            if (filePath == "-") return Console.OpenStandardOutput();
            var fullFilePath = Path.GetFullPath(filePath);
            return new FileStream(fullFilePath, new FileStreamOptions
            {
                Access = FileAccess.Write,
                Mode = overwrite ? FileMode.Create : FileMode.CreateNew,
                Share = FileShare.None,
            });
        }
    }
}
