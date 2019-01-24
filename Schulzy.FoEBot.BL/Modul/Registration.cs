using Schulzy.FoEBot.BL.Communication;
using Schulzy.FoEBot.Interface;
using Schulzy.FoEBot.Interface.Communications;
using Schulzy.FoEBot.Interface.Task;
using Unity;

namespace Schulzy.FoEBot.BL.Modul
{
    using Settings;
    internal class Registration
    {
        public void RegisterAll(IUnityContainer diContainer)
        {
            RegisterCommunication(diContainer);
            RegisterHelpers(diContainer);
        }

        void RegisterCommunication(IUnityContainer diContainer)
        {
            diContainer.RegisterInstance<IHttpRequestManager>(new HttpRequestManager());

        }
        void RegisterHelpers(IUnityContainer diContainer)
        {
            diContainer.RegisterInstance<ITaskManager>(new TaskManager());
            diContainer.RegisterInstance<ISettings>(new Settings());
            diContainer.RegisterType<IRequestManagerInitializer, RequestManagerInitializer>();
        }
    }
}
