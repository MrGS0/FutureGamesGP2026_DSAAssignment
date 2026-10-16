using Environment.Tasks;
using MQueue;
using MStack;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField] Queue<Task> queue = new Queue<Task>();
        [SerializeField] Stack<Task> stack = new Stack<Task>();
        [SerializeField] bool queueBool = false;
        public void OnInteract() {
            if(queueBool) {
                if(queue.Mcount > 0)
                    { Task task = queue.MDequeue();
                    task.Execute(); }
            } else if(stack.Mcount > 0)
                { Task task = stack.MDequeue();
                task.Execute();
            }
        }
    }
}
