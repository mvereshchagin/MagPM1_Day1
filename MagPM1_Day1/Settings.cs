using Microsoft.Extensions.Configuration;

namespace MagPM1_Day1;
internal record Settings
{
    [ConfigurationKeyName("UserName")]
    public string? UserName2 { get; set; }

    [ConfigurationKeyName("speed")]
    public int Velocity { get; set; }

    public int MaxLength { get; set; }

    public string? FgColor { get; set; }

    public string? BgColor { get; set; }

    public int AmountOfPoints { get; set; }

    [ConfigurationKeyName("Part1")]
    public SettingsPart1 Part1 { get; set; } = new();

    public int Width { get; set; }

    public int Height { get; set; }


    internal record SettingsPart1
    {
        public int Setting1 { get; set; }
        public int Setting2 { get; set; }
        public int Setting3 { get; set; }
    }
}

