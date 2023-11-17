using UniRx;
using Player;
using UI;

namespace Other_System
{
    public class GameTimerPresenter
    {
        private bool endGame = false;
        private CompositeDisposable disposables = new CompositeDisposable();
        public GameTimerPresenter(GameTimer gameTimer, TimerView view, IPlayerController player)
        {
            gameTimer.GetTimeCount()
                .Where(_ => !endGame)
                .Subscribe(x => view.SetTimerText(gameTimer.GetLimitCount(), x))
                .AddTo(disposables);

            gameTimer.GetTimeOver()
                .Distinct()
                .Subscribe(_ =>
                {
                    endGame = true;
                    player.EndGame();
                }).AddTo(disposables);
        }

        public void EndGame()
        {
            disposables.Dispose();
        }
    }
}