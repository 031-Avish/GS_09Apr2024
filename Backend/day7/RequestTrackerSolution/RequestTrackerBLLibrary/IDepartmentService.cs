using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IDepartmentService
    {
        bool AddDepartment(Department department);
        Department ChangeDepartmentName(string departmentOldName, string departmentNewName);
        Department GetDepartmentById(string departmentName);
        Department GetDepartmentByName(string departmentName);
        int GetDepartmentHeadId(int departmentId);

    }
}
