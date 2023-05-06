using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Client
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public override bool Equals(Object obj)
        {
            Client clientToCompare = obj as Client;
            if (clientToCompare == null)
            {
                return false;
            }
            else
            {
                
                return Username == clientToCompare.Username;
            }
        }

        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }
    }
    
}
