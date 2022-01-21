using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using SliceVisualizer.Configuration;
using Zenject;

namespace SliceVisualizer.ViewControllers
{
    internal class NsvSettingsViewController : BSMLResourceViewController
    {
        private PluginConfig _config = null!;

        public override string ResourceName => "SliceVisualizer.UI.Views.Main.bsml";

        [Inject]
        internal void Construct(PluginConfig config)
        {
            _config = config;
        }

        [UIValue("Enabled-value")]
        public bool EnabledValue
        {
            get => _config.Enabled;
            set => _config.Enabled = value;
        }
    }
}