using PlatformGame.Game.Application;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace PlatformGame.UI.Application
{
    public class MainMenuPresenter
    {
        [Inject]
        private readonly GameFlowManager gameFlowManager;

        public MainMenuPresenter()
        {

        }

        public void OnNewGameButtonClicked()
        {
            gameFlowManager.NewGame();
        }

        public void OnLoadGameButtonClicked()
        {
            gameFlowManager.LoadGame();
        }

        public void OnOptionButtonClicked()
        {
            
        }

        public void OnExitGameButtonClicked()
        {
            gameFlowManager.ExitGame();
        }
    }
}