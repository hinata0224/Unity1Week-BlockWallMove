using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Result
{
    public class GameClearPresenter
    {
        private static ResultView view;

        public GameClearPresenter(ResultView resultView)
        {
            view = resultView;
        }

        public static void OpenClearWindow()
        {
            view.OpenClearWindow();
        }
    }
}