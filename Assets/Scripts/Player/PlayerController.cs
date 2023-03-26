using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Constants;
using System;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField, Header("移動速度")] private float movePower = 3f;
        [SerializeField, Header("ジャンプ力")] private float jumpPower = 2f;
        [SerializeField, Header("重力の大きさ")] private float gravityValue = 0.5f;
        [SerializeField, Header("重力判定")] private float gravityDistance = 3f;
        [SerializeField, Header("ゲームオーバーになる時間")] private float gameOverTime = 10f;

        private float gravity;
        private float nowTime = 0;
        private GravityDecisionType gravityType;
        private bool isGround = false;
        private bool isJump = false;
        private bool isPlay = true;

        private Subject<Unit> isGameOver = new Subject<Unit>();

        private Rigidbody rb;


        private CompositeDisposable disposables = new CompositeDisposable();

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Start()
        {
            rb.useGravity = false;
            gravityType = GravityDecisionType.GravityUp;
            gravity = gravityValue;
            this.FixedUpdateAsObservable()
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
            if (isPlay)
            {
                GravityDecision();
                SetGravity();
                if (!isGround)
                {
                    nowTime += Time.deltaTime;
                    if (nowTime >= gameOverTime)
                    {
                        isGameOver.OnNext(Unit.Default);
                        isPlay = false;
                    }
                }
                else
                {
                    nowTime = 0;
                }

                if (gravity != gravityValue)
                {
                    GravityCalculation();
                }
                // 移動処理
                rb.velocity = transform.TransformDirection(new Vector3(movePower, gravity, 0));
            }
        }

        /// <summary>
        /// ジャンプ処理
        /// </summary>
        public void Jump()
        {
            if (isGround)
            {
                isGround = false;
                isJump = true;
                gravity = jumpPower;
            }
        }

        /// <summary>
        /// ゲーム終了
        /// </summary>
        public void EndGame()
        {
            isPlay = false;
        }

        /// <summary>
        /// 地面がどの方向にあるか
        /// </summary>
        private void GravityDecision()
        {
            RaycastHit hit;
            // 左側に地面があるか
            if (Physics.BoxCast(transform.position, new Vector3(1, 1, 1), -transform.right, out hit
            , Quaternion.identity, gravityDistance))
            {
                if (hit.collider.gameObject.CompareTag(TagName.Ground))
                {
                    IsGroundDecision();
                    Vector3 angle = transform.eulerAngles;
                    angle.z = -90;
                    transform.eulerAngles += angle;
                    Debug.Log(hit.collider.name + "Left");
                }
            }
            // 右側に地面があるか
            if (Physics.BoxCast(transform.position, new Vector3(1, 1, 1), transform.right, out hit
            , Quaternion.identity, gravityDistance))
            {
                if (hit.collider.gameObject.CompareTag(TagName.Ground) && !isGround)
                {
                    gravityType = GravityDecisionType.GravityRight;
                    Vector3 angle = transform.eulerAngles;
                    angle.z = 90;
                    transform.eulerAngles += angle;
                    Debug.Log(hit.collider.name + "Right" + angle);
                    isJump = false;
                }
            }
            // 上側に地面があるか
            if (Physics.BoxCast(transform.position, new Vector3(1, 1, 1), transform.up, out hit
            , Quaternion.identity, gravityDistance / 2))
            {
                if (hit.collider.gameObject.CompareTag(TagName.Ground) && isJump)
                {
                    Debug.Log(hit.collider.name + "Up");
                    gravityType = GravityDecisionType.GravityUp;
                    Vector3 angle = transform.eulerAngles;
                    angle.z = 180;
                    transform.eulerAngles += angle;
                    gravity = Mathf.Abs(gravityValue);
                    isJump = false;
                }
            }
        }

        /// <summary>
        /// 右回転するなら重力の向きを決定
        /// </summary>
        private void IsGroundDecision()
        {
            switch (gravityType)
            {
                case GravityDecisionType.GravityUp:
                    gravityType = GravityDecisionType.GravityRight;
                    break;
                case GravityDecisionType.GravityLeft:
                    gravityType = GravityDecisionType.GravityDown;
                    break;
                case GravityDecisionType.GravityDown:
                    gravityType = GravityDecisionType.GravityLeft;
                    break;
                case GravityDecisionType.GravityRight:
                    gravityType = GravityDecisionType.GravityUp;
                    break;
            }
        }

        /// <summary>
        /// 重力判定
        /// </summary>
        private void SetGravity()
        {
            switch (gravityType)
            {
                case GravityDecisionType.GravityUp:
                case GravityDecisionType.GravityLeft:
                case GravityDecisionType.GravityRight:
                    float temp = Mathf.Abs(gravityValue);
                    gravityValue = -temp;
                    break;
                case GravityDecisionType.GravityDown:
                    gravityValue = Mathf.Abs(gravityValue);
                    break;
            }
        }

        /// <summary>
        /// 重力計算
        /// </summary>
        private void GravityCalculation()
        {
            if (gravity > gravityValue)
            {
                gravity += gravityValue;
            }
            else
            {
                gravity -= gravityValue;
            }
        }

        public IObservable<Unit> GetIsGameOver()
        {
            return isGameOver;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(TagName.Ground))
            {
                isGround = true;
                isJump = false;
            }
        }
    }
}