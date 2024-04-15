using ReqTrackerModelLibbrary;
using System.Xml.Linq;

namespace ReqTrackerApp
{
    internal class Program
    {
        //void UnderstandingSequenceStatements () {
        //    Console.WriteLine("hello");
        //    Console.WriteLine("hi");
        //    int num1, num2;
        //    num1 = 10; num2=20;
        //    int num3 = num1 / num2;
        //    Console.WriteLine($"The result of {num1} divided by {num2} is {num3}");
        //}
        //void UnderstandingSelectionWithIf()
        //{
        //    string strName = "ramu";
        //    if (strName == "ramu")
        //        Console.WriteLine("Welcome Ramu , you are authorised");
        //    else if (strName == "sonu")
        //        Console.WriteLine("Welcome Sonu , you have limited access");
        //    else
        //        Console.WriteLine("sorry I don't know you");

        //}
        //void UnderstandingSwitchCase()
        //{
        //    int choice = 8;

        //    switch (choice)
        //    {
        //        case 1: Console.WriteLine("Monday");
        //            break;
        //        case 2: Console.WriteLine("Tueseday");
        //            break;
        //        case 3: Console.WriteLine("wednesday");
        //            break;
        //        case 4: Console.WriteLine("Thrusday");
        //            break;
        //        case 5: Console.WriteLine("Friday");
        //            break;
        //        case 6: 
        //        case 7: Console.WriteLine("Weekends");
        //            break;
        //        default: Console.WriteLine("Not a valid number");
        //            break;
        //    }
        //}
        //void UnderstandIterationWithFor()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine("hello" + i );
        //    }
        //}
        //void UnderstandingIterationWithWhile()
        //{
        //    int count = 9;
        //    while(count > 4) {
        //        count--;
        //        if (count == 7)
        //            continue;
        //        Console.WriteLine("The value of count is " + count);
        //        if (count == 5)
        //            break;
        //    }
        //}
        //void UnderstandingIterationWithDoWhile()
        //{
        //    int count = 0;
        //    do
        //    {
        //        Console.WriteLine("IN DO WHILE " + count);
        //        count++;
        //    } while (count > 3);
        //}

        //void UnderstangingArray()
        //{
        //    int[] number = { 1, 2, 20, 40, 50, 80, 123, 23 };
        //    int countOfRepeatingNumbers = 0;
        //    for (int i = 0;i < number.Length;i++)
        //    {
        //        if (number[i] >= 10 && number[i] < 100)
        //        {
        //            int oncePlace = number[i] % 10;
        //            int tensPlace = number[i] / 10;
        //            if (oncePlace == tensPlace)
        //                countOfRepeatingNumbers++;
        //        }
        //    }
        //    Console.WriteLine("the number of repeating number is " + countOfRepeatingNumbers);
        //}

        //void ChallangeQuestion()
        //{

        //    int[] number = { 1, 2, 20, 40, 50, 80, 123,180, 23,111,222,333 };
        //    int countOfRepeatingNumbers = 0;
        //    for (int i = 0; i < number.Length; i++)
        //    {
        //        if (number[i] >= 100 && number[i] < 1000)
        //        {
        //            int oncePlace = number[i] % 10;
        //            int tensPlace= (number[i] / 10 )%10;
        //            int hundredPlace = number[i] / 100;

        //            if (oncePlace == tensPlace && tensPlace==hundredPlace)
        //                countOfRepeatingNumbers++;
        //        }
        //    }
        //    Console.WriteLine("the number of repeating number is " + countOfRepeatingNumbers);
        //}

        Employee[] employees;
        int count = 0;

        /// <summary>
        /// constructor to give the size of array 
        /// </summary>
        public Program() {
            employees=new Employee[3];
        }

        /// <summary>
        /// to create the Employee object based on id 
        /// </summary>
        /// <param name="id"> id of employee</param>
        /// <returns>the object of employee </returns>
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            Console.WriteLine("-------------------------------");
            return employee;
        }

