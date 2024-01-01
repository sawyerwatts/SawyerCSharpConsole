using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace SawyerCSharpConsole;

public class Driver(
    IOptions<Driver.Settings> settings,
    ILogger<Driver> logger)
{
    public Task RunAsync(
        CancellationToken cancellationToken)
    {
        // TODO: start coding here
        return Task.CompletedTask;
    }

    public static void RegisterTo(
        IHostApplicationBuilder builder)
    {
        builder.Services.AddTransient<Driver>();
        builder.Services.AddOptions<Settings>()
            .Bind(builder.Configuration.GetRequiredSection("Driver"))
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }

    public class Settings
    {
        [Required]
        public string Demo { get; set; } = "";
    }
}