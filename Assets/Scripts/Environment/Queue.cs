using System.Collections.Generic;
using UnityEngine;
using System;

namespace MQueue {
    [Serializable]
    public class Queue<T> {
        [SerializeField] List<T> list;

        public Queue() {
            list = new List<T>();
        }

        public void MEnqueue(T item) {
            list.Add(item);
        }
        public T MDequeue() {
            if (list.Count > 0) {
                T item = list[0];
                list.RemoveAt(0);
                return item;
            }
            return default;
        }
        public int Mcount {
            get { return list.Count; }
        }
        public T MPeek() {
            if (list.Count > 0) {
                return list[0];
            }
            return default;
        }
    }
}
