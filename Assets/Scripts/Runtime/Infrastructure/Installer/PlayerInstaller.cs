using PlatformGame.Application.Interfaces;
using PlatformGame.Application.Services;

using PlatformGame.Domain.Entities;
using PlatformGame.Presentation.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace PlatformGame.Infrastructure.Installer
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
            builder.Register<Entity>(Lifetime.Scoped);
            builder.Register<PlayerController>(Lifetime.Scoped);
            builder.RegisterComponent<PlayerMovement>(playerPrefab.GetComponent<PlayerMovement>()).As<IPlayerMovement>();
            builder.RegisterComponent<PlayerInputManager>(playerPrefab.GetComponent<PlayerInputManager>());

            builder.RegisterBuildCallback((container) => 
            {
                //container.Resolve<GameManager>().;
            });

        }
    }
}
