using EmployeeRequestTrackerApp.Models.DTOs;
using EmployeeRequestTrackerApp.Models;

namespace EmployeeRequestTrackerApp.Interfaces
{
    public interface IUserService
    {
        public Task<Employee> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(EmployeeUserDTO employeeDTO);
    }
}
