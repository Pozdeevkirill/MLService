using Microsoft.Extensions.Configuration;

namespace MLService.Extensions
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddCustomConfigurations(this IConfigurationBuilder builder)
        {
            var solutionDirectory = TryGetSolutionDirectory();
            
            // configuration samples have the lowest priority
            builder
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

            // global configurations have mediocre priority
            if (solutionDirectory is not null)
            {
                builder
                    .AddJsonFile(Path.Combine(solutionDirectory.FullName, "envsettings.json"), optional: false, reloadOnChange: false)
                    .AddJsonFile(Path.Combine(solutionDirectory.FullName, "envsettings.development.json"), optional: false, reloadOnChange: false);
            }

            // environment specific configurations have the highest priority
            builder
                .AddJsonFile("appsettings.development.json", optional: true, reloadOnChange: false)
                .AddJsonFile("appsettings.production.json", optional: true, reloadOnChange: false);

            return builder;
        }

        private static DirectoryInfo TryGetSolutionDirectory()
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }

            return directory;
        }
    }
}
