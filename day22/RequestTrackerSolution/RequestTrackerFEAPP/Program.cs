using RequestTrackerBLLibrary;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System.Threading.Channels;

namespace RequestTrackerFEAPP
{
    internal class Program
    {
        private static Employee loggedInEmployee;
        async Task EmployeeLoginAsync(int username, string password)
        {
            Employee employee = new Employee() { Password = password,Id=username };
            IEmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();
            var result = await employeeLoginBL.Login(employee);
            if (result!=null)
            {
                await Console.Out.WriteLineAsync("Login Success");
            }
            else
            {
                Console.Out.WriteLine("Invalid username or password");
            }
        }
        async Task EmployeeRegisterAsync(int username, string password)
        {
            Employee employee = new Employee() { Password = password, Id = username };
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
            int id = await GetValidIntegerInput("Please enter Employee Id");
            string password = await GetValidStringInput("Please enter your password");
            await EmployeeRegisterAsync(id, password);
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

        static async Task Main(string[] args)
        {
            if (loggedInEmployee != null)
            {
                await new Program().EmployeeMenu();
            }
            else
            {
                await new Program().MainMenu();
            }
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
            IEmployeeRequestBL employeeRequestBL = new EmployeeRequestBL
                (new EmployeeRepository(new RequestTrackerContext()),
                new RequestRepository(new RequestTrackerContext()),
                new RequestSolutionRepository(new RequestTrackerContext()),
                new SolutionFeedbackRepository(new RequestTrackerContext()));
        }

        private async Task ViewRequestSolution()
        {
            throw new NotImplementedException();
        }
        private async Task ViewAllRequest()
        {
            throw new NotImplementedException();
        }

        async Task MainMenu()
        {
            while (true)
            {
                await DisplayMainMenu();
                int choice = await GetUserChoice(1, 3);
                switch (choice)
                {
                    case 1:
                        await GetLoginDeatils();
                        break;
                    case 2:
                        await GetRegisterDetails();
                        break;
                    case 3:
                        await Logout();
                        return;
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
