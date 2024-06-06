using ReqTrackerModelLibrary;

namespace ReqTrackerModelLibbrary
{
    public class Employee : IClientInteraction , IInternalCompanyWorking
    {
        public Department Department { get; set; }

        int age;
        DateTime dob;

        /// <summary>
        /// to get and set the Employee Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// to get and set the Employee Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// to get Employee Age
        /// </summary>
        public int Age
        {
            get
            {
                return age;
            }
        }

        /// <summary>
        /// To get the dob anf to set dob and age based on dob 
        /// </summary>

        public DateTime DateOfBirth { 
            get
            {
                return dob;
            }
            set
            {
                dob = value;
                age = (DateTime.Today - dob).Days / 365;

            }
        }

        /// <summary>
        /// To get and set the Salary 
        /// </summary>
        public double Salary { get; set; }

        public string Type {  get; set; }
        /// <summary>
        ///  default constructor to initialize with empty values 
        /// </summary>
        public Employee()
        {
            Console.WriteLine("Employee Class Default constructor");
            Id = 0;
            Name = string.Empty;
            Salary = 0.0;
            DateOfBirth = new DateTime();
            Type = string.Empty;
        }

        /// <summary>
        /// Constructor to initialize user with all values 
        /// </summary>
        /// <param name="id">Id of Epmloyee in int </param>
        /// <param name="name">Name of Emoloyee in String</param>
        /// <param name="dateOfBirth">Date of birth of Employee in DateTime </param>
        /// <param name="salary"> salary of employee in Double </param>

        public Employee(int id, string name, DateTime dateOfBirth)
        {
            Console.WriteLine("Inside employee parameterized constructor");
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        /// <summary>
        /// fun to take input from user and set to the employee object 
        /// </summary>

        public virtual void BuildEmployeeFromConsole()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Enter Employee Name");
            Name = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please enter Employee Dob");
            DateOfBirth=Convert.ToDateTime(Console.ReadLine());
            //Console.WriteLine("Enter Employee Basic Salary");
            //Salary=Convert.ToDouble(Console.ReadLine());
        }
        
        /// <summary>
        /// to print the detail of a employee 
        /// </summary>
        public virtual void PrintEmployeeDetails()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Employee Type : " + Type);
            Console.WriteLine("Employee Id " + Id);
            Console.WriteLine("Employee Name " + Name);
            Console.WriteLine("Date of Birth "+ DateOfBirth);
            Console.WriteLine("Employee Age " + Age);
            //Console.WriteLine("Employee Salary : Rs. " + Salary);
        }
        public override string ToString()
        {
            return "Employee Type : " + Type
          + "\nEmployee Id : " + Id
          + "\nEmployee Name " + Name
          + "\nDate of birth : " + DateOfBirth
          + "\nEmployee Age : " + Age;

        }

        public void GetOrder()
        {
            Console.WriteLine("Order fetched by " + Name);
        }

        public void GetPayment()
        {
            Console.WriteLine("Get the payment as per terms");
        }

        public void RaiseRequest()
        {
            throw new NotImplementedException();
        }

        public void CloseRequest()
        {
            throw new NotImplementedException();
        }
    }

}
