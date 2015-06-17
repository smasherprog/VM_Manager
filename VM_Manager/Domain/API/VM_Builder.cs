using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Manager.Domain.API
{
    static public class VM_Builder
    {
        public static VM_Manager.Domain.Model.Virtual_Machine CreateFrom(string xml){
            var vm = new Model.Virtual_Machine();




            return vm;
        }
        public static string CreateFrom(VM_Manager.Domain.Model.Virtual_Machine machine){
            var stbuilder = new StringBuilder();


            return stbuilder.ToString();
        }
    }
}
