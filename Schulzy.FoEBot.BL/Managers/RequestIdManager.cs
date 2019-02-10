using System.Threading;
using Schulzy.FoEBot.Interface.Manager;

namespace Schulzy.FoEBot.BL.Managers
{
    public class RequestIdManager : IRequestIdManager
    {
        private int _counter;

        public int GetNextId
        {
            get
            {
                Interlocked.Increment(ref _counter);
                return _counter;
            }
        }

        public void ResetId()
        {
            _counter = 0;
        }
    }
}