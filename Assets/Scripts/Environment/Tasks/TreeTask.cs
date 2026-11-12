using System;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Tree Task", menuName = "Tree Task")]
    public class TreeTask : Task {
        [SerializeField]
        InsertEmployeesTask insertEmployeesTask;
        public TreeNode root;
        int nodeCount;
        public override void Execute() {
            if(insertEmployeesTask == null) {
                Debug.LogError("InsertEmployeesTask is not assigned in TreeTask.");
                return;
            }
            if(insertEmployeesTask.employees == null) {
                Debug.LogError("Employee array is not available in InsertEmployeesTask.");
                return;
            }

            root = null;
            nodeCount = 0;
            Employee[] employees = insertEmployeesTask.employees;
            for(int i = 0; i < employees.Length; i++) {
                DateTime time = DateTime.Parse(employees[i].lastEntranceInEngineRoom);
                Insert(time, employees[i]);
            }
            Debug.Log($"Tree built: {employees.Length} employees in {nodeCount} nodes.");
        }
            void Insert(DateTime time, Employee employee) {
                if(root == null) {
                    root = new TreeNode(time, employee);
                    nodeCount++;
                    return;
                }

                TreeNode current = root;
                while(true) {

                    if(time == current.lastEntrance) {
                        current.sameTimeEmployees.Add(employee);
                    return;
                    }
                    if(time < current.lastEntrance) {
                        if(current.left == null) {
                            current.left = new TreeNode(time, employee);
                        nodeCount++;
                        return;
                        }
                        current = current.left;
                    } else {
                        if(current.right == null) {
                            current.right = new TreeNode(time, employee);
                        nodeCount++;
                        return;
                        }
                        current = current.right;
                    }

                }

        }
    }
}
