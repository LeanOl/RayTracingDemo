using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;


namespace Interface
{
    static class Instance
    {
        public static ClientLogic InstanceClientLogic { get; } = new ClientLogic();
        public static SessionLogic InstanceSessionLogic { get; } = new SessionLogic(InstanceClientLogic);

        public static MaterialLogic MateriaLogic { get; } = new MaterialLogic();


    }
}
