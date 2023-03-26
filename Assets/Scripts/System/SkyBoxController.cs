using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class SkyBoxController : MonoBehaviour
{
    [SerializeField, Header("回転スピード")]
    private float rotateSpeed = 0.01f;

    [SerializeField, Header("SkyBox")]
    private Material sky;

    private float rotationRepeatValue;

    private CompositeDisposable disposables = new();

    void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => SkyBoxRotate())
            .AddTo(disposables);
    }

    void SkyBoxRotate()
    {
        rotationRepeatValue = Mathf.Repeat(sky.GetFloat("_Rotation") + rotateSpeed, 360f);
        sky.SetFloat("_Rotation", rotationRepeatValue);
    }

    private void OnDestroy()
    {
        disposables.Dispose();
    }
}
