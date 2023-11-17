using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;
using System;

namespace Input
{
    public class InputController : MonoBehaviour, IInputController
    {
        private Subject<Unit> playerJump = new Subject<Unit>();
        private Subject<Unit> playerInvincible = new Subject<Unit>();

        public IObservable<Unit> JunpObservable => playerJump;
        public IObservable<Unit> InvincibleObservable => playerInvincible;

        /// <summary>
        /// ジャンプボタンが押されたら
        /// </summary>
        /// <param name="context"></param>
        public void PlayerJump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                playerJump.OnNext(Unit.Default);
            }
        }

        /// <summary>
        /// 無敵ボタンが押されたら
        /// </summary>
        /// <param name="context"></param>
        public void PlayerInvincible(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                playerInvincible.OnNext(Unit.Default);
            }
        }
    }
}