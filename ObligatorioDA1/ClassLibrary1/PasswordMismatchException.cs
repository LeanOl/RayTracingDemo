using System;

namespace Logic
{
    public class PasswordMismatchException :Exception
    {
    public PasswordMismatchException(string message) : base(message)
    {

    }
}
}
