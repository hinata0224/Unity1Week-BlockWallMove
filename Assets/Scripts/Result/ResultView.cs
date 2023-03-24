using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Result
{
    public class ResultView : MonoBehaviour
    {
        [SerializeField, Header("GameClearウィンドウ")] private GameObject clearWindow;

        void Start()
        {
            clearWindow.SetActive(false);
        }

        /// <summary>
        /// GameClearWindowを表示する
        /// </summary>
        public void OpenClearWindow()
        {
            clearWindow.SetActive(true);
        }
    }
}