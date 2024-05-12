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

        public async Task<RequestSolution> AcceptSolution(int solutionId)
        {
            try
            {
                var solution = await _requestSolutionRepository.GetByKey(solutionId);
                if (solution == null)
                    throw new Exception("No Solution found ");
                solution.IsSolved = true;
                await _requestSolutionRepository.Update(solution);
                return solution;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while Accepting solution");
            }
        }

        public async Task<Request> AddRequest(int EmployeeId, string RequestMessage)
        {
            Employee employee =await _employeeRepository.GetByKey(EmployeeId);
            if (employee !=null)
            {
                Request request = new Request(RequestMessage,EmployeeId);
                await _requestRepository.Add(request);
                return request;
            }
            throw new Exception("No such employee");
        }

        public async Task<IList<Request>> GetAllRequestByStatus(int employeeId, string status)
        {
            var requests = await _requestRepository.GetAll();
            return requests.Where(e => e.RequestRaisedBy == employeeId && e.RequestStatus == status).ToList();
        }

        public async Task<List<Request>> GetAllRequestForEmployeeById(int employeeId)
        {
            try
            {
                var requests = await _requestRepository.GetAll();
                return requests.Where(e => e.RequestRaisedBy == employeeId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get all Requests");
            }

        }

        public async Task<List<RequestSolution>> GetAllRequestSolution(int requestId)
        {
            var solutions =await _requestSolutionRepository.GetAll();
            return solutions.Where(s=>s.RequestId == requestId).ToList();
        }

        public async Task<Request> GetRequestById(int requestId)
        {
            var request=await _requestRepository.GetByKey(requestId);
            return request;
        }

        public async Task<string> GetRequestStatusById(int requestId)
        {
            var request = await _requestRepository.GetByKey(requestId);
            return request.RequestStatus;
        }

        public async Task<RequestSolution> ResponseToSolution(int solutionId, string response)
        {
            var solutions=await _requestSolutionRepository.GetByKey(solutionId);
            solutions.RequestRaiserComment=response;
            await _requestSolutionRepository.Update(solutions);
            return solutions;
        }
    }
}
