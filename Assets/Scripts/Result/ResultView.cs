using UnityEngine;
using UnityEngine.UI;

namespace Result
{
    public class ResultView : MonoBehaviour
    {
        [SerializeField, Header("GameClearウィンドウ")] private GameObject clearWindow;
        [SerializeField, Header("GameOverWindow")] private GameObject gameOverWindow;

        void Start()
        {
            clearWindow.SetActive(false);
            gameOverWindow.SetActive(false);
        }

        /// <summary>
        /// GameClearWindowを表示する
        /// </summary>
        public void OpenClearWindow()
        {
            clearWindow.SetActive(true);
        }

        /// <summary>
        /// GameOverWindowを表示する
        /// </summary>
        public void OpenGameOverWindow()
        {
            gameOverWindow.SetActive(true);
        }
    }
}