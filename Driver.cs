using System.ComponentModel.DataAnnotations;

using Microsoft.Extensions.Options;

namespace SawyerCSharpConsole;

public class Driver
{
    private readonly Settings _settings;
    private readonly ILogger<Driver> _logger;

    public Driver(
        IOptions<Settings> settings,
        ILogger<Driver> logger)
    {
        _settings = settings.Value;
        _logger = logger;
    }

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
        builder.Services.AddSingleton<IValidateOptions<Settings>, ValidateDriverSettings>();
        builder.Services.AddOptions<Settings>()
            .Bind(builder.Configuration.GetRequiredSection("Driver"))
            .ValidateOnStart();
    }

    public class Settings
    {
        [Required]
        public string Demo { get; set; } = "";
    }
}

[OptionsValidator]
public partial class ValidateDriverSettings : IValidateOptions<Driver.Settings>;
