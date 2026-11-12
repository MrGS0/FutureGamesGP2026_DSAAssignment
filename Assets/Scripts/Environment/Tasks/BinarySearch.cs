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
        float startTime;
        float endTime;
        public Employee[] inRange;

        public override void Execute() {
            startTime = Time.realtimeSinceStartup;
            for(int i = 0; i < 10000; i++) {
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


                int lowTimeIndex = Search(lowTime, sortedEmployees, false);
                int highTimeIndex = Search(highTime, sortedEmployees, true);
                int inRangeSize;

                if(highTimeIndex - lowTimeIndex > 0) inRangeSize = highTimeIndex - lowTimeIndex;
                else inRangeSize = 0;

                inRange = new Employee[inRangeSize];
                GetEmployeesInRange(lowTimeIndex, highTimeIndex, sortedEmployees, inRange);
            }
            endTime = Time.realtimeSinceStartup;
            Debug.Log((endTime -= startTime));
        }
        int Search(string time, Employee[] employees, bool striclyAfter) { 
            DateTime dateTime = DateTime.Parse(time);
            int bot = 0;
            int top = employees.Length;

            while(bot < top) {  
                int mid = bot + (top - bot) / 2;
                if(ShouldSearchLeft(employees[mid], dateTime, striclyAfter)) {//employeeDateTime > or >= dateTime
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
               // Debug.Log($"Employee {employees[i].name} is in range with last entrance at {employees[i].lastEntranceInEngineRoom}");
            }
        }

        bool ShouldSearchLeft(Employee employee, DateTime dateTime, bool striclyAfter) {
            DateTime employeeDateTime = GetDateTime(employee);
            if(striclyAfter) {
                return employeeDateTime > dateTime;
            }
            else {
                return employeeDateTime >= dateTime;
            }
        }

        DateTime GetDateTime(Employee employee) {
            return DateTime.Parse(employee.lastEntranceInEngineRoom);
        }
    }
}
