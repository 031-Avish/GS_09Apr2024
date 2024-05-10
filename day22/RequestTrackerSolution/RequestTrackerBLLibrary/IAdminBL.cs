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
        public Task<RequestSolution> AddSolutionByAdmin(int requestId, String SolutionDesc);
        public Task<bool> MarkRequestCloseByAdmin(int requestId);
    }
}
