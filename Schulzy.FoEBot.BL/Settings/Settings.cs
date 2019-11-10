using Schulzy.FoEBot.Interface;

namespace Schulzy.FoEBot.BL.Settings
{
    public class Settings : ISettings
    {
        public Settings()
        {
            Secret = @"XJ18e9tTgdV5pP6TlHBUah/7sYLewDfTGdoe0Z/bPI+S882zTj8DJHftS19opvb6jSWnbgaJmwAvJDd7m1pLrQ==";
        }

        public string Secret { get; set; } 
        public string Token { get; set; }
        public string Gateway { get; set; }
    }
}
