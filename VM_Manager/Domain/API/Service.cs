using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VM_Manager.Domain.API
{
    public static class Service
    {
        public static bool Create_VM(Libvirt.virConnectPtr con, Model.Virtual_Machine _Machine_Def)
        {
            string test = "<domain type='qemu'><name>" + _Machine_Def.Name + "</name><memory unit='MB'>" + _Machine_Def.Ram.ToString() + "</memory><vcpu>" + _Machine_Def.Cpu.ToString() + "</vcpu><os><type arch='i686' machine='pc'>hvm</type><boot dev='cdrom'/>";
            test += "</os><devices><disk type='file' device='cdrom'><source file='" + _Machine_Def.iso_Path + "'/><target dev='hdc'/><readonly/></disk>";
            test += "<disk type='file' device='disk'><source file='" + _Machine_Def.storage_path + "'/><target dev='hda'/></disk><interface type='network'><source network='default'/></interface><graphics type='vnc' port='-1'/></devices></domain>";
            var domainout = Libvirt.API.virDomainDefineXML(con, test);
            if(domainout.Pointer != IntPtr.Zero)
            {
                Libvirt.API.virDomainCreate(domainout);
            }
            return true; 
        }
    }
}
