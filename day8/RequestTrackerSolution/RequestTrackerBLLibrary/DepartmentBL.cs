
using RequestTrackerDataAccessLibrary;
using RequestTrackerModelLibrary;


namespace RequestTrackerBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public int AddDepartment(Department department)
        {
            var result = _departmentRepository.Add(department);

            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateDepartmentNameException();
        }

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            // first get all department and then check if any department with this name exists 
            List<Department> departments=_departmentRepository.GetAll();
            if(departments!=null)
            {
                foreach (Department department in departments )
                {
                    if (department.Name == departmentOldName)
                    {
                        department.Name = departmentNewName;
                        return department;
                    }
                }
            }
           
            throw new DepartmentDoesNotExistException();
        }

        public Department GetDepartmentById(int id)
        {
            Department department = _departmentRepository.Get(id);
            if (department != null)
            {
                return department;
            }
            throw new DepartmentDoesNotExistException();
        }

        public Department GetDepartmentByName(string departmentName)
        {
            List<Department> departments = _departmentRepository.GetAll();
            if (departments!=null)
            {
                foreach (Department department in departments)
                {
                    if (department.Name == departmentName)
                    {
                        return department;
                    }
                }
            }
            throw new DepartmentDoesNotExistException();
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            Department  department=_departmentRepository.Get(departmentId);
            if (department != null)
            {
                return department.DepartmentHead;
            }
            throw new DepartmentDoesNotExistException();
        }

        public List<Department> GetDepartmentList()
        {
            List<Department> departments = _departmentRepository.GetAll();
            if(departments!=null)
            {
                return departments;
            }
            throw new DepartmentDoesNotExistException();

        }
    }
}