using System;

namespace QOL
{
    public class ActionEvents
    {
        private Action _event = delegate { };

        public void AddListener(Action listener)
        {
            RemoveListener(listener);
            _event += listener;
        }

        public void RemoveListener(Action listener)
        {
            _event -= listener;
        }

        public void RemoveAllListeners()
        {
            _event = null;
        }

        public void Invoke()
        {
            _event?.Invoke();
        }

        public static ActionEvents operator +(ActionEvents a, Action b)
        {
            a.AddListener(b);
            return a;
        }

        public static ActionEvents operator -(ActionEvents a, Action b)
        {
            a.RemoveListener(b);
            return a;
        }
    }

    public class ActionEvents<T>
    {
        private Action<T> _event = delegate { };

        public void AddListener(Action<T> listener)
        {
            RemoveListener(listener);
            _event += listener;
        }

        public void RemoveListener(Action<T> listener)
        {
            _event -= listener;
        }

        public void RemoveAllListeners()
        {
            _event = null;
        }

        public void Invoke(T value)
        {
            _event?.Invoke(value);
        }

        public static ActionEvents<T> operator +(ActionEvents<T> a, Action<T> b)
        {
            a.AddListener(b);
            return a;
        }

        public static ActionEvents<T> operator -(ActionEvents<T> a, Action<T> b)
        {
            a.RemoveListener(b);
            return a;
        }
    }
}