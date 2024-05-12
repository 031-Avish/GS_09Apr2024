using RequestTrackerBLLibrary;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System.Threading.Channels;

namespace RequestTrackerFEAPP
{
    internal class Program
    {
        private static Employee loggedInEmployee=null;
        static EmployeeRequestBL employeeRequestBL = new EmployeeRequestBL();
        static async Task Main(string[] args)
        {
            var program = new Program();
            await program.MainMenu();
        }
        async Task EmployeeLoginAsync(int username, string password)
        {
            Employee employee = new Employee() { Password = password,Id=username };
            IEmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();
            var result = await employeeLoginBL.Login(employee);
            if (result!=null)
            {
                await Console.Out.WriteLineAsync("Login Success");
                await Console.Out.WriteLineAsync(result.ToString());
                loggedInEmployee = result; }
            else
            {
                Console.Out.WriteLine("Invalid username or password");
            }
        }
        async Task EmployeeRegisterAsync(string name, string password, string role)
        {
            Employee employee = new Employee() { Name =name, Password=password, Role=role };
            IEmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();
            var result = await employeeLoginBL.Register(employee);
            if (result != null)
            {
                loggedInEmployee = result;
                await Console.Out.WriteLineAsync("Registration Success");
            }
            else
            {
                await Console.Out.WriteLineAsync("Registration Failed");
            }
        }
        async Task GetRegisterDetails()
        {
            string name = await GetValidStringInput("Please enter Employee Name");
            string password = await GetValidStringInput("Please enter your password");
            string role = await GetValidStringInput("Please Enter Role");
            await EmployeeRegisterAsync(name,password,role);
        }
        async Task Logout()
        {
            loggedInEmployee = null;
        }
        async Task GetLoginDeatils()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            await EmployeeLoginAsync(id,password);
        }

        

        async Task EmployeeMenu()
        {
            while (true)
            {
                await DisplayEmployeeMenu();
                int choice = await GetUserChoice(0, 4);
                switch (choice)
                {
                    case 1:
                        await AddRequest();
                        break;
                    case 2:
                        await ViewAllRequest();
                        break;
                    case 3:
                        await ViewRequestSolution();
                        break;
                    case 0:
                        await Logout();
                        return;
                }
            }
        }
        async Task DisplayAdminMenu()
        {
            await Console.Out.WriteLineAsync("5. Add Solution to Request");
            await Console.Out.WriteLineAsync("6. Close Request");
        }
        async Task DisplayEmployeeMenu()
        {
            await Console.Out.WriteLineAsync("1. Add Request");
            await Console.Out.WriteLineAsync("2. View All Request");
            await Console.Out.WriteLineAsync("3. View Request Solution");
            await Console.Out.WriteLineAsync("4. Reply to Request Solution");
            await Console.Out.WriteLineAsync("0. Exit");
            await Console.Out.WriteLineAsync(loggedInEmployee.Name);
            await Console.Out.WriteLineAsync(loggedInEmployee.Role);
            if (loggedInEmployee != null && loggedInEmployee.Role == "Admin")
            {
                await DisplayAdminMenu();
            }
        }
        public async Task<int> GetUserChoice(int minChoice, int maxChoice)
        {
            int choice;
            while (true)
            {
                await Console.Out.WriteAsync("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < minChoice || choice > maxChoice)
                {
                    await Console.Out.WriteLineAsync($"Invalid input! Please enter a number between {minChoice} and {maxChoice}.");
                }
                else
                {
                    break;
                }
            }
            return choice;
        }
        public async Task<int> GetValidIntegerInput(string prompt)
        {
            int result;
            bool isValidInput = false;
            do
            {
                await Console.Out.WriteAsync(prompt);
                string userInput = Console.ReadLine();

                isValidInput = int.TryParse(userInput, out result);

                if (!isValidInput)
                {
                    await Console.Out.WriteLineAsync("Invalid input. Please enter a valid integer.");
                }
            } while (!isValidInput);

            return result;
        }

        public async Task<string> GetValidStringInput(string prompt)
        {
            string userInput;

            do
            {
                await Console.Out.WriteAsync(prompt);
                userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    await Console.Out.WriteLineAsync("Invalid input. Please enter a non-empty string.");
                }
            } while (string.IsNullOrWhiteSpace(userInput));

            return userInput;
        }
        private async Task AddRequest()
        {
            //EmployeeRequestBL employeeRequestBL = new EmployeeRequestBL();
            string message = await GetValidStringInput("Please Enter Your Message");
            await  employeeRequestBL.AddRequest(loggedInEmployee.Id, message);
        }

        private async Task ViewRequestSolution()
        {
            throw new NotImplementedException();
        }
        private async Task ViewAllRequest()
        {
            List<Request> requests = await employeeRequestBL.GetAllRequestForEmployeeById(loggedInEmployee.Id);
            foreach (Request request in requests)
            {
                await Console.Out.WriteLineAsync(request.ToString());
            }

        }

        async Task MainMenu()
        {
            bool flag = true;
            while (flag)
            {
                await DisplayMainMenu();
                int choice = await GetUserChoice(1, 3);
                switch (choice)
                {
                    case 1:
                        await GetLoginDeatils();
                        if (loggedInEmployee != null)
                        {
                            await EmployeeMenu();
                        }
                        break;
                    case 2:
                        await GetRegisterDetails();
                        if (loggedInEmployee != null)
                        {
                            await EmployeeMenu();
                        }
                        break;
                    case 3:
                        await Logout();
                        flag = false;
                        break;
                    default:
                        await Console.Out.WriteLineAsync("Wrong Choice Try Again");
                        break;
                }
            }
        }
        async Task DisplayMainMenu()
        {
            await Console.Out.WriteLineAsync("1. Login");
            await Console.Out.WriteLineAsync("2. Register");
            await Console.Out.WriteLineAsync("3. Exit");
        }


    }
}
