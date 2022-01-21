using System;
using BeatSaberMarkupLanguage;
using HMUI;
using SiraUtil.Logging;
using Zenject;

namespace SliceVisualizer.UI
{
    internal class NsvSettingsFlowCoordinator : FlowCoordinator
    {
        private SiraLog _siraLog = null!;
        private NsvSettingsViewController _settingsViewController = null!;

        [Inject]
        internal void Construct(SiraLog siraLog, NsvSettingsViewController settingsViewController)
        {
            _settingsViewController = settingsViewController;
            _siraLog = siraLog;
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            try
            {
                if (firstActivation)
                {
                    SetTitle("SliceVisualizer settings");
                    showBackButton = true;

                    ProvideInitialViewControllers(_settingsViewController);
                }
            }
            catch (Exception e)
            {
                _siraLog.Error(e);
            }
        }

        protected override void BackButtonWasPressed(ViewController _)
        {
            BeatSaberUI.MainFlowCoordinator.DismissFlowCoordinator(this);
        }
    }
}