using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;
using System;

namespace Input
{
    public class InputController : MonoBehaviour
    {
        private Subject<Unit> playerJump = new Subject<Unit>();
        private Subject<Unit> playerInvincible = new Subject<Unit>();

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

        public IObservable<Unit> GetPlayerJump()
        {
            return playerJump;
        }

        public IObservable<Unit> GetPlayerInvincible()
        {
            return playerInvincible;
        }
    }
}