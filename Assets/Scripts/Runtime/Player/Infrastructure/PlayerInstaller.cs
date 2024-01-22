using PlatformGame.Player.Application;
using PlatformGame.Player.Presentation;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace PlatformGame.Player.Infrastructure
{
    public class PlayerInstaller : LifetimeScope
    {
        [SerializeField]
        private GameObject playerPrefab;

        private void Start()
        {
            DontDestroyOnLoad(this);
            
        }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameManager>(Lifetime.Scoped);
            builder.Register<Player.Core.PlayerModel>(Lifetime.Scoped);
            builder.Register<PlayerPresenter>(Lifetime.Scoped);

            builder.RegisterComponentInNewPrefab<PlayerMovement>
                (playerPrefab.GetComponent<PlayerMovement>(),Lifetime.Scoped).As<IPlayerMovement>();

            builder.RegisterBuildCallback((container) => 
            {
                //container.Resolve<GameManager>().;
            });

        }
    }
}
