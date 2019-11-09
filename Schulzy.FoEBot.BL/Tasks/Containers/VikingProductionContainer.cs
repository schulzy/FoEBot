using Schulzy.FoEBot.BL.Constants;
using Schulzy.FoEBot.BL.Tasks.Production;
using Schulzy.FoEBot.Interface.Task;
using Unity;

namespace Schulzy.FoEBot.BL.Tasks.Containers
{
    public class BronzAgeProductionContainer
    {
        private IUnityContainer _diContainer;

        public BronzAgeProductionContainer(IUnityContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Initialize()
        {
            Setup();
        }

        private void Setup()
        {
            var bronzAgeHarvest = _diContainer.Resolve<TaskContainer>();
            bronzAgeHarvest.AddTask(new BronzAgePickupProduction(_diContainer));
            bronzAgeHarvest.AddTask(new BronzAgeStartProduction(_diContainer));
            _diContainer.RegisterInstance<ITaskContainer>(Constant.TaskContainerNames.BronzAgeHarvest, bronzAgeHarvest);
        }
    }
}