using UnityEngine;
using Constants;
using UniRx;
using UniRx.Triggers;

namespace Player
{
    public class CameraController : MonoBehaviour
    {
        private int height = 1;

        private GameObject player;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag(TagName.Player);
        }
        void Start()
        {
            this.UpdateAsObservable()
                .Subscribe(_ => transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z))
                .AddTo(this);
        }

        /// <summary>
        /// 高さの変更
        /// </summary>
        /// <param name="_height">変更したい高さ</param>
        public void ChengeHeight(int _height)
        {
            height = _height;
        }
    }
}