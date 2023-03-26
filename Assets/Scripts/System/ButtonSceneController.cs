using UnityEngine;
using UniRx;
using UnityEngine.UI;
using Constants;
using UnityEngine.SceneManagement;

namespace Other_System
{
    public class ButtonSceneController : MonoBehaviour
    {
        [SerializeField] private SceneType type;
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
        }
        void Start()
        {
            button.OnClickAsObservable()
                .Subscribe(_ => SceneMove())
                .AddTo(this);
        }

        private void SceneMove()
        {
            switch (type)
            {
                case SceneType.Title:
                    SceneManager.LoadSceneAsync(0);
                    break;
                case SceneType.Main:
                    SceneManager.LoadSceneAsync(1);
                    break;
            }
        }
    }
}