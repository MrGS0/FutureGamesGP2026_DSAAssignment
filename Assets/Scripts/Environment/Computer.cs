using Environment.Tasks;
using NUnit.Framework;
using UnityEngine;
using MQueue;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        Queue<Task> taskQueue = new Queue<Task>();

        public void OnInteract() {
            if(taskQueue.Mcount > 0) {
                Task task = taskQueue.MDequeue();
                task.Execute();
            }
        }
    }
}
