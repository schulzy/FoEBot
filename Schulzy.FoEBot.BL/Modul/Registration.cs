using Schulzy.FoEBot.BL.Communication;
using Schulzy.FoEBot.BL.Utils;
using Schulzy.FoEBot.Interface;
using Unity;

namespace Schulzy.FoEBot.BL.Modul
{
    internal class Registration
    {
        void RegisterCommunication(IUnityContainer diContainer)
        {
            diContainer.RegisterType<IHttpRequestManager, HttpRequestManager>();
        }
        void RegisterHelpers(IUnityContainer diContainer)
        {
            diContainer.RegisterType<IConverter, HttpRequestConverter>();
        }
    }
}
