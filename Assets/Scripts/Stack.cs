using System.Collections.Generic;
using UnityEngine;
using System;

namespace MStack {
    [Serializable]
    public class Stack<T> {
        [SerializeField] List<T> list;

        public Stack() {
            list = new List<T>();
        }

        public void MEnqueue(T item) {
            list.Add(item);
        }
        public T MDequeue() {
            if (list.Count > 0) {
                T item = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
                return item;
            }
            return default;
        }
        public int Mcount {
            get { return list.Count; }
        }
        public T MPeek() {
            if (list.Count > 0) {
                return list[list.Count - 1];
            }
            return default;
        }
    }
}
