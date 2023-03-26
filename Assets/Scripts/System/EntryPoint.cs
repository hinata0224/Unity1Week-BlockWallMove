using UnityEngine;
using Player;
using Input;
using Result;
using UI;

namespace Other_System
{
    public class EntryPoint : MonoBehaviour
    {
        [Header("参照スクリプト")]
        [SerializeField] private PlayerController playerController;
        [SerializeField] private InputController inputController;
        [SerializeField] private ResultView resultView;
        [SerializeField] private TimerView timerView;

        private InputControllerPresenter inputControllerPresenter;
        private GameClearPresenter gameClearPresenter;
        private GameOverPresenter gameOverPresenter;
        private GameTimerPresenter gameTimerPresenter;
        private GameTimer gameTimer = new GameTimer();

        void Start()
        {
            inputControllerPresenter = new InputControllerPresenter(inputController, playerController);
            gameClearPresenter = new GameClearPresenter(resultView);
            gameOverPresenter = new GameOverPresenter(resultView, playerController);
            gameTimerPresenter = new GameTimerPresenter(gameTimer, timerView, playerController);
            gameTimer.TimerStart();
        }

        private void OnDestroy()
        {
            inputControllerPresenter.EndGame();
            gameOverPresenter.GameEnd();
            gameTimer.EndGame();
            gameTimerPresenter.EndGame();
        }
    }
}