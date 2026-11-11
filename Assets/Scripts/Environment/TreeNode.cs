using System;
using System.Collections.Generic;

namespace Environment {
    public class TreeNode {
        public DateTime lastEntrance;
        public List<Employee> sameTimeEmployees;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(DateTime lastEntrance, Employee employee) {
            this.lastEntrance = lastEntrance;
            this.sameTimeEmployees = new List<Employee>();
            this.sameTimeEmployees.Add(employee);
        }
    }
}
