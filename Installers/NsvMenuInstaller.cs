using SliceVisualizer.UI;
using Zenject;

namespace SliceVisualizer.Installers
{
    public class NsvMenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<NsvSettingsViewController>().FromNewComponentAsViewController().AsSingle().Lazy();
            Container.Bind<NsvSettingsFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle().Lazy();
            Container.BindInterfacesTo<NsvButtonManager>().AsSingle();
        }
    }
}