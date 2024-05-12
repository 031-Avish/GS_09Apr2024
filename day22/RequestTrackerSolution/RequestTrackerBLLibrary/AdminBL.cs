using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class AdminBL : IAdminBL
    {

        private readonly IRepository<int, Request> _requestRepository;
        private readonly IRepository<int, Employee> _employeeRepository;
        private readonly IRepository<int, RequestSolution> _requestSolutionRepository;
        private readonly IRepository<int, SolutionFeedback> _solutionFeedbackRepository;
        public AdminBL()
        {
            _requestRepository = new RequestRepository(new RequestTrackerContext());
            _employeeRepository = new EmployeeRepository(new RequestTrackerContext());
            _requestSolutionRepository = new RequestSolutionRepository(new RequestTrackerContext());
            _solutionFeedbackRepository = new SolutionFeedbackRepository(new RequestTrackerContext());
        }

        private async Task<bool> IsAdmin(int adminId)
        {
            Employee employee = await _employeeRepository.GetByKey(adminId);
            if (employee==null || employee.Role != "Admin")
            {
                return false;
            }
            return true;
        }
        public async Task<RequestSolution> AddSolutionByAdmin(int requestId, string solutionDesc, int adminId)
        {
            try
            {
                if (await IsAdmin(adminId) == false)
                {
                    throw new Exception("User is not admin");
                }
                Request request = await _requestRepository.GetByKey(requestId);
                if (request == null)
                {
                    throw new Exception("Request Not found");
                }
                try
                {
                    RequestSolution requestSolution = new RequestSolution(requestId, solutionDesc, adminId);
                    await _requestSolutionRepository.Add(requestSolution);
                    return requestSolution;
                }
                catch (Exception ex)
                {
                    throw new Exception("error while adding the solution");
                }
            }
            catch(Exception ex) {
                throw new Exception("error in AddSolutionById");
            }
        }


        public async Task<IList<Request>> GetAllRequestsByEmployeesByStatus(int adminId, string status)
        {
            try
            {
                if (await IsAdmin(adminId) == false)
                {
                    throw new Exception("User is not admin");
                }
                var requests = await _requestRepository.GetAll();
                if (requests == null)
                {
                    throw new Exception("Request Not Found");
                }
                var openRequests = requests.Where(e => e.RequestStatus == status).ToList();
                return openRequests;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting data"+ ex.Message);
            }
        }

        public async Task<bool> MarkRequestCloseByAdmin(int requestId,int adminId)
        {
            if (await IsAdmin(adminId) == false)
            {
                throw new Exception("User is not admin");
            }
            var request = await _requestRepository.GetByKey(requestId);
            if (request == null)
            {
                throw new Exception("Request not found");
            }

            var admin = await _employeeRepository.GetByKey(adminId);
            request.ClosedDate = DateTime.Now;
            request.RequestClosedBy = admin.Id;
            request.RequestStatus = "Closed";
            var _savedRequest = await _requestRepository.Update(request);
            if (_savedRequest == null)
            {
                throw new Exception("Unable to update request");
            }
            return true;
        }

        public async Task<IList<Request>> GetAllRequestsByAdmin(int adminId)
        {
            if (await IsAdmin(adminId) == false)
            {
                throw new Exception("User is not admin");
            }
            try
            {
                var requests = await _requestRepository.GetAll();
                if (requests == null)
                {
                    throw new Exception("Request Not Found");
                }
                return requests;
            }
            catch(Exception ex)
            {
                throw new Exception("error in getting data");
            }
        }
    }
}
