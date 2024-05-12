using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class EmployeeRequestBL : IEmployeeRequestBL
    {
        private readonly IRepository<int, Request> _requestRepository;
        private readonly IRepository<int, Employee> _employeeRepository;
        private readonly IRepository<int, RequestSolution> _requestSolutionRepository;
        private readonly IRepository<int,SolutionFeedback> _solutionFeedbackRepository;
        public EmployeeRequestBL()
        {
            _requestRepository = new RequestRepository(new RequestTrackerContext());
            _employeeRepository = new EmployeeRepository(new RequestTrackerContext());
            _requestSolutionRepository = new RequestSolutionRepository(new RequestTrackerContext());
            _solutionFeedbackRepository = new SolutionFeedbackRepository(new RequestTrackerContext());
        }
        public Task<Request> AddRequest(int EmployeeId, string RequestMessage)
        {
            
        }

        public Task<List<Request>> GetAllRequestForEmployeeById(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<RequestSolution>> GetAllRequestSolution(int requestId)
        {
            throw new NotImplementedException();
        }

        public Task<Request> GetRequestById(int requestId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRequestStatusById(int requestId)
        {
            throw new NotImplementedException();
        }

        public Task<RequestSolution> ResponseToSolution(int solutionId, string response)
        {
            throw new NotImplementedException();
        }
    }
}
