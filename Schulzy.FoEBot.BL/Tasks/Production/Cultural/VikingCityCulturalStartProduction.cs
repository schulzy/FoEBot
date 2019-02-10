using Schulzy.FoEBot.Interface.Model;
using Schulzy.FoEBot.Interface.Task;
using Unity;

namespace Schulzy.FoEBot.BL.Tasks.Production
{
    public class VikingCityCulturalStartProduction : ITask
    {
        private IUnityContainer _diContainer;

        public VikingCityCulturalStartProduction(IUnityContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public int Priority { get; } = 11;
        public void Run()
        {
            throw new System.NotImplementedException();
        }

        public FoeTaskStatus Status { get; } = FoeTaskStatus.NotStarted;
    }
}