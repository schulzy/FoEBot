using Schulzy.FoEBot.Interface.Model;
using Schulzy.FoEBot.Interface.Task;
using Unity;

namespace Schulzy.FoEBot.BL.Tasks.Production
{
    public class VikingCityCulturalPickupProduction : ITask
    {
        private IUnityContainer _diContainer;

        public VikingCityCulturalPickupProduction(IUnityContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public int Priority { get; } = 10;
        public void Run()
        {
            throw new System.NotImplementedException();
        }

        public FoeTaskStatus Status { get; }
    }
}