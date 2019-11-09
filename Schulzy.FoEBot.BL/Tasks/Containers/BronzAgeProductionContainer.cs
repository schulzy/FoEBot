using Schulzy.FoEBot.BL.Constants;
using Schulzy.FoEBot.BL.Tasks.Production;
using Schulzy.FoEBot.BL.Tasks.Production.Cultural;
using Schulzy.FoEBot.Interface.Task;
using Unity;

namespace Schulzy.FoEBot.BL.Tasks.Containers
{
    public class VikingProductionContainer
    {
        private readonly IUnityContainer _diContainer;

        public VikingProductionContainer(IUnityContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Initialize()
        {
            Setup();
        }

        private void Setup()
        {
            var vikingHarvest = _diContainer.Resolve<TaskContainer>();
            vikingHarvest.AddTask(new VikingCityCulturalPickupProduction(_diContainer));
            vikingHarvest.AddTask(new VikingCityCulturalStartProduction(_diContainer));
            _diContainer.RegisterInstance<ITaskContainer>(Constant.TaskContainerNames.VikingProduktion, vikingHarvest);
        }
    }
}