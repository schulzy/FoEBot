using Schulzy.FoEBot.Interface;

namespace Schulzy.FoEBot.BL.Settings
{
    public class Settings : ISettings
    {
        public Settings()
        {
            Secret = @"X2hSCLmVfPKbmWIMm88CfEokCPVIfhV1cooHcF4yopCUkfEQJ6IsaDWsZHkz1xTfWAOdWPn2Iwp6wbLmnJBElw==";
        }

        public string Secret { get; set; } 
        public string Token { get; set; }
        public string Gateway { get; set; }
    }
}
