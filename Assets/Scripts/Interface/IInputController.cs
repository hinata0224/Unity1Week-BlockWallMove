using UniRx;
using System;

namespace Input
{
    public interface IInputController
    {
        public IObservable<Unit> JunpObservable { get; }
        public IObservable<Unit> InvincibleObservable { get; }
    }
}
