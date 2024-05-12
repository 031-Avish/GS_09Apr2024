using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IAdminBL
    {
         //Provide Solution
        public Task<RequestSolution> AddSolutionByAdmin(int requestId, String SolutionDesc,int adminId);
        public Task<IList<Request>> GetAllRequestsByEmployeesByStatus(int adminId,string Status);
        public Task<IList<Request>> GetAllRequestsByAdmin(int adminId);
        public Task<bool> MarkRequestCloseByAdmin(int requestId,int adminId);
    }
}