        /// <summary>
        /// Print the options for user , what he want to perform
        /// </summary>
        void PrintMenu()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Search By Id");
            Console.WriteLine("4. Update Employee By Name");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("0. Exit");

        }

        /// <summary>
        /// call function based on user choice , having switch case statments
        /// </summary>
        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        SearchAndPrintEmployee();
                        break;
                    case 4:
                        UpdateEmployee();
                        break;
                    case 5:
                        DeleteEmployee();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }


        /// <summary>
        /// function to get the Employee id from user 
        /// </summary>
        /// <returns> the id of employee </returns>
        int GetIdFromUser()
        {
            int id = 0;
            Console.WriteLine("please enter the Employee id");
            while(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid Entry ! try again ");
            }
            return id;  
        }

        /// <summary>
        /// Function to add the employee
        /// </summary>
        void AddEmployee()
        {
            if (employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(i);
                    count++;
                }
            }
        }

        /// <summary>
        /// Search a employee by its id and then delete that user if he us found  
        /// </summary>
        /// <param name="id">id of employee </param>
        /// <returns> true or false based on found or not </returns>
        bool SearchEmployeeByIdAndDelete(int id)
        {
            
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && employees[i].Id == id)
                {
                    employees[i] = null;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// to delete the employee based in user given id 
        /// </summary>
        void DeleteEmployee()
        {
            int id = GetIdFromUser();
            bool deleted= SearchEmployeeByIdAndDelete(id);
            if (deleted)
            {
                Console.WriteLine("Employee Deleted Successfully ");
                count--;
                PrintAllEmployees();
                return;
            }
            Console.WriteLine("No employee found with given id");
        }

        /// <summary>
        /// to print all the available employees
        /// </summary>

        void PrintAllEmployees()
        {
            if (count == 0)
            {
                Console.WriteLine("No Employees available");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                    PrintEmployee(employees[i]);
            }
        }


        /// <summary>
        /// Print a single employee by taking object as a parameter
        /// </summary>
        /// <param name="employee"> object of a employee </param>
        void PrintEmployee(Employee employee)
        {
            employee.PrintEmployeeDetails();
        }

        /// <summary>
        /// Search the employee and print that employee based on id
        /// </summary>

        void SearchAndPrintEmployee()
        {
            int id = GetIdFromUser();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No employee Found");
                return;
            }
            PrintEmployee(employee);
        }

        /// <summary>
        /// fuction to search employee by his id 
        /// </summary>
        /// <param name="id"> id of employee</param>
        /// <returns>the employee object for given id or a null object </returns>

        Employee SearchEmployeeById(int id)
        {
            Employee employee=null;
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i]!=null && employees[i].Id == id)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }

        /// <summary>
        /// to get the employee name form user to edit his name 
        /// </summary>
        /// <returns>Return the updated name of employee </returns>
        string GetEmployeeName()
        {
            Console.WriteLine("Enter the Updated Name ");
            string newName = Console.ReadLine() ?? String.Empty;
            while(string.IsNullOrEmpty(newName))
            {
                Console.WriteLine("Name can't be empty !! Enter Again");
                newName = Console.ReadLine() ?? String.Empty;
            }
            return newName;
        }

        /// <summary>
        /// update the name of employee , helper function for UpdateEmployee()
        /// </summary>
        /// <param name="employee">employee object whom you have to undate</param>
        void UpdateEmployeeName(Employee employee)
        {
            string newName = GetEmployeeName();
            employee.Name=newName;
            Console.WriteLine("Employee name updated successfully");
        }

        /// <summary>
        /// for updating the employee based on employee Id and updated name 
        /// </summary>
        void UpdateEmployee()
        {
            int id =GetIdFromUser();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No employee Found");
                return;
            }
            UpdateEmployeeName(employee);
            PrintEmployee(employee);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.UnderstandingSequenceStatements();
            //program.UnderstandingSelectionWithIf();
            //program.UnderstandingSwitchCase();
            //program.UnderstandIterationWithFor();
            //program.UnderstandingIterationWithWhile();
            //program.UnderstandingIterationWithDoWhile();
            //program.ChallangeQuestion();
            //Console.WriteLine("Hello, World!");

            program.EmployeeInteraction();
        }
    }
}
