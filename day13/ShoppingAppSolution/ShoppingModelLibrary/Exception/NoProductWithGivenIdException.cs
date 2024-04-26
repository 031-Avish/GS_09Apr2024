using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exception
{
    public class NoProductWithGivenIdException : System.Exception
    {
        string msg;
        public NoProductWithGivenIdException() {
            msg = "No product found with Given Id";
        }
        public override string Message => msg;

    }
}
