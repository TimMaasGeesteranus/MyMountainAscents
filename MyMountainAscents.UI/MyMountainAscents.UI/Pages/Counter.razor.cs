using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMountainAscents.UI.Pages
{
    public partial class Counter
    {
        protected int CurrentCount = 0;

        protected void IncrementCount()
        {
            System.Diagnostics.Debugger.Launch();
            CurrentCount++;
        }

        public Counter()
        {
            DataStore<string> store = new();
            store.AddOrUpdate(0, "first");
            store.AddOrUpdate(1, "second");
            store.AddOrUpdate(2, "third");
        }

        class DataStore<T>
        {
            private T[] _data = new T[10];

            public void AddOrUpdate(int index, T item)
            {
                if (index >= 0 && index < 10)
                    _data[index] = item;
            }

            public T GetData(int index)
            {
                if (index >= 0 && index < 10)
                    return _data[index];
                else
                    return default(T);
            }
        }
    }
}
