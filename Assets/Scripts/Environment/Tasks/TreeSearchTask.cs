using System;
using System.Collections.Generic;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Tree Search Task", menuName = "Tree Search Task")]
    public class TreeSearchTask : Task {

        [SerializeField]
        TreeTask treeTask;
        [SerializeField]
        string lowTime;
        [SerializeField]
        string highTime;

        public List<Employee> inRange;
        float startTime;
        float endTime;
        public override void Execute() {
            startTime = Time.realtimeSinceStartup;
            for(int i = 0; i < 10000; i++) {
                if(treeTask == null) {
                    Debug.LogError("TreeTask is not assigned in TreeSearchTask.");
                    return;
                }
                if(treeTask.root == null) {
                    Debug.LogError("The tree is empty. Run TreeTask first.");
                    return;
                }
                DateTime low = DateTime.Parse(lowTime);
                DateTime high = DateTime.Parse(highTime);
                if(low > high) {
                    DateTime temp = low;
                    low = high;
                    high = temp;
                }
                inRange = new List<Employee>();
                SearchRange(treeTask.root, low, high);

                //Debug.Log($"Tree search found {inRange.Count} employees between {low} and {high}.");
            }
            endTime = Time.realtimeSinceStartup;
            Debug.Log($"Tree search took {endTime - startTime} seconds");
        }
        void SearchRange(TreeNode node, DateTime low, DateTime high) {
            if(node == null) {
                return;
            }
            if(node.lastEntrance > low) {
                SearchRange(node.left, low, high);
            }
            if(node.lastEntrance >= low && node.lastEntrance <= high) {
                inRange.AddRange(node.sameTimeEmployees);
            }
            if(node.lastEntrance < high) {
                SearchRange(node.right, low, high);
            }
        }
    }
}
