using DbUp;
using DbUp.Engine.Output;
using System.Reflection;

namespace MigrationRunner;
public class DbUpMigrationRunner
{
    public void Migrate(string connectionString)
    {
        EnsureDatabase.For.SqlDatabase(connectionString, new AutodetectUpgradeLog());

        var upgrader =
    DeployChanges.To
        .SqlDatabase(connectionString)
        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
        .LogToConsole()
        .Build();

        //var scripts = upgrader.GetScriptsToExecute();
        //foreach (var script in scripts)
        //{
        //    Log.Information(script.Name);
        //    Log.Information(script.Contents);
        //}


        var result = upgrader.PerformUpgrade();

        if (!result.Successful)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(result.Error);
            Console.ResetColor();
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Success!");
        Console.ResetColor();
    }
}
