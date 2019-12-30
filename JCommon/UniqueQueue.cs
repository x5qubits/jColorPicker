using System;
using System.Collections.Generic;
using System.Text;

namespace JCommon
{
    public class UniqueQueue<T> : IEnumerable<T>
    {
        HashSet<T> m_HashSet;
        Queue<T> m_Queue;

        public UniqueQueue()
        {
            m_HashSet = new HashSet<T>();
            m_Queue = new Queue<T>();
        }

        public int Count
        {
            get
            {
                return m_HashSet.Count;
            }
        }

        public void Clear()
        {
            m_HashSet.Clear();
            m_Queue.Clear();
        }


        public bool Contains(T item)
        {
            return m_HashSet.Contains(item);
        }


        public void Enqueue(T item)
        {
            if (m_HashSet.Add(item))
            {
                m_Queue.Enqueue(item);
            }
        }

        public T Dequeue()
        {
            T item = m_Queue.Dequeue();
            m_HashSet.Remove(item);
            return item;
        }


        public T Peek()
        {
            return m_Queue.Peek();
        }


        public IEnumerator<T> GetEnumerator()
        {
            return m_Queue.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_Queue.GetEnumerator();
        }
    }
}
