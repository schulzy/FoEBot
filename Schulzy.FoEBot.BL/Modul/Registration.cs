using Schulzy.FoEBot.BL.Communication;
using Schulzy.FoEBot.BL.Managers;
using Schulzy.FoEBot.BL.ResponseProcessor;
using Schulzy.FoEBot.BL.Tasks;
using Schulzy.FoEBot.BL.Tasks.Containers;
using Schulzy.FoEBot.BL.Utils;
using Schulzy.FoEBot.Interface;
using Schulzy.FoEBot.Interface.Communications;
using Schulzy.FoEBot.Interface.Manager;
using Schulzy.FoEBot.Interface.ResponseProcessor;
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
            RegisterTaskManagement(diContainer);
            RegisterTaskContainers(diContainer);
            RegisterSessionProcessors(diContainer);
        }

        private void RegisterSessionProcessors(IUnityContainer diContainer)
        {
            diContainer.RegisterType<INoSessionResponse, NoSessionResponse>();
        }

        private void RegisterTaskContainers(IUnityContainer diContainer)
        {
            new FoeInitializeTaskContainer(diContainer).Initialize();
            new BronzAgeProductionContainer(diContainer).Initialize();
            new VikingProductionContainer(diContainer).Initialize();
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
            diContainer.RegisterInstance<IRequestIdManager>(new RequestIdManager());
            diContainer.RegisterType<IHashCreator, HashCreator>();
            diContainer.RegisterInstance<ISettings>(new Settings());
            diContainer.RegisterType<IRequestManagerInitializer, RequestManagerInitializer>();
        }
    }
}
