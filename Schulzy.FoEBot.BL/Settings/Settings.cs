using Schulzy.FoEBot.Interface;

namespace Schulzy.FoEBot.BL.Settings
{
    public class Settings : ISettings
    {
        public Settings()
        {
            Secret = @"Rw7oeLIP29HTVWjgS3NG6UzoyfIoEtwUR3pY/if76FdLOZHUPRLGHVDRCkdk4zijAqv4YGXBtIbKKnDCn7/8+A==";
        }

        public string Secret { get; set; } 
        public string Token { get; set; }
    }
}