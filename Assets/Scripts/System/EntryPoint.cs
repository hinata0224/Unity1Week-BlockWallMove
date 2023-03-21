using UnityEngine;
using Player;
using Input;

namespace Other_System
{
    public class EntryPoint : MonoBehaviour
    {
        [Header("参照スクリプト")]
        [SerializeField] private PlayerController playerController;
        [SerializeField] private InputController inputController;

        private InputControllerPresenter inputControllerPresenter;

        void Start()
        {
            inputControllerPresenter = new InputControllerPresenter(inputController, playerController);
        }

        private void OnDestroy()
        {
            inputControllerPresenter.EndGame();
        }
    }
}