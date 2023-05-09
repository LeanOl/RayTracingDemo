using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PasswordMismatchException :Exception
    {
    public PasswordMismatchException(string message) : base(message)
    {

    }
}
}
