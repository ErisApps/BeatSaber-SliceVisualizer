using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Logging;
using SiraUtil.Zenject;
using SliceVisualizer.Configuration;
using SliceVisualizer.Installers;

namespace SliceVisualizer
{
    [Plugin(RuntimeOptions.DynamicInit), NoEnableDisable]
    public class Plugin
    {
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        [Init]
        public Plugin(Logger logger, Config conf, Zenjector zenject)
        {
            zenject.UseLogger(logger);

            zenject.Install<NsvAppInstaller>(Location.App,conf.Generated<PluginConfig>());
            zenject.Install<NsvMenuInstaller>(Location.Menu);
            zenject.Install<NsvGameInstaller>(Location.Player);
        }
    }
}
