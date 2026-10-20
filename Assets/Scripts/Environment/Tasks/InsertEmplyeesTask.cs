using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Insert Employees Task", menuName = "Insert Employees Task")]
    public class InsertEmployeesTask : Task {
        [SerializeField]
        ReadEmployeesTask readEmployeesTask;
        public Employee[] employees;

        public override void Execute()
            {
                if(readEmployeesTask == null) {
                    Debug.LogError("ReadEmployeesTask is not assigned in InsertEmployeesTask.");
                    return;
                }
                if(readEmployeesTask.employeeArray == null || readEmployeesTask.employeeArray.employees == null) {
                    Debug.LogError("Employee array is not available in ReadEmployeesTask.");
                    return; 
                }
                Employee[] source = readEmployeesTask.employeeArray.employees;
                employees = new Employee[source.Length];
                for(int i = 0; i < source.Length; i++) {
                    employees[i] = source[i];
                    Debug.Log($"Inserted Employee: {employees[i].name}, ID: {employees[i].employeeId}, Engine Room Clearance: {employees[i].hasEngineRoomClearance}");
                }
                Debug.Log($"Inserted {employees.Length} employees into the InsertEmployeesTask.");
            }
        }
    }

