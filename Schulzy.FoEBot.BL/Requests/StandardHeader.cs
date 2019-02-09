using System;
using Schulzy.FoEBot.Interface.Communications;

namespace Schulzy.FoEBot.BL.Requests
{
    internal class StandardHeader : Header
    {
        private readonly IHttpRequestManager _manager;

        public StandardHeader(IHttpRequestManager manager)
        {
            _manager = manager;
        }

        public override void Clear()
        {
            _manager.Header.Clear();
            _manager.Accept = string.Empty;
            _manager.ContentType = string.Empty;
            _manager.UserAgent = string.Empty;
        }

        public override void CreateHeader()
        {
            throw new NotImplementedException();
        }
    }
}