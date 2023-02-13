using Microsoft.Extensions.Configuration;

namespace MagPM1_Day1;

internal class Project
{
    private static Project _instance = new Project();

    

    private Project()
    {
    }

    public void Run()
    {
        var settingsProvider = new SettingsProvider("appsettings.json");
        var settings = settingsProvider.Read();
        Console.WriteLine($"Speed = {settings.Velocity}");

        settings.Velocity = 1000;
        settingsProvider.Update(settings);

        settings = settingsProvider.Read();
        Console.WriteLine($"Speed = {settings.Velocity}");
    }

    public static Project Instance
    {
        get
        {
            if (_instance is null)
                _instance = new Project();

            return _instance;
        }
    }
}
