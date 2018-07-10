using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulzy.FoEBot.Interface
{
    public interface IPayload
    {
        string GetPayload(PayloadData data);
    }
}
