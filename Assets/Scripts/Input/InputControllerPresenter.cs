using UniRx;
using Player;

namespace Input
{
    public class InputControllerPresenter
    {
        private InputController controller;
        private PlayerController player;

        private CompositeDisposable disposables = new CompositeDisposable();

        public InputControllerPresenter(InputController _controller, PlayerController _player)
        {
            controller = _controller;
            player = _player;

            Monitoring();
        }

        private void Monitoring()
        {
            controller.GetPlayerJump()
                .Subscribe(_ => player.Jump())
                .AddTo(disposables);
        }

        public void EndGame()
        {
            disposables.Dispose();
        }
    }
}