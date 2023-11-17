using UniRx;
using System;

namespace Player
{
    public interface IPlayerController
    {
        public IObservable<Unit> IsGameOver { get; }

        /// <summary>
        /// ジャンプ処理
        /// </summary>
        public void Jump();

        /// <summary>
        /// ゲーム終了
        /// </summary>
        public void EndGame();
    }
}
