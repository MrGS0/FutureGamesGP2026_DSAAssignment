using System;
using UnityEngine;


namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Search Employees Task", menuName = "Search Employees Task")]
    public class SearchEmployeesTask : Task {
        [SerializeField]
        SortEmployeesTask SortEmployeesTask;
        [SerializeField]
        string lowTime;
        [SerializeField]
        string highTime;

        public Employee[] inRange;

        public override void Execute() {
            if(SortEmployeesTask == null) {
                Debug.LogError("SortEmployeesTask is not assigned in SearchEmployeesTask.");
                return;
            }
            if(SortEmployeesTask.sortedEmployees == null) {
                Debug.LogError("Sorted employee array is not available in SortEmployeesTask.");
                return;
            }
            Employee[] sortedEmployees = SortEmployeesTask.sortedEmployees;

            if(DateTime.Parse(lowTime) > DateTime.Parse(highTime)) {
                string temp = lowTime;
                lowTime = highTime;
                highTime = temp;
            }
            

            int lowTimeIndex = Search(lowTime, sortedEmployees);
            int highTimeIndex = Search(highTime, sortedEmployees);
            int inRangeSize;
            if(highTimeIndex - lowTimeIndex > 0) inRangeSize = highTimeIndex - lowTimeIndex;
            else inRangeSize = 0;
            inRange = new Employee[inRangeSize];
            GetEmployeesInRange(lowTimeIndex, highTimeIndex, sortedEmployees, inRange);

        }
        int Search(string time, Employee[] employees) {
            DateTime dateTime = DateTime.Parse(time);
            int bot = 0;
            int top = employees.Length;

            while(bot < top) {
                int mid = bot + (top - bot) / 2;
                if(GetDateTime(employees[mid]) >= dateTime) {
                    top = mid;
                }
                else {
                    bot = mid + 1;
                }
            }
            return bot;
        }

        void GetEmployeesInRange(int low, int high, Employee[] employees, Employee[] inRange) {
            for(int i = low; i < high; i++) {
               inRange[i - low] = employees[i];
            }
        }

        DateTime GetDateTime(Employee employee) {
            return DateTime.Parse(employee.lastEntranceInEngineRoom);
        }
    }
}
