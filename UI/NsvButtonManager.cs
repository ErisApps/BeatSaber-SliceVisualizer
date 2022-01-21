using System;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using Zenject;

namespace SliceVisualizer.UI
{
    internal class NsvButtonManager : IInitializable, IDisposable
    {
        private readonly LazyInject<NsvSettingsFlowCoordinator> _lazySettingsFlowCoordinator;
        private readonly MainFlowCoordinator _mainFlowCoordinator;

        private MenuButton? _nsvButton;

        public NsvButtonManager(LazyInject<NsvSettingsFlowCoordinator> lazySettingsFlowCoordinator, MainFlowCoordinator mainFlowCoordinator)
        {
            _lazySettingsFlowCoordinator = lazySettingsFlowCoordinator;
            _mainFlowCoordinator = mainFlowCoordinator;

            _nsvButton = new MenuButton("SliceVisualizer", "Chase the perfect slice", OnClick);
        }

        public void Initialize()
        {
            MenuButtons.instance.RegisterButton(_nsvButton);
        }

        private void OnClick()
        {
            if (_lazySettingsFlowCoordinator.Value == null)
            {
                return;
            }

            _mainFlowCoordinator.PresentFlowCoordinator(_lazySettingsFlowCoordinator.Value);
        }

        public void Dispose()
        {
            if (_nsvButton == null)
            {
                return;
            }

            if (MenuButtons.IsSingletonAvailable && BSMLParser.IsSingletonAvailable)
            {
                MenuButtons.instance.UnregisterButton(_nsvButton);
            }

            _nsvButton = null!;
        }
    }
}