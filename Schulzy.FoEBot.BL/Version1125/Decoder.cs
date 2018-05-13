using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Schulzy.FoEBot.Interface;

namespace Schulzy.FoEBot.BL.Version1125
{
    public class Decoder : IDecoder
    {
        public string Signature { get; private set; }
        private string m_fullText;

        public Decoder(string fullText)
        {
            m_fullText = fullText;
        }

        public Decoder(string userKey, string secret, string payload)
        {
            m_fullText = userKey + secret + payload;
        }

        public void Decode()
        {
            using (MD5 md5Hash = MD5.Create())
            {
                Signature = Tools.GetMd5Hash(md5Hash, m_fullText);
            }
        }
    }
}
