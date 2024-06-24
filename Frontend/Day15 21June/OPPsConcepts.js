function employeeDetails(employeeName, employeeSalary) {
    this.employeeName = employeeName;
    this.employeeSalary = employeeSalary;
    this.displayEmployeeDetails = function() {
        return (`Employee Name: ${this.employeeName}, Employee Salary: ${this.employeeSalary}`);
    }
}
const firstEmployee = new employeeDetails('John', 10000);
console.log(typeof firstEmployee);
const secondEmployee = new employeeDetails('Doe', 20000);   

console.log(firstEmployee.displayEmployeeDetails());

console.log(secondEmployee.displayEmployeeDetails());

const firstEmployee1=Object.create(new employeeDetails('John', 10000));
console.log(firstEmployee1.employeeName);
