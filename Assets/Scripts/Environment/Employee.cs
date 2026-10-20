using System;
using UnityEngine;

namespace Environment {
    [Serializable]
    public class Employee {
        public string name;
        public int employeeId;
        public bool hasEngineRoomClearance;
        public string lastEntranceInEngineRoom;
        public string lastExitFromEngineRoom;
    }
    [Serializable]
    public class EmployeeArray {
        public Employee[] employees;
    }
}
