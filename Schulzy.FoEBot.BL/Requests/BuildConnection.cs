using Schulzy.FoEBot.Interface.Communications;

namespace Schulzy.FoEBot.BL.Requests
{
    internal class BuildConnection
    {
        private IHttpRequestManager _manager;

        internal BuildConnection(IHttpRequestManager manager)
        {
            _manager = manager;
        }

        internal void Initialize()
        {
        }
    }
}