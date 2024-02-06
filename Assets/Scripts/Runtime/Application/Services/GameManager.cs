using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformGame.Application.Services
{
    public class GameManager
    {
        public ReactiveCommand<Unit> StartGame { get; private set; }

        public GameManager()
        {
            StartGame = new ReactiveCommand<Unit>();
            StartGame.Subscribe(_ => InitializeGame());
        }

        private void InitializeGame()
        {

        }

        ~GameManager()
        {
            StartGame.Dispose();
        }

    }
}
