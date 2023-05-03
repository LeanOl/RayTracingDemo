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
            if ((obj == null) || !(obj is Client))
            {
                return false;
            }
            else
            {
                Client client = (Client)obj;
                return Username == client.Username;
            }
        }
    }
    
}
