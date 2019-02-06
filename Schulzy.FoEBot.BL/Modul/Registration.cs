using System.Threading.Tasks;
using Schulzy.FoEBot.BL.Communication;
using Schulzy.FoEBot.BL.Tasks;
using Schulzy.FoEBot.BL.Tasks.Containers;
using Schulzy.FoEBot.Interface;
using Schulzy.FoEBot.Interface.Communications;
using Schulzy.FoEBot.Interface.Task;
using Unity;

namespace Schulzy.FoEBot.BL.Modul
{
    using System;
    using Settings;
    internal class Registration
    {
        public void RegisterAll(IUnityContainer diContainer)
        {
            RegisterCommunication(diContainer);
            RegisterHelpers(diContainer);
            RegisterTaskManagement(diContainer);
            RegisterTaskContainers(diContainer);
        }

        private void RegisterTaskContainers(IUnityContainer diContainer)
        {
            new RegisterTaskContainers(diContainer).Initialize();
        }

        private void RegisterTaskManagement(IUnityContainer diContainer)
        {
            diContainer.RegisterInstance<ITaskManager>(new TaskManager());
            diContainer.RegisterType<ITaskContainer, TaskContainer>();
        }

        void RegisterCommunication(IUnityContainer diContainer)
        {
            diContainer.RegisterInstance<IHttpRequestManager>(new HttpRequestManager());

        }
        void RegisterHelpers(IUnityContainer diContainer)
        {
            diContainer.RegisterInstance<ISettings>(new Settings());
            diContainer.RegisterType<IRequestManagerInitializer, RequestManagerInitializer>();
        }
    }
}
