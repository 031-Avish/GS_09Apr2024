using RequestTrackerDataAccessLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerTest
{
    public class Tests
    {
        IRepository<int, Department> repository;
        [SetUp]
        public void Setup()
        {
            repository = new DepartmentRepository();
        }

        [Test]
        public void AddSuccessTest()
        {
            //Arrange 
            Department department = new Department() { Name = "IT", DepartmentHead = 101 };
            //Action
            var result = repository.Add(department);
            //Assert
            Assert.AreEqual(1, result.Id);
            //Assert.AreEqual(2, result.Id);
        }

        [Test]
        public void AddFailTest()
        {
            //Arrange 
            Department department = new Department() { Name = "IT", DepartmentHead = 101 };
            repository.Add(department);
            department = new Department() { Name = "IT", DepartmentHead = 102 };
            //Action
            var result = repository.Add(department);
            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetAllSuccessTest()
        {
            Department department = new Department() { Name = "IT", DepartmentHead = 101 };
            repository.Add(department);
            department = new Department() { Name = "HR", DepartmentHead = 102 };
            repository.Add(department);

            //Action

            List<Department> result = repository.GetAll();
            Assert.AreEqual(2, result.Count);
            
        }
        [Test]
        public void GetAllFailTest()
        {
            var result = repository.GetAll();
            Assert.IsNull(result);
        }

        [TestCase(1, "Hr", 101)]
        [TestCase(2, "Admin", 101)] 

        // this function will run 2 times for different test cases that is why id=2 will be null
        public void GetPassTest(int id, string name, int hid)
        {
            //Arrange 
            Department department = new Department() { Name = name, DepartmentHead = hid };
            repository.Add(department);

            //Action
            var result = repository.Get(id);
            //Assert
            Assert.IsNotNull(result);
        }
    }
}