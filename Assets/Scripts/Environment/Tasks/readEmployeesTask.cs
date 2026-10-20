using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Read Employees Task", menuName = "Read Employees Task")]
    public class ReadEmployeesTask : Task {
        [SerializeField]
        private TextAsset textFile;
        public EmployeeArray employeeArray;
        public override void Execute() {
            if(textFile == null) {
                Debug.LogError("Text file is not assigned in ReadEmployeesTask.");
                return;
            }
            employeeArray = JsonUtility.FromJson<EmployeeArray>(textFile.text);
            if(employeeArray == null || employeeArray.employees == null) {
                Debug.LogError("Failed to parse employee data from the text file.");
                return;
            }
            Debug.Log($"Successfully read {employeeArray.employees.Length} employees from the text file.");
        }
    }
}
