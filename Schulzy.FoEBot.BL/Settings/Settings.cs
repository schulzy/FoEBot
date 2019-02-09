using Schulzy.FoEBot.Interface;

namespace Schulzy.FoEBot.BL.Settings
{
    public class Settings : ISettings
    {
        public Settings()
        {
            Secret = @"5ojZ7ltWda/CMrY6IhVwdvAMYK9Gy5QLIdrSDitg9/ugY9y8YL8haQp7ZR6EXZo182gNenXv0Er4F2p1myI0MA==";
        }

        public string Secret { get; set; } 
        public string Token { get; set; }
        public string Gateway { get; set; }
    }
}
