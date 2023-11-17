using Player;
using UniRx;

namespace Result
{
    public class GameOverPresenter
    {
        private static ResultView view;
        private static IPlayerController player;

        private CompositeDisposable disposables = new CompositeDisposable();

        public GameOverPresenter(ResultView _view, IPlayerController _player)
        {
            view = _view;
            player = _player;

            player.IsGameOver
                .Distinct()
                .Subscribe(_ => view.OpenGameOverWindow())
                .AddTo(disposables);
        }

        public void GameEnd()
        {
            disposables.Dispose();
        }
    }
}