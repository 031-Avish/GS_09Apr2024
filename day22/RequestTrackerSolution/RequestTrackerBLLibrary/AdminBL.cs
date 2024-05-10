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

        public Task<RequestSolution> AddSolutionByAdmin(int requestId, string SolutionDesc)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MarkRequestCloseByAdmin(int requestId)
        {
            throw new NotImplementedException();
        }
    }
}
