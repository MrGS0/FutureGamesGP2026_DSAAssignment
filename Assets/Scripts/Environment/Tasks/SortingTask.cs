using System;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Sort Employees Task", menuName = "Sort Employees Task")]
    public class SortEmployeesTask : Task {
        [SerializeField]
        InsertEmployeesTask insertEmployeesTask;
        public Employee[] sortedEmployees;
        public override void Execute() {
            if(insertEmployeesTask == null) {
                Debug.LogError("InsertEmployeesTask is not assigned in SortEmployeesTask.");
                return;
            }
            if(insertEmployeesTask.employees == null) {
                Debug.LogError("Employee array is not available in InsertEmployeesTask.");
                return;
            }
            Employee[] source = insertEmployeesTask.employees;
            sortedEmployees = new Employee[source.Length];
            for(int i = 0; i < source.Length; i++) {
                sortedEmployees[i] = source[i]; 
            }
            QuickSort(sortedEmployees, 0, sortedEmployees.Length - 1);
        }
        DateTime GetDateTime(Employee employee) {
            return DateTime.Parse(employee.lastEntranceInEngineRoom);
        }

        void QuickSort(Employee[] arr, int low, int high) {
            if(low < high) {
                int pivotIndex = Partition(arr, low, high);
                QuickSort(arr, low, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, high);
            }
        }
        int Partition(Employee[] arr, int low, int high) {
            int random = UnityEngine.Random.Range(low, high + 1);
            Swap(arr, random, high);

            Employee pivot = arr[high];
            int i = low - 1;
            for(int j = low; j < high; j++) {

                if(GetDateTime(arr[j]) <= GetDateTime(pivot)) {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, high);
            return i + 1;
        }
        void Swap(Employee[] arr, int a, int b) {
            Employee temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
