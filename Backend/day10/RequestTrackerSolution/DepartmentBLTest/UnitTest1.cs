using RequestTrackerBLLibrary;
using RequestTrackerDataAccessLibrary;
using RequestTrackerModelLibrary;

namespace DepartmentBLTest
{
    public class Tests
    {
        IRepository<int, Department> repository;
        IDepartmentService departmentService;
        [SetUp]
        public void Setup()
        {
            repository = new DepartmentRepository();
            Department department = new Department() { Name = "IT", DepartmentHead = 101 };
            repository.Add(department);
            departmentService = new DepartmentBL(repository);
        }

        [Test]
        public void GetDepartmentByNamePassTest()
        {
            //Action
            var department = departmentService.GetDepartmentByName("IT");

            Assert.AreEqual(1,department.Id);
        }
        [Test]
        public void GetDepartmentByNameFailTest()
        {
            //var department = departmentService.GetDepartmentByName("HR");
            var exception = Assert.Throws<DepartmentDoesNotExistException>(()=> departmentService.GetDepartmentByName("ITI"));
            Assert.AreEqual("Department does not exists ", exception.Message);
        }
    }
}