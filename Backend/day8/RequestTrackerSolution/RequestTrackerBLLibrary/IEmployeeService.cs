using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public  interface IEmployeeService
    {
        int AddEmployee(Employee employee);

        Employee GetEmployeeById(int employeeId);

        List<Employee> GetAllEmployees();

        List<Employee> GetEmployeesByEmployeeRole(string role);
        Department GetDepartmentByEmployeeId(int employeeId);

        Employee DeleteEmployeeByID(int employeeId);
        Employee UpdateEmployeeByName(string EmployeeOldName,string EmployeeNewName);
        string GetEmployeeName(int id);
        string GetEmployeeRole(int id);

        Employee UpdateEmployeeSalaryById(int employeeId, double NewSalary);
    }
}