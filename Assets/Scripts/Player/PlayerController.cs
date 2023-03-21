using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Constants;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField, Header("移動速度")] private float movePower = 3f;
        [SerializeField, Header("ジャンプ力")] private float jumpPower = 2f;

        private Rigidbody rb;

        private bool isGround = false;

        private CompositeDisposable disposables = new CompositeDisposable();

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Start()
        {
            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                    PlayerMove();
                }).AddTo(disposables);
        }

        /// <summary>
        /// プレイヤーの横移動
        /// </summary>
        private void PlayerMove()
        {
            rb.velocity = new Vector3(movePower, rb.velocity.y, 0);
        }

        /// <summary>
        /// ジャンプ処理
        /// </summary>
        public void Jump()
        {
            if (isGround)
            {
                rb.AddForce(0, jumpPower, 0);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(TagName.Ground))
            {
                isGround = true;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag(TagName.Ground))
            {
                isGround = false;
            }
        }
    }
}