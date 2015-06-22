using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM_Manager.Domain
{
    public class Create_First_Step_Model : View_Model_To_Service
    {
        public Create_First_Step_Model(Libvirt.CS_Objects.Host con, Libvirt.Models.Concrete.Virtual_Machine d)
            : base(con, d)
        {

        }
        protected override bool Validate(Libvirt.Models.Interface.IValdiator v)
        {
            _Machine_Definition.Metadata.Validate(v);
            if (v.IsValid())
            {
                Libvirt.CS_Objects.Domain[] domains;
                if(_Connection.virConnectListAllDomains(out domains, Libvirt.virConnectListAllDomainsFlags.VIR_CONNECT_LIST_DOMAINS_PERSISTENT | Libvirt.virConnectListAllDomainsFlags.VIR_CONNECT_LIST_DOMAINS_TRANSIENT)>0){
                    foreach (var item in domains)
                    {
                        if (item.virDomainGetName() == Machine_Definition.Metadata.name)
                        {
                            v.AddError("General_Metadata.name", "A VM with that name already exists, try another!");
                            break;
                        }
                    }
                    foreach (var item in domains)
                    {
                        item.Dispose();
                    }
                }
            }
            return v.IsValid();
        }
    }
}
