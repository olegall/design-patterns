using System.Collections.Generic;

namespace Observer
{
    interface IObservable_
    {
        void AddObserver(IObserver_ o);
        void RemoveObserver(IObserver_ o);
        void NotifyObservers();
    }

    class ConcreteObservable : IObservable_
    {
        private List<IObserver_> observers;
        public ConcreteObservable()
        {
            observers = new List<IObserver_>();
        }
        public void AddObserver(IObserver_ o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver_ o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver_ observer in observers)
                observer.Update();
        }
    }

    interface IObserver_
    {
        void Update();
    }

    class ConcreteObserver : IObserver_
    {
        public void Update()
        {
        }
    }
}
