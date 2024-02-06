using UnityEngine;
using UnityEngine.UI;
using R3;
using VContainer;
using PlatformGame.Application.Services;

namespace PlatformGame.Presentation.UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField]
        private Button newGameButton;
        [SerializeField]
        private Button loadGameButton;
        [SerializeField]
        private Button optionButton;
        [SerializeField]
        private Button exitGameButton;

        [Inject]
        private readonly MainMenuPresenter presenter;


        private void Awake()
        {
            newGameButton.onClick.AsObservable().Subscribe((_)=> { presenter.OnNewGameButtonClicked(); });
            loadGameButton.onClick.AsObservable().Subscribe((_) => { presenter.OnLoadGameButtonClicked(); });
            optionButton.onClick.AsObservable().Subscribe((_) => { presenter.OnOptionButtonClicked(); });
            exitGameButton.onClick.AsObservable().Subscribe((_) => { presenter.OnExitGameButtonClicked(); });

        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }


    }
}
