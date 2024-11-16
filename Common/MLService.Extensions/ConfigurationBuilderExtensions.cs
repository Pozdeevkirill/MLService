using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MLService.Infrastructure.Models.Settings;
using Serilog;

namespace MLService.Extensions
{
    public static class ConfigurationBuilderExtensions
    {
        private readonly static string ErrorEmptyPathMessage = "Ошибка кофигурации приложения! Не удалось найти файл конфигурации.";

        public static IHostApplicationBuilder AddCustomConfigurations(this IHostApplicationBuilder builder)
        {
            builder.Configuration.AddCustomConfigurationFile();
            builder.Configuration.ConfigureSettingsClass();
            return builder;
        } 

        public static IHostApplicationBuilder AddLoggerConfiguration(this IHostApplicationBuilder builder)
        {
            builder.Services.AddSerilog((services, lc) => lc
                .ReadFrom.Configuration(builder.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext());
            return builder;
        }

        public static IConfigurationBuilder AddCustomConfigurationFile(this IConfigurationBuilder builder)
        {
            DirectoryInfo solutionDirectory;
            
            if (File.Exists("/.dockerenv"))//Запущено через докер
                solutionDirectory = TryGetSolutionDirectoryDocker();
            else //Запущено через что угодно, но не докер
                solutionDirectory = TryGetSolutionDirectory();

            if (solutionDirectory is null || solutionDirectory.FullName == string.Empty)
                throw new Exception(ErrorEmptyPathMessage);

           try
           {
                builder
                   .AddYamlFile(Path.Combine(solutionDirectory.FullName, "commonsettings.yaml"), optional: false, reloadOnChange: false)
                   .AddYamlFile(Path.Combine(solutionDirectory.FullName, "commonsettings.development.yaml"), optional: false, reloadOnChange: false)
                   .AddJsonFile(Path.Combine(solutionDirectory.FullName, "serilogConfig.json"), optional: false, reloadOnChange: false);
           }
           catch(Exception ex) {
               throw new Exception(ErrorEmptyPathMessage + " Exception: " + ex.Message);
           }

           return builder;
        }

        public static IConfigurationManager ConfigureSettingsClass(this IConfigurationManager configuration)
        {
            configuration.GetSection("RabbitMQ").Bind(AppSettings.RabbitMq);
            configuration.GetSection("MassTransit").Bind(AppSettings.MassTransit);

            configuration.GetSection("MLService").Bind(AppSettings.MLService);
            configuration.GetSection("MLService").GetSection("Endpoints").Bind(AppSettings.MLService.Endpoints);

            return configuration;
        }

        #region Private
        private static DirectoryInfo TryGetSolutionDirectory()
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }

            return directory;
        }

        private static DirectoryInfo TryGetSolutionDirectoryDocker()
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());

            return directory;
        }
        #endregion
    }
}
