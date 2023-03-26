using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UniRx;

namespace Result
{
    public class GameOverPresenter
    {
        private static ResultView view;
        private static PlayerController player;

        private CompositeDisposable disposables = new CompositeDisposable();

        public GameOverPresenter(ResultView _view, PlayerController _player)
        {
            view = _view;
            player = _player;

            player.GetIsGameOver()
                .Subscribe(_ => view.OpenGameOverWindow())
                .AddTo(disposables);
        }

        public void GameEnd()
        {
            disposables.Dispose();
        }
    }
}