using SliceVisualizer.Configuration;
using Zenject;

namespace SliceVisualizer.Installers
{
    internal class NsvAppInstaller : Installer
    {
        private readonly PluginConfig _config;

        public NsvAppInstaller(PluginConfig config)
        {
            _config = config;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(_config).AsSingle();

            Container.BindInterfacesAndSelfTo<NsvAssetLoader>().AsSingle().Lazy();
        }
    }
}