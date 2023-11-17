using UniRx;
using Player;

namespace Input
{
    public class InputControllerPresenter
    {
        private IInputController controller;
        private PlayerController player;

        private CompositeDisposable disposables = new CompositeDisposable();

        public InputControllerPresenter(IInputController _controller, PlayerController _player)
        {
            controller = _controller;
            player = _player;

            Monitoring();
        }

        private void Monitoring()
        {
            controller.JunpObservable
                .Subscribe(_ => player.Jump())
                .AddTo(disposables);
        }

        public void EndGame()
        {
            disposables.Dispose();
        }
    }
}