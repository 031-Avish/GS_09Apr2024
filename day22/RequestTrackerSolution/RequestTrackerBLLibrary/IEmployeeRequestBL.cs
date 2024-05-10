using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeRequestBL
    {
        public Task<Request> AddRequest(int EmployeeId, string RequestMessage);
        //public Task<Request> CloseRequest(int requestId);
        public Task<Request> GetRequestById(int requestId);
        public Task<string> GetRequestStatusById(int requestId);
        public Task<List<Request>> GetAllRequestForEmployeeById(int employeeId);
        public Task<List<RequestSolution>> GetAllRequestSolution(int requestId);
        public Task<RequestSolution> ResponseToSolution(int solutionId,string response); 
    }
}
