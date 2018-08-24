using Schulzy.FoEBot.Interface;

namespace Schulzy.FoEBot.BL
{
    public class Decoder : IDecoder
    {
        private readonly string _fullText;
        private readonly HashCreator _hashCreator;

        public Decoder(string fullText)
        {
            _fullText = fullText;
            _hashCreator = new HashCreator();
        }

        public Decoder(string userKey, string secret, string payload)
        {
            _fullText = userKey + secret + payload;
            _hashCreator = new HashCreator();
        }

        public string Signature { get; private set; }

        public void Decode()
        {
            _hashCreator.GetMd5Hash(_fullText);
        }
    }
}