using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exception
{

    public class NoCartItemWithGivenIdException:System.Exception
    {
        string msg;
        public NoCartItemWithGivenIdException()
        {
            msg = "No card is present";
        }

        public override string Message => msg;
    }
}
