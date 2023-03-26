using UniRx;
using System;

public class GameTimer
{
    private int gameCount = 5;
    private Subject<Unit> timerOver = new Subject<Unit>();
    private ReactiveProperty<int> timeCount = new ReactiveProperty<int>(0);

    private CompositeDisposable disposables = new CompositeDisposable();


    public void TimerStart()
    {
        Observable.Timer(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1))
            .Subscribe(_ => timeCount.Value++)
            .AddTo(disposables);

        timeCount.Where(x => x > gameCount)
            .Subscribe(_ => timerOver.OnNext(Unit.Default))
            .AddTo(disposables);
    }

    public void EndGame()
    {
        disposables.Dispose();
    }

    public int GetLimitCount()
    {
        return gameCount;
    }

    public IObservable<int> GetTimeCount()
    {
        return timeCount;
    }
    public IObservable<Unit> GetTimeOver()
    {
        return timerOver;
    }

}
