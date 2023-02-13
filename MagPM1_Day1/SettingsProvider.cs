using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace MagPM1_Day1;

internal class SettingsProvider
{
    private IConfigurationRoot _config;
    private readonly string _settingFileName;

    public SettingsProvider(string settingsFileName)
    {
        _settingFileName = settingsFileName;


    }
    public Settings Read()
    {
        _config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile(_settingFileName)
            //.AddJsonFile("appsettings2.json", optional: true)
            //.AddXmlFile("appsettings.xml", optional: true)
            //.AddIniFile("appsettings.ini", optional: true)
            .Build();

        var settings = _config.Get<Settings>();
        if (settings is null) throw new Exception();

        return settings;
    }

    public void Update(Settings settings)
    {
        var jsonWriteOptions = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        var newJson = JsonSerializer.Serialize(settings, jsonWriteOptions);

        var appSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _settingFileName);
        File.WriteAllText(appSettingsPath, newJson);
    }
}
