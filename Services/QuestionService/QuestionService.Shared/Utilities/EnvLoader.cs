using DotNetEnv;

namespace QuestionService.Shared.Utilities;

public class EnvLoader
{
    public static void Load()
    {
        var baseDir = AppContext.BaseDirectory;
        var rootPath = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.Parent?.FullName;

        if (rootPath == null)
        {
            Console.WriteLine("Path is not found");
            return;
        }
        
        var envPath = Path.Combine(rootPath, "QuestionService.Interface", ".env");

        if (File.Exists(envPath))
        {
            Env.Load(envPath);
        }

        else
        {
            Console.WriteLine("Fail to load env");
        }
    }
}