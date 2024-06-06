using RequestTrackerDataAccessLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class EmployeeBL : IEmployeeService
    {
        readonly IRepository<int,Employee> _employeeRepository;

        public EmployeeBL()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public int AddEmployee(Employee employee)
        {
            var result = _employeeRepository.Add(employee);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateEmployeeIdException();
        }

        public Employee DeleteEmployeeByID(int employeeId)
        {
            Employee employee = _employeeRepository.Delete(employeeId);
            if(employee!=null)
            {
                return employee;
            }
            throw new EmployeeDoesNotExistException();
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = _employeeRepository.GetAll();
            if(employees!=null)
            {
                return employees;
            }
            throw new EmployeeDoesNotExistException();
        }

        public Department GetDepartmentByEmployeeId(int employeeId)
        {
            Employee employee=_employeeRepository.Get(employeeId);
            if(employee!=null)
            {
                return employee.Department;
            }
            throw new EmployeeDoesNotExistException();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            Employee employee= _employeeRepository.Get(employeeId);
            if(employee!=null)
            {
                return employee;
            }
            throw new EmployeeDoesNotExistException();
        }

        public string GetEmployeeName(int id)
        {
           Employee employee=_employeeRepository.Get(id);
           if(employee!=null)
            {
                return employee.Name;
            }
           throw new EmployeeDoesNotExistException();
        }

        public string GetEmployeeRole(int id)
        {
            Employee employee = _employeeRepository.Get(id);
            if (employee != null)
            {
                return employee.Role;
            }
            throw new EmployeeDoesNotExistException();
        }

        public List<Employee> GetEmployeesByEmployeeRole(string role)
        {
            List<Employee> employees =_employeeRepository.GetAll();

            List<Employee> employeeRoleList = new List<Employee>();
            if(employees!=null)
            {
                foreach (Employee employee in employees)
                {
                    if (employee.Role != role )
                    {
                        employeeRoleList.Add(employee);
                    }
                }
                return employeeRoleList;
            }
            throw new EmployeeDoesNotExistException();
            
        }

        public Employee UpdateEmployeeByName(string EmployeeOldName, string EmployeeNewName)
        {
            List<Employee> employees=_employeeRepository.GetAll();
            if(employees!=null)
            {
                foreach (Employee employee in employees)
                {
                    if (employee.Name != EmployeeOldName)
                    {
                        employee.Name = EmployeeOldName;
                        return employee;
                    }
                }

            }
            
            throw new EmployeeDoesNotExistException();

        }

        public Employee UpdateEmployeeSalaryById(int employeeId,double NewSalary)
        {
            Employee employee  = _employeeRepository.Get(employeeId);
            if(employee!=null)
            {
                employee.Salary = NewSalary;
            }
            throw new EmployeeDoesNotExistException();
        }
    }
}
