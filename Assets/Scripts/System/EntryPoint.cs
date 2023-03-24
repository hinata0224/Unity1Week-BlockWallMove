using UnityEngine;
using Player;
using Input;
using Result;

namespace Other_System
{
    public class EntryPoint : MonoBehaviour
    {
        [Header("参照スクリプト")]
        [SerializeField] private PlayerController playerController;
        [SerializeField] private InputController inputController;
        [SerializeField] private ResultView resultView;

        private InputControllerPresenter inputControllerPresenter;
        private GameClearPresenter gameClearPresenter;

        void Start()
        {
            inputControllerPresenter = new InputControllerPresenter(inputController, playerController);
            gameClearPresenter = new GameClearPresenter(resultView);
        }

        private void OnDestroy()
        {
            inputControllerPresenter.EndGame();
        }
    }
}