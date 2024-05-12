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
        static AdminBL adminBL = new AdminBL();
        static async Task Main(string[] args)
        {
            var program = new Program();
            await program.MainMenu();
        }

        // LOGIN
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
        //Register 
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

        // Get input for Register
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
            var result =await  employeeRequestBL.AddRequest(loggedInEmployee.Id, message);
            if (result != null)
            {
                await Console.Out.WriteLineAsync("Request added successfully");
                await Console.Out.WriteLineAsync(result.ToString());
            }
            else
            {
                await Console.Out.WriteLineAsync("Request failed");
            }
        }

        //private async Task ViewRequestSolution()
        //{
        //    int requestId = await GetValidIntegerInput("Enter Request Id To View Solution");
        //    List<RequestSolution> requestSolutions=await employeeRequestBL.GetAllRequestSolution(requestId);
        //    foreach(RequestSolution requestSolution in requestSolutions)
        //    {
        //        await Console.Out.WriteLineAsync(requestSolution.ToString());
        //    }
        //}
        private async Task ViewAllRequestByStatus()
        {
            string requestStatus = await GetValidStringInput("Enter Open/Closed to get corresponding requests ");
            var allRequestByStatus = await employeeRequestBL.GetAllRequestByStatus(loggedInEmployee.Id, requestStatus);
            foreach (var request in allRequestByStatus)
            {
                await Console.Out.WriteLineAsync(request.ToString());
            }
        }
        
        private async Task ViewAllRequest()
        {
            List<Request> requests = await employeeRequestBL.GetAllRequestForEmployeeById(loggedInEmployee.Id);
            foreach (Request request in requests)
            {
                await Console.Out.WriteLineAsync(request.ToString());
            }
        }


        private async Task AddRequestSolutionByAdmin()
        {
            await GetAllOpenRequestsByAdmin();
            int requestId = await GetValidIntegerInput("Enter the request id: ");
            string solutionDescription = await GetValidStringInput("Enter the solution description: ");
            var solution = await adminBL.AddSolutionByAdmin(requestId, solutionDescription, loggedInEmployee.Id);
            if (solution != null)
            {
                await Console.Out.WriteLineAsync("Solution added successfully");
                await Console.Out.WriteLineAsync(solution.ToString());
            }
            else
            {
                await Console.Out.WriteLineAsync("Solution failed");
            }
        }


        private async Task CloseRequestByAdmin()
        {
            await DisplayAllOpenAndAcceptedSolutionByEmployeeRequests();
            int requestId = await GetValidIntegerInput("Enter the request id: ");
            await adminBL.MarkRequestCloseByAdmin(requestId, loggedInEmployee.Id);
        }
        private async Task GetAllOpenRequestsByAdmin()
        {
            string requestStatus = "Open";
            var allRequests = await adminBL.GetAllRequestsByEmployeesByStatus(loggedInEmployee.Id, requestStatus);
            foreach (var request in allRequests)
            {
                await Console.Out.WriteLineAsync(request.ToString());
            }
        }
        private async Task DisplayAllOpenAndAcceptedSolutionByEmployeeRequests()
        {
            if (loggedInEmployee.Role != "Admin")
            {
                await Console.Out.WriteLineAsync("You are not authorized to perform this operation");
                return;
            }
            var allRequests = await adminBL.GetAllRequestsByEmployeesByStatus(loggedInEmployee.Id, "Open");
            var allRequestWithAcceptedSolutions = allRequests.SelectMany(e => e.RequestSolutions).Where(e => e.IsSolved == true);

            foreach (var request in allRequestWithAcceptedSolutions)
            {
                await Console.Out.WriteLineAsync(request.ToString());
            }
        }
        private async Task DisplayAllOpenedRequestOfEmployee()
        {
            var allRequests = await employeeRequestBL.GetAllRequestByStatus(loggedInEmployee.Id, "Open");
            foreach (var request in allRequests)
            {
                await Console.Out.WriteLineAsync(request.ToString());
            }
        }
        async Task ResponseToSolution()
        {
            int solutionId = await GetValidIntegerInput("Enter the solution id: ");
            string response = await GetValidStringInput("Enter your response: ");
            var solution = await employeeRequestBL.ResponseToSolution(solutionId, response);
            if (solution != null)
            {
                await Console.Out.WriteLineAsync("Response added successfully");
                await Console.Out.WriteLineAsync(solution.ToString());
            }
            else
            {
                await Console.Out.WriteLineAsync("Response failed");
            }
        }

        async Task AcceptSolution()
        {
            int solutionId = await GetValidIntegerInput("Enter the solution id: ");
            var solution = await employeeRequestBL.AcceptSolution(solutionId);
            if (solution != null)
            {
                await Console.Out.WriteLineAsync("Solution accepted successfully");
                await Console.Out.WriteLineAsync(solution.ToString());
            }
            else
            {
                await Console.Out.WriteLineAsync("Solution failed");
            }
        }
        private async Task ViewRequestSolution()
        {
            await DisplayAllOpenedRequestOfEmployee();
            int requestId = await GetValidIntegerInput("Enter the request id: ");
            var allNotAcceptedSolutions = await employeeRequestBL.GetAllRequestSolution(requestId);
            if(allNotAcceptedSolutions != null)
            {
                await Console.Out.WriteLineAsync("No Solution is given Until Now");
                return;
            }
            foreach (var request in allNotAcceptedSolutions)
            {
                await Console.Out.WriteLineAsync(request.ToString());
            }
            await EmployeeSolutionMenu();
            int choice = await GetUserChoice(0, 3);
            bool flag = false;
            while (!flag)
            {
                switch (choice)
                {
                    case 0:
                        flag = true;
                        break;
                    case 1:
                        await ResponseToSolution();
                        flag = true;
                        break;
                    case 2:
                        await AcceptSolution();
                        flag = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        async Task EmployeeSolutionMenu()
        {
            await Console.Out.WriteLineAsync("1. Reply to Request Solution");
            await Console.Out.WriteLineAsync("2. Accept Solution");
            await Console.Out.WriteLineAsync("0. Exit");
        }
        async Task DisplayAdminMenu()
        {
            await Console.Out.WriteLineAsync("5. Add Solution to Request");
            await Console.Out.WriteLineAsync("6. Close Request");
            
        }

        async Task DisplayEmployeeMenu()
        {
            //await Console.Out.WriteLineAsync(loggedInEmployee.ToString());
            await Console.Out.WriteLineAsync("0. Exit");
            await Console.Out.WriteLineAsync("1. Add Request");
            await Console.Out.WriteLineAsync("2. View All Request");
            await Console.Out.WriteLineAsync("3. View All Request By Status");
            await Console.Out.WriteLineAsync("4. View Request Solution");
            if (loggedInEmployee != null && loggedInEmployee.Role == "Admin")
            {
                await DisplayAdminMenu();
            }
        }
        
        async Task EmployeeMenu()
        {
            bool flag = true;
            while (flag)
            {
                await DisplayEmployeeMenu();
                int minChoice = 0;
                int maxChoice = loggedInEmployee != null && loggedInEmployee.Role == "Admin" ? 6 : 5;

                int choice = await GetUserChoice(minChoice, maxChoice);
                switch (choice)
                {
                    case 1:
                        await AddRequest();
                        break;
                    case 2:
                        await ViewAllRequest();
                        break;
                    case 3:
                        await ViewAllRequestByStatus();
                        break;
                    case 4:
                        await ViewRequestSolution();
                        break;

                    case 5:
                        await AddRequestSolutionByAdmin();
                        break;

                    case 6:
                        await CloseRequestByAdmin();
                        break;

                    case 0:
                        await Logout();
                        flag = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
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

        async Task MainMenu()
        {
            bool exit = false;
            while (!exit)
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
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
