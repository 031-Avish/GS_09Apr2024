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
        private readonly IRepository<int, Request> _repository;

        public EmployeeRequestBL()
        {
            IRepository<int, Employee> repo = new EmployeeRequestRepository(new RequestTrackerContext());
            
        }
        public Task<Request> AddRequest(int EmployeeId, string RequestMessage)
        {
            throw new NotImplementedException();
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
